using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using HtmlAgilityPack;
using QRCoder;
using ClosedXML;
using ClosedXML.Excel;
using System.Text.RegularExpressions;
using System.Reflection;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;
using Microsoft.VisualBasic;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Control.Models.Settings;
using Control.Models.Entities;

namespace Control.Logic
{
    public class Functions
    {
        #region Lectura de Anexos

        /// <summary>
        /// Lee archivo <c>xls</c> o <c>xlsx</c>
        /// </summary>
        /// <param name="ruta">Path correspondiente al archivo.</param>
        /// <param name="header">Encabezados a buscar dentro del archivo.</param>
        /// <param name="firstColumn">Primera columna que se espera encontrar.</param>
        /// <param name="movementsBernafon">Si el archivo pertenece a los movimientos de stock de Bernafon.</param>
        /// <returns>Retorna el listado de items anexo capturados del archivo.</returns>
        public static List<ItemAnexo>? ReadAnexoFile(string ruta, Models.Entities.Headers header, bool movementsBernafon = false, bool groupItems = true)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                List<string[]> filas = new List<string[]>();
                List<ItemAnexo> listItems = new List<ItemAnexo>();
                bool headerFound = false;
                int intentos = 0;

                if (IsHtmlFile(ruta))
                {
                    listItems = bringFromHtml(ruta, header);
                    return listItems;
                }

                int maxIntentos = 20;


