using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Control.Models.Entities;
using Control.Models.Settings;
using ExcelDataReader;

namespace Control.Logic
{
    public static class ConsignacionesLogic
    {
        private static readonly string[] DateFormats = new[]
        {
            "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "MM/dd/yyyy",
            "dd/MM/yy", "dd-MM-yy", "d/M/yyyy", "d-M-yyyy"
        };

        /// <summary>
        /// Lee el archivo de movimientos de stock y devuelve un item por cada detalle (serie) del movimiento.
        /// Soporta HTML (.xls exportado) con tabla anidada y Excel plano (.xlsx).
        /// </summary>
        public static List<MovimientoConsignacion>? LeerMovimientos(string ruta, ConsignacionSettings settings)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                if (IsHtmlFile(ruta))
                {
                    return LeerMovimientosHtml(ruta, settings);
                }

                // Pri­mero se intenta el layout plano (cabecera única); si no calza,
                // se parsea el layout anidado de producción (tabla principal + detalle por movimiento).
                var tabular = LeerMovimientosFlat(ruta, settings);
                if (tabular != null)
                {
                    return tabular;
                }

                return LeerMovimientosNested(ruta, settings);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static List<MovimientoConsignacion> LeerMovimientosHtml(string ruta, ConsignacionSettings settings)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(ruta);

            string colCode = settings.MovColCode.Trim();
            string colSerial = settings.MovColSerial.Trim();
            string colDate = settings.MovColDate.Trim();
            string colFrom = settings.MovColFrom.Trim();
            string colTo = settings.MovColTo.Trim();

            var movimientos = new List<MovimientoConsignacion>();
            var tables = doc.DocumentNode.SelectNodes("//table");
            if (tables == null)
            {
                return movimientos;
            }

            // 1. Localizar la tabla principal: su "thead" contiene la columna de fecha y depósitos.
            var mainTable = tables.FirstOrDefault(t =>
            {
                var headers = GetHeaderCells(t);
                return headers.Any(h => h.Equals(colDate, StringComparison.OrdinalIgnoreCase))
                    && headers.Any(h => h.Equals(colFrom, StringComparison.OrdinalIgnoreCase))
                    && headers.Any(h => h.Equals(colTo, StringComparison.OrdinalIgnoreCase));
            });

            if (mainTable == null)
            {
                return null;
            }

            var mainHeaders = GetHeaderCells(mainTable);
            int posDate = mainHeaders.FindIndex(h => h.Equals(colDate, StringComparison.OrdinalIgnoreCase));
            int posFrom = mainHeaders.FindIndex(h => h.Equals(colFrom, StringComparison.OrdinalIgnoreCase));
            int posTo = mainHeaders.FindIndex(h => h.Equals(colTo, StringComparison.OrdinalIgnoreCase));

            DateTime? currentDate = null;
            string currentFrom = "";
            string currentTo = "";

            // 2. Recorrer las filas del cuerpo de la tabla principal.
            var rows = mainTable.SelectNodes("./tbody/tr");
            if (rows == null)
            {
                return movimientos;
            }

