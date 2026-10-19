using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Control.Models.Entities;

namespace Control.Logic
{
    /// <summary>
    /// Genera un PDF válido (PDF 1.4) sin librerías externas, renderizando la tabla del reporte
    /// de consignaciones con paginado, repetido de encabezados, colores de estado y numeración.
    /// Páginas A4 horizontales con tipografías base Helvetica (WinAnsi).
    /// </summary>
    public static class ConsignacionPdfExporter
    {
        private const int PageW = 842;
        private const int PageH = 595;
        private const int Margen = 45;
        private const float AnchoUtil = PageW - (2 * Margen); // 752
        private const float AltoFila = 18F;
        private const float AltoFilaCabecera = 22F;
        private const float AltoZonaPie = 35F;
        private const float PaddingCelda = 4.5F;

        private struct Columna
        {
            public string Titulo;
            public int Peso;
            public char Alineacion; // 'I' izquierda, 'C' centro, 'D' derecha
        }

        private static readonly Columna[] Columnas =
        {
            new Columna { Titulo = "Serie", Peso = 130, Alineacion = 'I' },
            new Columna { Titulo = "Código", Peso = 95, Alineacion = 'I' },
            new Columna { Titulo = "Depósito Actual", Peso = 85, Alineacion = 'I' },
            new Columna { Titulo = "Fecha Salida", Peso = 92, Alineacion = 'I' },
            new Columna { Titulo = "Días", Peso = 65, Alineacion = 'D' },
            new Columna { Titulo = "Entregado", Peso = 80, Alineacion = 'C' },
            new Columna { Titulo = "Estado", Peso = 195, Alineacion = 'I' }
        };

        public static void Exportar(IReadOnlyList<ItemConsignacion> items, string rutaDestino, DateTime fechaCorte)
        {
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("No hay ítems para exportar.", nameof(items));
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            float[] anchos = CalcularAnchos();
            var paginas = ComponerPaginas(items, fechaCorte, anchos);

            byte[] pdf = EnsamblarPdf(paginas);
            File.WriteAllBytes(rutaDestino, pdf);
        }

        // ------------------------------------------------------------------ composición de páginas

        private static List<byte[]> ComponerPaginas(IReadOnlyList<ItemConsignacion> items, DateTime fechaCorte, float[] anchos)
        {
            var paginas = new List<byte[]>();
            int filaActual = 0;
            bool primera = true;

            while (filaActual < items.Count)
            {
                var pag = new List<byte>();

                if (primera)
                {
                    DibujarEncabezadoDocumento(pag, items.Count, fechaCorte);
                    float y = 86F;
                    DibujarCabeceraTabla(pag, y, anchos);
                    y += AltoFilaCabecera;
                    filaActual = DibujarFilas(pag, items, filaActual, y, anchos);
                    primera = false;
                }
                else
                {
                    float y = Margen;
                    DibujarCabeceraTabla(pag, y, anchos);
                    y += AltoFilaCabecera;
                    filaActual = DibujarFilas(pag, items, filaActual, y, anchos);
                }

                paginas.Add(pag.ToArray());
            }

            for (int i = 0; i < paginas.Count; i++)
            {
                paginas[i] = ConPieDePagina(paginas[i], i + 1, paginas.Count);
            }

            return paginas;
        }

        private static int DibujarFilas(List<byte> pag, IReadOnlyList<ItemConsignacion> items, int desde, float yInicio, float[] anchos)
        {
            float limite = PageH - AltoZonaPie;
            float y = yInicio;

            for (int i = desde; i < items.Count; i++)
            {
                if (y + AltoFila > limite)
                {
                    return i;
                }

                var item = items[i];
                var fill = item.SerieSinMovimiento
                    ? Colores.SinMovimiento
                    : ColoresFila(item.State);

                float x = Margen;
                for (int c = 0; c < Columnas.Length; c++)
                {
                    string texto = TextoFila(item, c);
                    DibujarRectFondo(pag, x, y, anchos[c], AltoFila, fill);
                    DibujarTexto(pag, false, 9F, x, y, Columnas[c].Alineacion, anchos[c], Colores.TextoFila, texto);
                    x += anchos[c];
                }

                y += AltoFila;
            }

            return items.Count;
        }

        private static string TextoFila(ItemConsignacion item, int col)
        {
            return col switch
            {
                0 => item.Serial,
                1 => item.Code,
                2 => item.CurrentDepot,
                3 => item.DepartureDate,
                4 => item.DaysElapsed.ToString(CultureInfo.InvariantCulture),
                5 => item.Delivered ? "Sí" : "No",
                _ => ConsignacionesLogic.EstadoTexto(item.State)
            };
        }