                using (var stream = File.Open(ruta, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read() && intentos < maxIntentos)
                        {

                            // Accedo al total de la fila
                            string?[] fila = Enumerable.Range(0, reader.FieldCount)
                                                      .Select(i => reader.GetValue(i)?.ToString()?.Trim())
                                                      .ToArray();

                            // Para los movimientos de Bernafon solo me interesan columnas Código Artículo y Cantidad
                            if (movementsBernafon)
                            {
                                if (!headerFound && fila.Contains(header.ArtCode.Name))
                                {
                                    header.ArtCode.Position = Array.IndexOf(fila, header.ArtCode.Name);
                                    header.Qty.Position = Array.IndexOf(fila, header.Qty.Name);
                                    headerFound = true;
                                }

                                if (header.ArtCode.Position == -1 || header.Qty.Position == -1)
                                {
                                    MessageBox.Show("El formato de las columnas del anexo no es válido, por favor corroborar desde la configuración que los nombres de las columnas coincidan.", "Nombre de columnas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return null;
                                }
                            }
                            else
                            {
                                // Si tengo el artículo, significa que es el header de la tabla en el archivo
                                if (!headerFound && fila.Contains(header.ArtCode.Name))
                                {
                                    header.ArtCode.Position = Array.IndexOf(fila, header.ArtCode.Name);
                                    header.Qty.Position = Array.IndexOf(fila, header.Qty.Name);
                                    header.Description.Position = Array.IndexOf(fila, header.Description.Name);
                                    header.SerialNr.Position = Array.IndexOf(fila, header.SerialNr.Name);
                                    header.DueDate.Position = Array.IndexOf(fila, header.DueDate.Name);
                                    headerFound = true;
                                }

                                if (header.ArtCode.Position == -1 || header.Qty.Position == -1 || header.Description.Position == -1 || header.SerialNr.Position == -1 || header.DueDate.Position == -1)
                                {
                                    MessageBox.Show("El formato de las columnas del anexo no es válido, por favor corroborar desde la configuración que los nombres de las columnas coincidan.", "Nombre de columnas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return null;
                                }
                            }

                            if (!headerFound)
                            {
                                intentos++;
                                continue;
                            }

                            while (reader.Read())
                            {
                                try
                                {
                                    var codItem = reader.GetValue(header.ArtCode.Position);

                                    // Implica que ya no hay ítems por leer
                                    if (codItem == null || string.IsNullOrEmpty(codItem.ToString()) || string.IsNullOrWhiteSpace(codItem.ToString()))
                                    {
                                        break;
                                    }

                                    if (string.Compare(codItem.ToString().Trim(), "Filas") == 0 || string.Compare(codItem.ToString().Trim(), "Artículos") == 0)
                                    {
                                        break;
                                    }

                                    if (movementsBernafon)
                                    {
                                        var rawValue = reader.GetValue(header.Qty.Position);

                                        if (rawValue == DBNull.Value || rawValue == null)
                                        {
                                            continue;
                                        }

                                        var quantity = getQuantityValue(reader.GetValue(header.Qty.Position).ToString());

                                        ItemAnexo newItem = new ItemAnexo();
                                        newItem.CodItem = codItem.ToString().Trim();
                                        newItem.Quantity = quantity;

                                        ItemAnexo? itemExist = listItems.FirstOrDefault(x => x.CodItem == newItem.CodItem && x.SerialNumber == newItem.SerialNumber && x.DueDate == newItem.DueDate);

                                        if (itemExist != null && groupItems)
                                        {
                                            itemExist.Quantity += quantity;
                                        }
                                        else
                                        {
                                            listItems.Add(newItem);
                                        }

                                    }
                                    else
                                    {

                                        var description = reader.GetValue(header.Description.Position);
                                        var serialNumber = reader.GetValue(header.SerialNr.Position);
                                        var dueDate = reader.GetValue(header.DueDate.Position);
                                        var quantity = getQuantityValue(reader.GetValue(header.Qty.Position).ToString());
                                        string dueDateString = "";

                                        if (dueDate != null)
                                        {
                                            var dateNormalized = NormalizeTwoDigitYearDate(dueDate);
                                            if (dateNormalized.HasValue)
                                                dueDateString = dateNormalized.Value.ToString("dd/MM/yyyy");
                                        }

                                        ItemAnexo newItem = new ItemAnexo();
                                        string codItemStr = codItem.ToString();

                                        // Si la posición del código y de la descripción son la misma entonces el código y descripción vienen concatenados.
                                        if (header.ArtCode.Position == header.Description.Position && !string.IsNullOrWhiteSpace(codItemStr))
                                        {
                                            var codSplitted = GetCodeDescriptionSplitted(codItemStr);
                                            newItem.CodItem = codSplitted.codItem;
                                            newItem.Description = codSplitted.description;
                                        }
                                        else
                                        {
                                            newItem.CodItem = codItem.ToString();
                                            newItem.Description = description != null ? description.ToString() : "";
                                        }
                                        newItem.Quantity = quantity;
                                        newItem.SerialNumber = serialNumber != null ? serialNumber.ToString().Split("/")[0] : "";
                                        newItem.DueDate = dueDateString;

                                        ItemAnexo? itemExist = listItems.FirstOrDefault(x => x.CodItem == newItem.CodItem && x.SerialNumber == newItem.SerialNumber && x.DueDate == newItem.DueDate);

                                        if (itemExist != null && groupItems)
                                        {
                                            itemExist.Quantity += quantity;
                                        }
                                        else
                                        {
                                            listItems.Add(newItem);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Hubo un error al leer los datos del archivo: {ex}.", "Error de lectura de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return null;
                                }
                            }

                            break;
                        }

                        if (intentos == maxIntentos)
                        {
                            MessageBox.Show($"No se encontró información correcta en las primeras {maxIntentos} filas del archivo, por lo que no se pudo leer.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }

                return listItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al leer los datos desde el archivo: {ex}", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Identifica si el archivo es un Html
        private static bool IsHtmlFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                char[] buffer = new char[100];
                int read = reader.Read(buffer, 0, buffer.Length);
                string start = new string(buffer, 0, read).ToLowerInvariant();

                // Si empieza con <html o <!doctype => es HTML
                return start.Contains("<html") || start.Contains("<!doctype");
            }
        }

        // Lectura de archivo si tiene formato Html
        private static List<ItemAnexo>? bringFromHtml(string ruta, Models.Entities.Headers header)
        {
            List<ItemAnexo> itemsAnexo = new List<ItemAnexo>();
            try
            {

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(ruta); // carga el "xls" que en realidad es html

                // Buscar todas las filas <tr> dentro del último <table>
                var rows = doc.DocumentNode.SelectNodes("//table[last()]/tbody/tr");
                var headerHtml = doc.DocumentNode.SelectNodes("//table[last()]/thead/tr");

                // Recorro el header para acceder a la posición de cada columna
                foreach (var head in headerHtml)
                {
                    var cells = head.SelectNodes("th");
                    List<string> list = cells.Select(x => x.InnerText).ToList();

                    if (list.Contains(header.ArtCode.Name))
                    {
                        header.ArtCode.Position = list.IndexOf(header.ArtCode.Name);
                        header.Qty.Position = list.IndexOf(header.Qty.Name);
                        header.Description.Position = list.IndexOf(header.Description.Name);
                        header.SerialNr.Position = list.IndexOf(header.SerialNr.Name);
                        header.DueDate.Position = list.IndexOf(header.DueDate.Name);
                    }

                    if (header.ArtCode.Position == -1 || header.Qty.Position == -1 || header.Description.Position == -1 || header.SerialNr.Position == -1 || header.DueDate.Position == -1)
                    {
                        MessageBox.Show("El formato de las columnas del anexo no es válido, por favor corroborar desde la configuración que los nombres de las columnas coincidan.", "Nombre de columnas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                }

                // Recorro cada fila para obtener los itemAnexo
                foreach (var row in rows)
                {
                    var cells = row.SelectNodes("td");
                    List<string> list = cells.Select(x => x.InnerText.Trim()).ToList();
                    if (cells != null)
                    {
                        ItemAnexo newItem = new ItemAnexo();
                        string codeItem = list[header.ArtCode.Position].ToString().Trim();
                        string qtyItem = list[header.Qty.Position].ToString().Trim();
                        string descriptionItem = list[header.Description.Position].ToString().Trim();
                        string serialItem = list[header.SerialNr.Position].ToString().Trim();
                        string dueDateItem = list[header.DueDate.Position].ToString().Trim();

                        // Las últimas 2 filas del html son información general que no me interesa
                        if (string.Compare("Artículos", codeItem) == 0 || string.Compare("Filas", codeItem) == 0)
                        {
                            continue;
                        }

                        if (serialItem.Contains("/"))
                        {
                            serialItem = serialItem.Split("/")[0].ToString().Trim();
                        }

                        decimal qty = getQuantityValue(qtyItem);

                        ItemAnexo existingItem = itemsAnexo.FirstOrDefault(x => x.CodItem == codeItem && x.SerialNumber == serialItem && x.Quantity == qty);

                        if (existingItem == null)
                        {
                            newItem.CodItem = codeItem;
                            newItem.SerialNumber = serialItem;
                            newItem.Quantity = (int)qty;
                            newItem.Description = descriptionItem;
                            //newItem.DueDate = !string.IsNullOrEmpty(dueDateItem) ? dueDateItem : "No Aplica";

                            if (string.IsNullOrEmpty(dueDateItem) || dueDateItem.Contains("2100"))
                            {
                                newItem.DueDate = "";
                            }
                            else
                            {
                                newItem.DueDate = dueDateItem;
                            }
                            itemsAnexo.Add(newItem);
                        }
                        else
                        {
                            existingItem.Quantity++;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al leer los datos desde el archivo: {ex}", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


            return itemsAnexo;
        }

        // Lectura de tabla copiada del portapapeles
        public static List<ItemAnexo>? ReadAnexo(string anexo, Models.Entities.Headers headers, bool movementsBernafon = false, bool groupItems = true)
        {
            List<ItemAnexo> itemAnexos = new List<ItemAnexo>();

            if (string.IsNullOrWhiteSpace(anexo))
            {
                return null;
            }

            try
            {
                string[] rows = anexo.Split('\n'); // Separar por líneas (filas)
                string[] headerRow = rows[0].Split('\t');
                headerRow[headerRow.Length - 1] = headerRow[headerRow.Length - 1].Trim();

                // Para los movimientos de Bernafon solo me interesan columnas Código Artículo y Cantidad
                if (movementsBernafon)
                {
                    if (!headerRow.Any(h => h.Trim().Equals(headers.ArtCode.Name, StringComparison.OrdinalIgnoreCase)) ||
                        !headerRow.Any(h => h.Trim().Equals(headers.Qty.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("El formato de las columnas del anexo no es válido, por favor corroborar desde la configuración que los nombres de las columnas coincidan.", "Nombre de columnas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    headers.ArtCode.Position = Array.FindIndex(
                                                    headerRow,
                                                    h => h.Trim().Equals(headers.ArtCode.Name, StringComparison.OrdinalIgnoreCase)
                                                );
                    headers.Qty.Position = Array.FindIndex(
                                                    headerRow,
                                                    h => h.Trim().Equals(headers.Qty.Name, StringComparison.OrdinalIgnoreCase)
                                                );

                    for (int i = 1; i < rows.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(rows[i])) continue;
                        string[] cells = rows[i].Split('\t'); // Separar por tabuladores (columnas)

                        if (string.IsNullOrEmpty(cells[headers.Qty.Position]) || string.IsNullOrWhiteSpace(cells[headers.Qty.Position]))
                        {
                            continue;
                        }

                        ItemAnexo itemAnexo = new ItemAnexo();
                        itemAnexo.CodItem = cells[headers.ArtCode.Position].Trim();

                        itemAnexo.Quantity = getQuantityValue(cells[headers.Qty.Position]);

                        ItemAnexo? itemExisting = itemAnexos.FirstOrDefault(a => a.CodItem == itemAnexo.CodItem && a.SerialNumber == itemAnexo.SerialNumber && a.DueDate == itemAnexo.DueDate);

                        if (itemExisting == null)
                        {
                            itemAnexos.Add(itemAnexo);
                        }
                        else
                        {
                            itemExisting.Quantity += itemAnexo.Quantity;
                        }


                    }

                }
                else
                {

                    if (!headerRow.Contains(headers.ArtCode.Name) || !headerRow.Contains(headers.Qty.Name) || !headerRow.Contains(headers.Description.Name) || !headerRow.Contains(headers.SerialNr.Name) || !headerRow.Contains(headers.DueDate.Name))
                    {
                        MessageBox.Show("El formato de las columnas del anexo no es válido, por favor corroborar desde la configuración que los nombres de las columnas coincidan.", "Nombre de columnas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    headers.ArtCode.Position = Array.IndexOf(headerRow, headers.ArtCode.Name);
                    headers.Qty.Position = Array.IndexOf(headerRow, headers.Qty.Name);
                    headers.Description.Position = Array.IndexOf(headerRow, headers.Description.Name);
                    headers.SerialNr.Position = Array.IndexOf(headerRow, headers.SerialNr.Name);
                    headers.DueDate.Position = Array.IndexOf(headerRow, headers.DueDate.Name);


                    for (int i = 1; i < rows.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(rows[i])) continue;
                        string[] cells = rows[i].Split('\t'); // Separar por tabuladores (columnas)

                        ItemAnexo itemAnexo = new ItemAnexo();

                        if (headers.ArtCode.Position == headers.Description.Position)
                        {
                            var codSplitted = GetCodeDescriptionSplitted(cells[headers.ArtCode.Position].Trim());
                            itemAnexo.CodItem = codSplitted.codItem;
                            itemAnexo.Description = codSplitted.description;
                        }
                        else
                        {
                            itemAnexo.CodItem = cells[headers.ArtCode.Position].Trim();
                            itemAnexo.Description = cells[headers.Description.Position].Trim();
                        }

                        itemAnexo.Quantity = getQuantityValue(cells[headers.Qty.Position]);

                        string dueDateItem = cells[headers.DueDate.Position].Trim();
                        string dueDateString = "";

                        if (!string.IsNullOrEmpty(dueDateItem) && string.Compare(dueDateItem, "No Aplica") != 0)
                        {
                            object duedateObj = dueDateItem;
                            var dateNormalized = NormalizeTwoDigitYearDate(duedateObj);
                            if (dateNormalized.HasValue)
                                dueDateString = dateNormalized.Value.ToString("dd/MM/yyyy");
                        }

                        itemAnexo.DueDate = dueDateString;

                        // if the serial number contains despacho
                        if (cells[headers.SerialNr.Position].Contains("/"))
                        {
                            itemAnexo.SerialNumber = cells[headers.SerialNr.Position].Split("/")[0].Trim();
                        }
                        else
                        {
                            itemAnexo.SerialNumber = cells[headers.SerialNr.Position].Trim();
                        }

                        ItemAnexo? itemExisting = itemAnexos.FirstOrDefault(a => a.CodItem == itemAnexo.CodItem && a.SerialNumber == itemAnexo.SerialNumber && a.DueDate == itemAnexo.DueDate);

                        if (itemExisting != null && groupItems)
                        {
                            itemExisting.Quantity += itemAnexo.Quantity;
                        }
                        else
                        {
                            itemAnexos.Add(itemAnexo);
                        }


                    }
                }
                return itemAnexos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al leer los datos del portapapeles: {ex}", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region Exportación de Datos

        public static void GenerateQRBernafon(DataGridView data)
        {
            try
            {

                string concatenado = string.Join(";", data.Rows.Cast<DataGridViewRow>()
                                                        .Where(r => !r.IsNewRow && r.Cells["SerialReceivedInventory"].Value != null)
                                                        .Select(r => r.Cells["SerialReceivedInventory"].Value.ToString())
                                                );

                if (string.IsNullOrEmpty(concatenado))
                {
                    MessageBox.Show("No hay números de serie para generar el QR.");
                    return;
                }

                // 2. Generar QR con QRCoder
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(concatenado, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(10); // 10 = tamaño de los píxeles

                string basePath = Application.StartupPath;
                string folder = Path.Combine(basePath, "QRs");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = $"QR_{DateTime.Now:dd-MM-yy-HHmm}.png";
                string filePath = Path.Combine(folder, fileName);

                // Guardar QR en archivo
                qrImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show($"Se creó el QR '{fileName}' correctamente.", "QR Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al generar el Qr.\n\n{ex}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void GenerateQRAB(DataGridView data)
        {
            try
            {

                string concatenado = string.Join(";", data.Rows.Cast<DataGridViewRow>()
                                                        .Where(r => !r.IsNewRow && r.Cells["SerialReceivedInventory"].Value != null)
                                                        .Select(r => r.Cells["SerialReceivedInventory"].Value.ToString())
                                                );

                if (string.IsNullOrEmpty(concatenado))
                {
                    MessageBox.Show("No hay números de serie para generar el QR.");
                    return;
                }

                // 2. Generar QR con QRCoder
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(concatenado, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(10); // 10 = tamaño de los píxeles

                string basePath = Application.StartupPath;
                string folder = Path.Combine(basePath, "QRs");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = $"QR_{DateTime.Now:dd-MM-yy-HHmm}.png";
                string filePath = Path.Combine(folder, fileName);

                // Guardar QR en archivo
                qrImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show($"Se creó el QR '{fileName}' correctamente.", "QR Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al generar el Qr.\n\n{ex}", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        public static void ExportToExcel(List<ItemAnexoReport> itemsReport, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reporte de Inventario");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Código";
                worksheet.Cell(1, 2).Value = "Descripción";
                worksheet.Cell(1, 3).Value = "N° de Serie";
                worksheet.Cell(1, 4).Value = "Vencimiento";
                worksheet.Cell(1, 5).Value = "Cantidad OpenOrange";
                worksheet.Cell(1, 6).Value = "Cantidad Física";
                worksheet.Cell(1, 7).Value = "Diferencia";
                worksheet.Cell(1, 8).Value = "Resultado";

                // Estilo de encabezados (opcional)
                var headerRange = worksheet.Range("A1:H1");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                // Cargar datos
                int row = 2;
                foreach (var item in itemsReport)
                {
                    worksheet.Cell(row, 1).Value = item.CodItem;
                    worksheet.Cell(row, 2).Value = item.Description;
                    worksheet.Cell(row, 3).Value = item.SerialNumber;
                    worksheet.Cell(row, 4).Value = item.DueDate;
                    worksheet.Cell(row, 5).Value = item.Quantity;
                    worksheet.Cell(row, 6).Value = item.QuantityFisical;
                    worksheet.Cell(row, 7).Value = item.QuantityDifference;
                    worksheet.Cell(row, 8).Value = item.QuantityDifference == 0 ? "OK" : "ERROR";
                    row++;
                }

                // Ajustar ancho de columnas
                worksheet.Columns().AdjustToContents();

                // Guardar archivo (diálogo para elegir ubicación)
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Guardar reporte de inventario";
                    saveDialog.FileName = $"ReporteInventario{fileName}.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Archivo exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Exporta un DataGridView pasado por parámetro a un archivo Excel.
        /// </summary>
        /// <param name="dgv">DataGridView a exportar.</param>
        /// <param name="headers">Encabezados a utilizar en caso de que UseOpenOrangeHeaders=True. Deben mantener el mismo orden que las columnas de GridView.</param>
        /// <param name="useOpenOrangeHeaders">Si True entonces se utilizan los encabezados del parámetro 'headers', caso contrario se utilizan los encabezados del GridView.</param>
        /// <param name="pTitle">Título de la hoja de Excel donde se alojará la tabla.</param>
        /// <param name="pFileName">Nombre del archivo a exportar.</param>
        /// <exception cref="Exception"></exception>
        public static void ExportGridToExcel(DataGridView dgv, List<string> headers, bool useOpenOrangeHeaders, string pTitle = "Recibido", string pFileName = "Reporte")
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // 1. Nombre de hoja limpio y título
                    var worksheet = workbook.Worksheets.Add(pTitle.Length > 30 ? pTitle.Substring(0, 30) : pTitle);

                    // 2. Encabezados dinámicos basándonos en columnas visibles solamente
                    int colExcel = 1;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            if (useOpenOrangeHeaders)
                            {
                                worksheet.Cell(1, colExcel).Value = headers[i];
                            }
                            else
                            {
                                worksheet.Cell(1, colExcel).Value = dgv.Columns[i].HeaderText;
                            }
                            colExcel++;
                        }
                    }

                    // 3. Carga de datos optimizada (con manejo de nulos)
                    int rowLine = 2;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        colExcel = 1;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                var cellValue = row.Cells[i].Value;
                                worksheet.Cell(rowLine, colExcel).Value = cellValue?.ToString() ?? "";
                                colExcel++;
                            }
                        }
                        rowLine++;
                    }

                    // --- TOQUES DE DISEÑO PROFESIONAL ---

                    // 4. Convertir el rango en una TABLA de Excel (Permite filtros y ordenamiento automático)
                    var lastColLetter = worksheet.Column(colExcel - 1).ColumnLetter();
                    var range = worksheet.Range($"A1:{lastColLetter}{rowLine - 1}");
                    var table = range.CreateTable();
                    table.Theme = XLTableTheme.TableStyleMedium2; // Un azul sobrio y profesional

                    // 5. Ajustes de estilo fino
                    worksheet.Columns().AdjustToContents(); // Ajuste de ancho
                    worksheet.Rows().Height = 20; // Filas un poco más altas (más aire)

                    // Centrar columnas que suelen ser cortas (como Unidades o Cantidad)
                    worksheet.Columns("A:H").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // 6. Congelar paneles (El encabezado siempre visible al hacer scroll)
                    //worksheet.SheetView.FreezeRows(1);

                    // --- GUARDADO ---
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                        saveDialog.FileName = $"{pFileName}_{DateTime.Now:ddMMyy}.xlsx";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveDialog.FileName);

                            // Opción extra: Preguntar si quiere abrir el archivo al finalizar
                            if (MessageBox.Show("Exportación exitosa. ¿Desea abrir el archivo?", "Excel",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int CountActiveColumns(OpenOrange openOrange)
        {
            if (openOrange == null)
                return 0;

            return openOrange
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(OpenOrangeStructure))
                .Select(p => (OpenOrangeStructure)p.GetValue(openOrange))
                .Count(s => s != null && s.isActive);
        }

        public static void CopyGridViewResult(DataGridView gdv)
        {
            StringBuilder sb = new StringBuilder();

            // Obtener índices de columnas visibles
            List<int> visibleCols = new List<int>();
            for (int i = 0; i < gdv.Columns.Count; i++)
            {

                if (gdv.Columns[i].Visible)
                    visibleCols.Add(i);
            }

            // Encabezados
            for (int c = 0; c < visibleCols.Count; c++)
            {
                sb.Append(gdv.Columns[visibleCols[c]].HeaderText);
                if (c < visibleCols.Count - 1)
                    sb.Append("\t");
            }
            sb.AppendLine();

            // Filas
            foreach (DataGridViewRow row in gdv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int c = 0; c < visibleCols.Count; c++)
                    {
                        int colIndex = visibleCols[c];
                        sb.Append(row.Cells[colIndex].Value?.ToString());

                        if (c < visibleCols.Count - 1)
                            sb.Append("\t");
                    }
                    sb.AppendLine();
                }
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Tabla copiada con éxito.", "Completado");
        }

        #endregion

        #region Get Items From Inputs

        public static ItemAnexo? GetItemFromInput(string pCodeInputUser, eProductLine productLine)
        {

            switch (productLine)
            {
                case eProductLine.AB:
                    break;
                case eProductLine.Atos:
                    return GetItemFromInputAtos(pCodeInputUser);
                case eProductLine.Bernafon:
                    break;
                case eProductLine.Inomed:
                    return GetItemFromInputInomed(pCodeInputUser);
                default:
                    break;
            }

            return null;
        }

        public static ItemAnexo? GetItemFromInput(string pCodeInputUser, string pSerialInputUser, eProductLine productLine)
        {

            switch (productLine)
            {
                case eProductLine.AB:
                    return GetItemFromInputAB(pCodeInputUser, pSerialInputUser);
                case eProductLine.Atos:
                    break;
                case eProductLine.Bernafon:
                    break;
                case eProductLine.Oticom:
                    return GetItemFromInputOticom(pCodeInputUser, pSerialInputUser);
                default:
                    break;
            }

            return null;
        }

        private static ItemAnexo? GetItemFromInputAtos(string pCodeInputUser)
        {
            string code = pCodeInputUser[^4..];
            string serial = pCodeInputUser.Substring(pCodeInputUser.Length - 14, 7);
            string dueDate = code == "7439" ? "" : GetDueDate(pCodeInputUser);

            ItemAnexo newItem = new ItemAnexo()
            {
                CodItem = code,
                SerialNumber = serial,
                Quantity = 1,
                DueDate = dueDate
            };

            return newItem;

            //return (code, serial);
        }

        private static ItemAnexo? GetItemFromInputInomed(string inputUser)
        {
            ItemAnexo newItem = new ItemAnexo();
            // 01142503076038452405326251024D029D172904043010

            var regex = new Regex(
            @"01\d{14}240(?<codigo>\d{6})17(?<vto>\d{6})10(?<serie>[A-Za-z0-9]+?)30(?<uxc>\d{1,2})",
            RegexOptions.Compiled);

            var match = regex.Match(inputUser);
            if (!match.Success)
                return null;

            var codigo = match.Groups["codigo"].Value;
            var serie = match.Groups["serie"].Value;
            var fechaStr = match.Groups["vto"].Value;
            var unidadesStr = match.Groups["uxc"].Value;

            // Fecha formato yyMMdd → convertir a DateTime
            var año = 2000 + int.Parse(fechaStr.Substring(0, 2));
            var mes = int.Parse(fechaStr.Substring(2, 2));
            var dia = int.Parse(fechaStr.Substring(4, 2));
            var fecha = new DateTime(año, mes, dia);

            var unidades = int.Parse(unidadesStr);

            newItem.CodItem = codigo;
            newItem.SerialNumber = serie;
            newItem.DueDate = fecha.ToString("dd/MM/yyyy");
            newItem.Quantity = unidades;

            //return new ItemAnexo
            //{
            //    CodigoProducto = codigo,
            //    NumeroSerie = serie,
            //    FechaVencimiento = fecha,
            //    UnidadesPorCaja = unidades
            //};


            return newItem;
        }

        private static ItemAnexo? GetItemFromInputOticom(string pCodeInput, string pSerialInput)
        {
            try
            {
                Match matchCode = GetMatchRegex(pCodeInput, "^0000(?<codeItem>\\d{6})");

                string codeInput = "";
                string serialInput = "";
                string dueDateInput = "";

                if (matchCode.Success)
                {
                    codeInput = matchCode.Groups["codeItem"].Value;
                    serialInput = pSerialInput;

                    if (serialInput.StartsWith("21"))
                        serialInput = serialInput.Substring(2);
                }
                else
                {
                    matchCode = GetMatchRegex(pCodeInput, "^01\\d{14}10.{8}11\\d{6}17(?<date>\\d{6}).*240(?<codeItem>\\d{6})$");

                    Match matchSerial = GetMatchRegex(pSerialInput, "0000(?<serialItem>\\d{4})");

                    if (matchCode.Success && matchSerial.Success)
                    {
                        codeInput = matchCode.Groups["codeItem"].Value;
                        dueDateInput = ConvertDate(matchCode.Groups["date"].Value);
                        serialInput = matchSerial.Groups["serialItem"].Value;
                    }
                }

                if (!string.IsNullOrEmpty(codeInput) && !string.IsNullOrEmpty(serialInput))
                {

                    //ItemAnexo? itemInput = Functions.GetItemFromInput(codeInput, eProductLine.Oticom);

                    ItemAnexo itemInput = new ItemAnexo();
                    itemInput.CodItem = codeInput;
                    itemInput.SerialNumber = serialInput;
                    itemInput.Quantity = 1;
                    itemInput.DueDate = dueDateInput;

                    //AddNewItem(itemInput);

                    //TxtPickCodeReceived.Focus();
                    //TxtPickCodeReceived.Clear();
                    //TxtPickSerialNumReceived.Clear();

                    return itemInput;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener la información del producto.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private static ItemAnexo? GetItemFromInputAB(string pCodeInputUser, string pSerialInputUser)
        {
            string codeNewItem = pCodeInputUser.Replace("'", "-");

            string dueDateNewItem = "";
            if (pSerialInputUser.Length > 15)
            {
                var implantData = getImplantDate(pSerialInputUser);
                pSerialInputUser = implantData.serie;
                dueDateNewItem = implantData.dueDate;
            }

            ItemAnexo newItem = new ItemAnexo()
            {
                CodItem = codeNewItem.ToUpper(),
                SerialNumber = pSerialInputUser.ToUpper(),
                Quantity = 1,
                DueDate = dueDateNewItem
            };

            return newItem;

        }

        #endregion

        #region Manipulación de Datos

        /// Normalizes dates in dd/MM/yy format.
        /// Years >= 30 are adjusted to the next century according to business rules.
        private static DateOnly? NormalizeTwoDigitYearDate(object dueDate)
        {
            if (dueDate == null)
                return null;

            DateTime dt;

            if (dueDate is DateTime dateTime)
            {
                dt = dateTime;
            }
            // Si viene como número OADate (Excel)
            else if (double.TryParse(dueDate.ToString(), out double oa))
            {
                dt = DateTime.FromOADate(oa);
            }
            // String (ej: "5/27/2029", "17/11/30", etc.)
            else if (dueDate is string s)
            {
                string[] formats =
                {
                    "dd/M/yyyy",
                    "dd/MM/yyyy",
                    "dd/M/yy",
                    "MM/dd/yyyy",
                    "M/dd/yyyy",
                    "MM/dd/yy",
                    "dd/MM/yy"
                };

                if (!DateTime.TryParseExact(
                        s,
                        formats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out dt
                    ))
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            // Regla de negocio: vencimientos siempre futuros
            if (dt.Year < DateTime.Today.Year)
            {
                dt = dt.AddYears(100);
            }

            return DateOnly.FromDateTime(dt);

        }

        private static (string codItem, string description) GetCodeDescriptionSplitted(string codItemStr)
        {
            string codItem = string.Empty;
            string description = string.Empty;

            // Si se está leyendo Anexo de Accesorios de AB el código y descripción viene de la siguiente forma:
            // CI-5293-130 Naida TM CI M90 Procesador de Sonido marron
            if (!string.IsNullOrWhiteSpace(codItemStr))
            {
                int firstSpaceIndex = codItemStr.IndexOf(' ');

                if (firstSpaceIndex > 0)
                {
                    codItem = codItemStr.Substring(0, firstSpaceIndex);
                    description = codItemStr.Substring(firstSpaceIndex + 1).Trim(' ', '-');
                }
                else
                {
                    // Caso defensivo: no hay descripción
                    codItem = codItemStr;
                    description = string.Empty;
                }
            }

            return (codItem, description);
        }

        private static int getQuantityValue(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;
            if (string.IsNullOrWhiteSpace(number)) return 0;

            decimal resultDecimal = 0;
            int resultInt = 0;

            if (decimal.TryParse(number.Trim(), NumberStyles.Any, new CultureInfo("es-ES"), out resultDecimal))
            {
                resultInt = (int)resultDecimal;
            }

            return resultInt;
        }

        public static string GetDueDate(string input)
        {
            string dateSegment = input.Substring(input.Length - 24, 10);
            string datePart = dateSegment.Substring(2, 6); // yyMMdd

            DateTime dueDate = DateTime.ParseExact(datePart, "yyMMdd", CultureInfo.InvariantCulture);

            return dueDate.ToString("dd/MM/yyyy");
        }

        private static Match GetMatchRegex(string pInput, string pRegex)
        {
            Regex regex = new Regex(@$"{pRegex}");

            Match match = regex.Match(pInput);

            return match;
        }

        public static (string serie, string dueDate) getImplantDate(string dateValue)
        {
            // Obtiene la serie (últimos 7 caracteres)
            string serie = dateValue.Substring(dateValue.Length - 7);

            // Obtiene los caracteres desde -15 a -9 (6 caracteres) y los convierte en fecha
            string rawDate = dateValue.Substring(dateValue.Length - 15, 6);
            string dueDate = ConvertDate(rawDate);

            return (serie, dueDate);
        }

        private static string ConvertDate(string date, string dateFormat = "yyMMdd")
        {
            if (string.IsNullOrWhiteSpace(date))
                return string.Empty;

            if (DateTime.TryParseExact(
                date,
                dateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate))
            {
                return parsedDate.ToString("dd/MM/yyyy");
            }

            return string.Empty;
        }

        public static string DecompressString(string compressedText)
        {
            // 1. Convertir de Base64 a bytes
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);

            using (var ms = new MemoryStream(gZipBuffer))
            {
                using (var zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(zip, Encoding.UTF8))
                    {
                        // 2. Leer el flujo descomprimido hasta el final
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Agrega el número de fila a cada Row del DataGridView.
        /// </summary>
        /// <param name="dgv">DataGridView sobre el cual se genera la numeración de filas.</param>
        public static void GenerateNumericalRows(DataGridView dgv)
        {
            int finalRow = dgv.Rows.Count;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Si AllowUserToAddRows es True entonces el gridView por defecto tiene una fila extra que no considero.
                if (row.Index == finalRow - 1 && dgv.AllowUserToAddRows)
                    break;

                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        /// <summary>
        /// Genera la numeración de filas del dataGridView pasado como parámetro. No tiene en cuenta la fila por defecto.
        /// </summary>
        /// <param name="sender">Sender del evento.</param>
        /// <param name="e">Objeto 'e' del evento.</param>
        public static void EnumerarFilasDataGrid(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null) return;

            // VALIDACIÓN: Si es la última fila (la de asterisco para agregar) y AllowUserToAddRows está activo, no pintar número
            if (grid.AllowUserToAddRows && e.RowIndex == grid.Rows.Count - 1)
                return;

            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Usamos el ForeColor del RowHeadersDefaultCellStyle para que combine con el diseño moderno
            Brush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor);

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, grid.Font, brush, headerBounds, centerFormat);
        }

        /// <summary>
        /// Carga los items anexo al gridView de Resultado.
        /// </summary>
        /// <param name="dgv">DataGridView de la pestaña de Resultado.</param>
        /// <param name="_items">Listado de items anexo a cargar en el gridView.</param>
        /// <param name="serialNumProcessor">Número de serie del procesador en caso de que sea necesario.</param>
        public static void GenerateResultOpenOrangeGrid(DataGridView dgv, List<ItemAnexo> _items, string serialNumProcessor = "")
        {
            foreach (var item in _items)
            {
                if (item == null)
                {
                    continue;
                }

                string expireDate = item.DueDate == "" ? "" : item.DueDate;
                string batchStatus = item.DueDate == "" ? "" : "APRO";
                string kitPrefij = item.IsAquaKit ? "AKIT" : "KIT";
                string kitNumber = serialNumProcessor != "" ? string.Concat(kitPrefij, "-", serialNumProcessor) : kitPrefij;
                string articlePrice = AppSettings.settings.ArticlePrice;

                dgv.Rows.Add(item.CodItem, item.Quantity, item.SerialNumber, expireDate, articlePrice, batchStatus, kitNumber);
            }
        }


    }

    public enum eArticle
    {
        oldArticle = 1,
        newArticle = 2
    }

    public enum eProductLine
    {
        AB = 1,
        Atos,
        Bernafon,
        Inomed,
        Oticom
    }
}