            foreach (var row in rows)
            {
                var nestedTables = row.SelectNodes(".//table");

                if (nestedTables != null && nestedTables.Count > 0)
                {
                    foreach (var nested in nestedTables)
                    {
                        var nestedHeaders = GetHeaderCells(nested);
                        int posCode = nestedHeaders.FindIndex(h => h.Equals(colCode, StringComparison.OrdinalIgnoreCase));
                        int posSerial = nestedHeaders.FindIndex(h => h.Equals(colSerial, StringComparison.OrdinalIgnoreCase));
                        if (posCode == -1 || posSerial == -1)
                        {
                            continue;
                        }

                        var detailRows = nested.SelectNodes("./tbody/tr");
                        if (detailRows == null)
                        {
                            continue;
                        }

                        foreach (var detailRow in detailRows)
                        {
                            var cells = detailRow.SelectNodes("./td");
                            if (cells == null)
                            {
                                continue;
                            }

                            var textos = cells.Select(c => c.InnerText.Trim()).ToList();
                            if (textos.Count <= Math.Max(posCode, posSerial))
                            {
                                continue;
                            }

                            var code = textos[posCode];
                            var serial = SplitSerie(textos[posSerial]);

                            // Solo se informan ítems con número de serie (tarea del cliente).
                            if (string.IsNullOrWhiteSpace(serial))
                            {
                                continue;
                            }

                            movimientos.Add(new MovimientoConsignacion
                            {
                                Serial = serial,
                                Code = code,
                                Date = currentDate,
                                FromDepto = currentFrom,
                                ToDepto = currentTo
                            });
                        }
                    }
                }
                else
                {
                    // Fila de cabecera del movimiento: actualiza fecha y depósitos vigentes.
                    var cells = row.SelectNodes("./td");
                    if (cells == null)
                    {
                        continue;
                    }

                    var textos = cells.Select(c => c.InnerText.Trim()).ToList();
                    if (textos.Count <= Math.Max(Math.Max(posDate, posFrom), posTo))
                    {
                        continue;
                    }

                    var fechaText = textos[posDate];
                    var fechaParsed = ParseFecha(fechaText);
                    if (fechaParsed.HasValue)
                    {
                        currentDate = fechaParsed.Value;
                    }

                    currentFrom = GetCellValue(textos, posFrom);
                    currentTo = GetCellValue(textos, posTo);
                }
            }

            return movimientos;
        }