        private static void DibujarCabeceraTabla(List<byte> pag, float y, float[] anchos)
        {
            DibujarRectFondo(pag, Margen, y, AnchoUtil, AltoFilaCabecera, Colores.CabeceraFondo);

            float x = Margen;
            for (int c = 0; c < Columnas.Length; c++)
            {
                DibujarTexto(pag, true, 9F, x, y, Columnas[c].Alineacion, anchos[c], Colores.CabeceraTexto, Columnas[c].Titulo);
                x += anchos[c];
            }
        }

        private static void DibujarEncabezadoDocumento(List<byte> pag, int cantidadSeries, DateTime fechaCorte)
        {
            string titulo = "Control de Consignaciones - Bernafon";
            string subtitulo = $"Fecha de corte: {fechaCorte:dd/MM/yyyy}  |  Series: {cantidadSeries}";

            DibujarTexto(pag, true, 16F, Margen, 40F, 'I', 0F, Colores.Titulo, titulo);
            DibujarTexto(pag, false, 9.5F, Margen, 62F, 'I', 0F, Colores.Subtitulo, subtitulo);
        }

        private static byte[] ConPieDePagina(byte[] contenido, int numeroPagina, int totalPaginas)
        {
            var pag = new List<byte>(contenido);

            string generado = $"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}";
            string paginado = $"Página {numeroPagina} de {totalPaginas}";

            DibujarTexto(pag, false, 8.5F, Margen, PageH - 32F, 'I', 0F, Colores.Pie, generado);

            float anchoPaginado = MedirTexto(paginado, 8.5F);
            DibujarTexto(pag, false, 8.5F, Margen + AnchoUtil - anchoPaginado, PageH - 32F, 'I', 0F, Colores.Pie, paginado);

            return pag.ToArray();
        }

        // ------------------------------------------------------------------ primitivas de dibujo

        private static void DibujarTexto(List<byte> pag, bool negrita, float size, float xCol, float yTop, char alineacion, float anchoCol, (float R, float G, float B) color, string texto)
        {
            float textWidth = MedirTexto(texto, size);
            float x = xCol + PaddingCelda;

            if (alineacion == 'D')
            {
                x = xCol + anchoCol - PaddingCelda - textWidth;
            }
            else if (alineacion == 'C')
            {
                x = xCol + (anchoCol - textWidth) / 2F;
            }

            string font = negrita ? "F1" : "F2";
            byte[] bytes = ToLatin1(texto);
            float baseline = PageH - yTop - (size * 0.736F);

            Escribir(pag, $"BT /{font} {Size(size)} Tf {C(color.R)} {C(color.G)} {C(color.B)} rg ");
            Escribir(pag, $"{Size(x)} {Size(baseline)} Td (");
            EmitirEscape(pag, bytes);
            Escribir(pag, ") Tj ET\n");
        }

        private static void DibujarRectFondo(List<byte> pag, float x, float y, float ancho, float alto, (float R, float G, float B) fill)
        {
            float pdfY = PageH - y - alto;
            Escribir(pag, $"{C(fill.R)} {C(fill.G)} {C(fill.B)} rg {Size(x)} {Size(pdfY)} {Size(ancho)} {Size(alto)} re f\n");
        }

        // ------------------------------------------------------------------ colores

        private static class Colores
        {
            public static readonly (float R, float G, float B) Titulo = (39F / 255F, 39F / 255F, 58F / 255F);
            public static readonly (float R, float G, float B) Subtitulo = (107F / 255F, 107F / 255F, 118F / 255F);
            public static readonly (float R, float G, float B) CabeceraFondo = (45F / 255F, 45F / 255F, 48F / 255F);
            public static readonly (float R, float G, float B) CabeceraTexto = (1F, 1F, 1F);
            public static readonly (float R, float G, float B) TextoFila = (64F / 255F, 64F / 255F, 64F / 255F);
            public static readonly (float R, float G, float B) Pie = (120F / 255F, 120F / 255F, 130F / 255F);
            public static readonly (float R, float G, float B) SinMovimiento = (255F / 255F, 249F / 255F, 230F / 255F);
        }

        private static (float R, float G, float B) ColoresFila(ConsignacionEstado estado)
        {
            return estado switch
            {
                ConsignacionEstado.EnPlazo => (255F / 255F, 243F / 255F, 205F / 255F),
                ConsignacionEstado.Entregado => (212F / 255F, 237F / 255F, 216F / 255F),
                _ => (248F / 255F, 215F / 255F, 218F / 255F)
            };
        }