        private static List<MovimientoConsignacion> LeerMovimientosFlat(string ruta, ConsignacionSettings settings)
        {
            var movimientos = new List<MovimientoConsignacion>();

            string colCode = settings.MovColCode.Trim();
            string colSerial = settings.MovColSerial.Trim();
            string colDate = settings.MovColDate.Trim();
            string colFrom = settings.MovColFrom.Trim();
            string colTo = settings.MovColTo.Trim();

            using var stream = File.Open(ruta, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            int maxIntentos = 50;
            int intentos = 0;
            int posCode = -1, posSerial = -1, posDate = -1, posFrom = -1, posTo = -1;
            bool headerFound = false;

            while (intentos < maxIntentos && reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                posCode = fila.FindIndex(f => f.Equals(colCode, StringComparison.OrdinalIgnoreCase));
                posSerial = fila.FindIndex(f => f.Equals(colSerial, StringComparison.OrdinalIgnoreCase));
                posDate = fila.FindIndex(f => f.Equals(colDate, StringComparison.OrdinalIgnoreCase));
                posFrom = fila.FindIndex(f => f.Equals(colFrom, StringComparison.OrdinalIgnoreCase));
                posTo = fila.FindIndex(f => f.Equals(colTo, StringComparison.OrdinalIgnoreCase));

                if (posCode >= 0 && posSerial >= 0 && posDate >= 0)
                {
                    headerFound = true;
                    break;
                }

                intentos++;
            }

            if (!headerFound || posCode == -1 || posSerial == -1 || posDate == -1)
            {
                return null;
            }

            while (reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                var code = GetCellValue(fila, posCode);
                var serial = SplitSerie(GetCellValue(fila, posSerial));
                var fecha = ParseFecha(GetCellValue(fila, posDate));

                // Solo se informan ítems con número de serie (tarea del cliente).
                if (string.IsNullOrWhiteSpace(serial))
                {
                    continue;
                }

                movimientos.Add(new MovimientoConsignacion
                {
                    Serial = serial,
                    Code = code,
                    Date = fecha,
                    FromDepto = GetCellValue(fila, posFrom),
                    ToDepto = GetCellValue(fila, posTo)
                });
            }

            return movimientos;
        }

        /// <summary>
        /// Parseo del layout de producción: una tabla principal con las columnas del movimiento
        /// (Nro., Fecha, Desde Depósito, Hasta Depósito, Totales...) y, por cada movimiento,
        /// una sub-cabecera de detalle (Artículo, Nombre, Cant., Unidad, Nro. Serie, ...) seguida
        /// de las líneas del detalle y una fila de total. Cada línea de detalle hereda la fecha y
        /// los depósitos del movimiento que la contiene. Solo se informan detalles con número de serie.
        /// </summary>
        private static List<MovimientoConsignacion> LeerMovimientosNested(string ruta, ConsignacionSettings settings)
        {
            var movimientos = new List<MovimientoConsignacion>();

            string colCode = settings.MovColCode.Trim();
            string colSerial = settings.MovColSerial.Trim();
            string colDate = settings.MovColDate.Trim();
            string colFrom = settings.MovColFrom.Trim();
            string colTo = settings.MovColTo.Trim();

            using var stream = File.Open(ruta, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            // 1. Localizar la cabecera principal del listado (Nro./Fecha/Desde Depósito/Hasta Depósito/...).
            int posDate = -1, posFrom = -1, posTo = -1;
            int intentos = 0;
            bool headerFound = false;

            while (intentos < 50 && reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                posDate = fila.FindIndex(f => f.Equals(colDate, StringComparison.OrdinalIgnoreCase));
                posFrom = fila.FindIndex(f => f.Equals(colFrom, StringComparison.OrdinalIgnoreCase));
                posTo = fila.FindIndex(f => f.Equals(colTo, StringComparison.OrdinalIgnoreCase));

                if (posDate >= 0 && posFrom >= 0 && posTo >= 0)
                {
                    headerFound = true;
                    break;
                }

                intentos++;
            }

            if (!headerFound)
            {
                return null;
            }

            // 2. Recorrer los bloques: fila del movimiento (fecha + depósitos vigentes),
            //    sub-cabecera de detalle y líneas de detalle serializadas.
            DateTime? fechaMovimiento = null;
            string desdeDeposito = "";
            string hastaDeposito = "";
            int posCode = -1, posSerial = -1;

            while (reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                // Fila de cabecera del movimiento: la fecha del bloque vigente para el detalle siguiente.
                var fecha = ParseFecha(GetCellValue(fila, posDate));
                if (fecha.HasValue && !string.IsNullOrWhiteSpace(GetCellValue(fila, posFrom)))
                {
                    fechaMovimiento = fecha;
                    desdeDeposito = GetCellValue(fila, posFrom);
                    hastaDeposito = GetCellValue(fila, posTo);
                    posCode = -1;
                    posSerial = -1;
                    continue;
                }

                // Sub-cabecera del detalle anidado (Artículo/Nombre/Cant./Unidad/Nro. Serie/...).
                if (posCode == -1
                    && fila.Any(f => f.Equals(colCode, StringComparison.OrdinalIgnoreCase))
                    && fila.Any(f => f.Equals(colSerial, StringComparison.OrdinalIgnoreCase)))
                {
                    posCode = fila.FindIndex(f => f.Equals(colCode, StringComparison.OrdinalIgnoreCase));
                    posSerial = fila.FindIndex(f => f.Equals(colSerial, StringComparison.OrdinalIgnoreCase));
                    continue;
                }

                if (posCode < 0)
                {
                    continue;
                }

                var code = GetCellValue(fila, posCode);
                var serial = SplitSerie(GetCellValue(fila, posSerial));

                // Solo se informan ítems con número de serie (tarea del cliente).
                if (string.IsNullOrWhiteSpace(serial))
                {
                    continue;
                }

                movimientos.Add(new MovimientoConsignacion
                {
                    Serial = serial,
                    Code = code,
                    Date = fechaMovimiento,
                    FromDepto = desdeDeposito,
                    ToDepto = hastaDeposito
                });
            }

            return movimientos;
        }

        private static List<string> GetHeaderCells(HtmlAgilityPack.HtmlNode table)
        {
            var headers = new List<string>();

            var headRows = table.SelectNodes("./thead/tr");
            if (headRows != null)
            {
                foreach (var headRow in headRows)
                {
                    var ths = headRow.SelectNodes("./th");
                    if (ths != null)
                    {
                        headers.AddRange(ths.Select(t => t.InnerText.Trim()));
                        if (headers.Count > 0)
                        {
                            break;
                        }
                    }
                }
            }

            return headers;
        }

        private static DateTime? ParseFecha(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string clean = text.Trim();

            // Serial numérico de Excel (ej. 46085 = fecha del movimiento en el listado de producción).
            if (double.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out double serialOa)
                && serialOa >= 1 && serialOa < 60000)
            {
                try
                {
                    return DateTime.FromOADate(serialOa);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Se cae al parseo de texto.
                }
            }

            if (DateTime.TryParseExact(clean, DateFormats, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var exact))
            {
                return exact;
            }

            if (DateTime.TryParse(clean, CultureInfo.GetCultureInfo("es-AR"), DateTimeStyles.None, out var parsed))
            {
                return parsed;
            }

            return null;
        }

        private static string SplitSerie(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            return text.Split('/')[0].Trim();
        }

        private static string GetCellValue(List<string> fila, int pos)
        {
            if (pos < 0 || pos >= fila.Count)
            {
                return "";
            }

            return fila[pos];
        }

        /// <summary>
        /// Cruza movimientos y stock por número de serie y asigna el estado según las reglas A–D:
        /// A) en stock y días ≤ plazo → EnPlazo; B) en stock y días > plazo → Vencida;
        /// C) ya no en stock → Entregado; D) en stock sin movimiento → Vencida + SerieSinMovimiento.
        /// Para una serie con varios movimientos se usa el más antiguo (movimiento original).
        /// </summary>
        public static List<ItemConsignacion>? ComputeEstados(
            List<MovimientoConsignacion>? movimientos,
            List<StockConsignacion>? stock,
            ConsignacionSettings settings,
            DateTime fechaReporte)
        {
            if (movimientos == null || stock == null)
            {
                return null;
            }

            // Movimiento original por serie: el más antiguo con fecha.
            var movimientoPorSerie = new Dictionary<string, MovimientoConsignacion>(StringComparer.Ordinal);
            foreach (var m in movimientos)
            {
                if (string.IsNullOrWhiteSpace(m.Serial))
                {
                    continue;
                }

                if (!movimientoPorSerie.TryGetValue(m.Serial, out var actual))
                {
                    movimientoPorSerie[m.Serial] = m;
                }
                else if (EsMasAntiguo(m, actual))
                {
                    movimientoPorSerie[m.Serial] = m;
                }
            }

            // Serie en stock con depósito actual (se ignoran series vacías o "0" sin serializar).
            var depositoPorSerie = new Dictionary<string, string>(StringComparer.Ordinal);
            var codePorSerie = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var s in stock)
            {
                if (string.IsNullOrWhiteSpace(s.Serial) || s.Serial == "0")
                {
                    continue;
                }

                if (!depositoPorSerie.ContainsKey(s.Serial))
                {
                    depositoPorSerie[s.Serial] = s.Depto;
                    codePorSerie[s.Serial] = s.Code;
                }
            }

            var result = new List<ItemConsignacion>();

            foreach (var kv in depositoPorSerie)
            {
                string serial = kv.Key;
                var tieneMovimiento = movimientoPorSerie.TryGetValue(serial, out var movement);

                var item = new ItemConsignacion
                {
                    Serial = serial,
                    Code = codePorSerie[serial],
                    CurrentDepot = kv.Value,
                    SerieSinMovimiento = !tieneMovimiento
                };

                if (tieneMovimiento && movement!.Date.HasValue)
                {
                    item.DepartureDate = movement.Date.Value.ToString("dd/MM/yyyy");
                    item.DaysElapsed = (fechaReporte.Date - movement.Date.Value.Date).Days;
                    item.State = item.DaysElapsed <= settings.PlazoLimite
                        ? ConsignacionEstado.EnPlazo
                        : ConsignacionEstado.Vencida;
                }
                else
                {
                    // Regla D: sin movimiento registrado (o sin fecha parseada) → Vencida.
                    item.State = ConsignacionEstado.Vencida;
                }

                result.Add(item);
            }

            // Movimientos cuya serie ya no figura en el stock actual → Entregado.
            var serialesEnStock = new HashSet<string>(depositoPorSerie.Keys, StringComparer.Ordinal);
            foreach (var kv in movimientoPorSerie)
            {
                if (serialesEnStock.Contains(kv.Key))
                {
                    continue;
                }

                var item = new ItemConsignacion
                {
                    Serial = kv.Key,
                    Code = kv.Value.Code,
                    Delivered = true,
                    State = ConsignacionEstado.Entregado
                };

                if (kv.Value.Date.HasValue)
                {
                    item.DepartureDate = kv.Value.Date.Value.ToString("dd/MM/yyyy");
                    item.DaysElapsed = (fechaReporte.Date - kv.Value.Date.Value.Date).Days;
                }

                result.Add(item);
            }

            return OrdenarPorCriticidad(result);
        }

        /// <summary>
        /// Ordena el reporte por criticidad: primero las consignaciones vencidas, luego las en plazo
        /// y por último las entregadas. Dentro de cada grupo quedan primero las que más días
        /// transcurridos tienen, que es lo que el usuario necesita ver cuanto antes.
        /// </summary>
        public static List<ItemConsignacion> OrdenarPorCriticidad(IEnumerable<ItemConsignacion> items)
        {
            return items
                .OrderBy(i => PrioridadEstado(i.State))
                .ThenByDescending(i => i.DaysElapsed)
                .ThenBy(i => i.Serial, StringComparer.Ordinal)
                .ToList();
        }

        private static int PrioridadEstado(ConsignacionEstado estado)
        {
            return estado switch
            {
                ConsignacionEstado.Vencida => 0,
                ConsignacionEstado.EnPlazo => 1,
                _ => 2
            };
        }

        public static string EstadoTexto(ConsignacionEstado estado)
        {
            return estado switch
            {
                ConsignacionEstado.EnPlazo => "Consignación en Plazo",
                ConsignacionEstado.Entregado => "OK - Entregado",
                _ => "Consignación Vencida"
            };
        }

        private static bool EsMasAntiguo(MovimientoConsignacion candidato, MovimientoConsignacion actual)
        {
            if (!candidato.Date.HasValue)
            {
                return false;
            }

            return !actual.Date.HasValue || candidato.Date < actual.Date;
        }