        // ------------------------------------------------------------------ medición y utilerías

        private static float[] CalcularAnchos()
        {
            int totalPeso = Columnas.Sum(c => c.Peso);
            var anchos = new float[Columnas.Length];
            float acumulado = 0F;
            for (int i = 0; i < Columnas.Length; i++)
            {
                float ancho = Columnas[i].Peso * AnchoUtil / totalPeso;
                if (i < Columnas.Length - 1)
                {
                    anchos[i] = (float)Math.Round(ancho, 1);
                    acumulado += anchos[i];
                }
                else
                {
                    anchos[i] = AnchoUtil - acumulado;
                }
            }
            return anchos;
        }

        private static float MedirTexto(string texto, float size)
        {
            float ancho = 0F;
            foreach (char ch in texto)
            {
                ancho += char.IsDigit(ch) ? 0.556F : 0.5F;
            }
            return ancho * size;
        }

        // ------------------------------------------------------------------ ensamblado PDF

        private static byte[] EnsamblarPdf(List<byte[]> paginas)
        {
            int paginasCount = paginas.Count;
            int objFontBold = 3 + paginasCount;      // F1 Helvetica-Bold
            int objFontRegular = objFontBold + 1;    // F2 Helvetica
            int objContenidoBase = objFontRegular + 1;
            int totalObjetos = objContenidoBase + paginasCount - 1; // 4 + 2*P

            var buffer = new List<byte>();
            var offsets = new long[totalObjetos + 1];

            long Off() => buffer.Count;

            Escribir(buffer, "%PDF-1.4\n");

            // catálogo
            offsets[1] = Off();
            Escribir(buffer, "1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");

            // nodo de páginas
            offsets[2] = Off();
            Escribir(buffer, "2 0 obj\n<< /Type /Pages /Kids [");
            for (int i = 0; i < paginasCount; i++)
            {
                Escribir(buffer, $" {3 + i} 0 R");
            }
            Escribir(buffer, $" ] /Count {paginasCount} >>\nendobj\n");

            // objetos de página
            for (int i = 0; i < paginasCount; i++)
            {
                offsets[3 + i] = Off();
                Escribir(buffer,
                    $"{3 + i} 0 obj\n" +
                    $"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {PageW} {PageH}] " +
                    $"/Resources << /Font << /F1 {objFontBold} 0 R /F2 {objFontRegular} 0 R >> >> " +
                    $"/Contents {objContenidoBase + i} 0 R >>\nendobj\n");
            }

            // fuentes
            offsets[objFontBold] = Off();
            Escribir(buffer, $"{objFontBold} 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>\nendobj\n");
            offsets[objFontRegular] = Off();
            Escribir(buffer, $"{objFontRegular} 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>\nendobj\n");

            // streams de contenido
            for (int i = 0; i < paginasCount; i++)
            {
                byte[] contenido = paginas[i];
                offsets[objContenidoBase + i] = Off();
                Escribir(buffer, $"{objContenidoBase + i} 0 obj\n<< /Length {contenido.Length} >>\nstream\n");
                buffer.AddRange(contenido);
                Escribir(buffer, "\nendstream\nendobj\n");
            }

            // tabla xref
            long posXref = Off();
            Escribir(buffer, $"xref\n0 {totalObjetos + 1}\n");
            Escribir(buffer, "0000000000 65535 f \n");
            for (int i = 1; i <= totalObjetos; i++)
            {
                Escribir(buffer, $"{offsets[i]:D10} 00000 n \n");
            }

            Escribir(buffer, $"trailer\n<< /Size {totalObjetos + 1} /Root 1 0 R >>\nstartxref\n{posXref}\n%%EOF\n");

            return buffer.ToArray();
        }

        // ------------------------------------------------------------------ utilerías de bytes

        private static string Size(float valor)
        {
            return valor.ToString("0.##", CultureInfo.InvariantCulture);
        }

        private static string C(float valor)
        {
            return valor.ToString("0.###", CultureInfo.InvariantCulture);
        }

        private static void Escribir(List<byte> destino, string texto)
        {
            destino.AddRange(Encoding.ASCII.GetBytes(texto));
        }

        private static void EmitirEscape(List<byte> destino, byte[] texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                byte b = texto[i];
                if (b == 0x28 || b == 0x29 || b == 0x5C) // ( ) \
                {
                    destino.Add(0x5C);
                }
                destino.Add(b);
            }
        }

        private static byte[] ToLatin1(string texto)
        {
            var enc = Encoding.GetEncoding(1252, EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback);
            return enc.GetBytes(texto);
        }
    }
}