        /// <summary>
        /// Lee el archivo de stock actual y devuelve un ítem por fila con serie no vacía.
        /// Soporta HTML (.xls exportado) y Excel plano (.xlsx); descarta las filas de resumen "Filas" y "Artículos".
        /// </summary>
        public static List<StockConsignacion>? LeerStock(string ruta, ConsignacionSettings settings)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                if (IsHtmlFile(ruta))
                {
                    return LeerStockHtml(ruta, settings);
                }

                return LeerStockFlat(ruta, settings);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static List<StockConsignacion> LeerStockHtml(string ruta, ConsignacionSettings settings)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(ruta);

            string colCode = settings.StockColCode.Trim();
            string colSerial = settings.StockColSerial.Trim();
            string colDepot = settings.StockColDepot.Trim();
            string colQty = settings.StockColQty.Trim();

            var stock = new List<StockConsignacion>();
            var tables = doc.DocumentNode.SelectNodes("//table");
            if (tables == null)
            {
                return stock;
            }

            var mainTable = tables.FirstOrDefault(t =>
            {
                var headers = GetHeaderCells(t);
                return headers.Any(h => h.Equals(colCode, StringComparison.OrdinalIgnoreCase))
                    && headers.Any(h => h.Equals(colSerial, StringComparison.OrdinalIgnoreCase))
                    && headers.Any(h => h.Equals(colDepot, StringComparison.OrdinalIgnoreCase))
                    && headers.Any(h => h.Equals(colQty, StringComparison.OrdinalIgnoreCase));
            });

            if (mainTable == null)
            {
                return null;
            }

            var mainHeaders = GetHeaderCells(mainTable);
            int posCode = mainHeaders.FindIndex(h => h.Equals(colCode, StringComparison.OrdinalIgnoreCase));
            int posSerial = mainHeaders.FindIndex(h => h.Equals(colSerial, StringComparison.OrdinalIgnoreCase));
            int posDepot = mainHeaders.FindIndex(h => h.Equals(colDepot, StringComparison.OrdinalIgnoreCase));
            int posQty = mainHeaders.FindIndex(h => h.Equals(colQty, StringComparison.OrdinalIgnoreCase));

            var rows = mainTable.SelectNodes("./tbody/tr");
            if (rows == null)
            {
                return stock;
            }

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("./td");
                if (cells == null)
                {
                    continue;
                }

                var textos = cells.Select(c => c.InnerText.Trim()).ToList();
                if (textos.Count <= Math.Max(Math.Max(posCode, posSerial), Math.Max(posDepot, posQty)))
                {
                    continue;
                }

                var code = textos[posCode];
                var serial = SplitSerie(textos[posSerial]);

                // Filas de resumen del export ("Filas" y "Artículos").
                if (code.Equals("Filas", StringComparison.OrdinalIgnoreCase)
                    || code.Equals("Artículos", StringComparison.OrdinalIgnoreCase)
                    || code.Equals("Articulos", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(serial) && string.IsNullOrWhiteSpace(code))
                {
                    continue;
                }

                stock.Add(new StockConsignacion
                {
                    Code = code,
                    Serial = serial,
                    Depto = GetCellValue(textos, posDepot),
                    Qty = ParseQty(GetCellValue(textos, posQty))
                });
            }

            return stock;
        }

        private static List<StockConsignacion> LeerStockFlat(string ruta, ConsignacionSettings settings)
        {
            var stock = new List<StockConsignacion>();

            string colCode = settings.StockColCode.Trim();
            string colSerial = settings.StockColSerial.Trim();
            string colDepot = settings.StockColDepot.Trim();
            string colQty = settings.StockColQty.Trim();

            using var stream = File.Open(ruta, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            int maxIntentos = 50;
            int intentos = 0;
            int posCode = -1, posSerial = -1, posDepot = -1, posQty = -1;
            bool headerFound = false;

            while (intentos < maxIntentos && reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                posCode = fila.FindIndex(f => f.Equals(colCode, StringComparison.OrdinalIgnoreCase));
                posSerial = fila.FindIndex(f => f.Equals(colSerial, StringComparison.OrdinalIgnoreCase));
                posDepot = fila.FindIndex(f => f.Equals(colDepot, StringComparison.OrdinalIgnoreCase));
                posQty = fila.FindIndex(f => f.Equals(colQty, StringComparison.OrdinalIgnoreCase));

                if (posCode >= 0 && posSerial >= 0 && posDepot >= 0 && posQty >= 0)
                {
                    headerFound = true;
                    break;
                }

                intentos++;
            }

            if (!headerFound)
            {
                return null;
            }

            while (reader.Read())
            {
                var fila = Enumerable.Range(0, reader.FieldCount)
                                     .Select(i => reader.GetValue(i)?.ToString()?.Trim() ?? "")
                                     .ToList();

                var code = GetCellValue(fila, posCode);
                var serial = SplitSerie(GetCellValue(fila, posSerial));

                if (code.Equals("Filas", StringComparison.OrdinalIgnoreCase)
                    || code.Equals("Artículos", StringComparison.OrdinalIgnoreCase)
                    || code.Equals("Articulos", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(serial) && string.IsNullOrWhiteSpace(code))
                {
                    continue;
                }

                stock.Add(new StockConsignacion
                {
                    Code = code,
                    Serial = serial,
                    Depto = GetCellValue(fila, posDepot),
                    Qty = ParseQty(GetCellValue(fila, posQty))
                });
            }

            return stock;
        }

        private static int ParseQty(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            if (int.TryParse(text.Trim(), out int entero))
            {
                return entero;
            }

            if (decimal.TryParse(text.Trim(), NumberStyles.Any, CultureInfo.GetCultureInfo("es-ES"),
                    out decimal decimalEs))
            {
                return (int)decimalEs;
            }

            if (decimal.TryParse(text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture,
                    out decimal decimalInv))
            {
                return (int)decimalInv;
            }

            return 0;
        }

        private static bool IsHtmlFile(string path)
        {
            using var reader = new StreamReader(path);
            char[] buffer = new char[100];
            int read = reader.Read(buffer, 0, buffer.Length);
            string start = new string(buffer, 0, read).ToLowerInvariant();

            return start.Contains("<html") || start.Contains("<!doctype");
        }
    }
}