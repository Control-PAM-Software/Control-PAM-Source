using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using Control.Logic;
using Control.Models.Entities;
using Xunit;

namespace Control.Tests.Logic
{
    public class ConsignacionExportersTests
    {
        private static ItemConsignacion Item(string serial, string code, string depto, ConsignacionEstado estado, int dias, bool entregado = false, bool sinMovimiento = false)
        {
            return new ItemConsignacion
            {
                Serial = serial,
                Code = code,
                CurrentDepot = depto,
                DepartureDate = "04/03/2026",
                DaysElapsed = dias,
                Delivered = entregado,
                SerieSinMovimiento = sinMovimiento,
                State = estado
            };
        }

        private static List<ItemConsignacion> TresItems()
        {
            return new List<ItemConsignacion>
            {
                Item("AAA100", "240319", "200", ConsignacionEstado.EnPlazo, 12),
                Item("AAA101", "240320", "210", ConsignacionEstado.Vencida, 90),
                Item("BBB200", "240321", "", ConsignacionEstado.Entregado, 100, entregado: true)
            };
        }

        // ------------------------------------------------------------------ Excel

        [Fact]
        public void Excel_ExportaHeadersDatosYColores()
        {
            string ruta = Path.Combine(Path.GetTempPath(), $"bern_excel_{Guid.NewGuid():N}.xlsx");
            try
            {
                ConsignacionExcelExporter.Exportar(TresItems(), ruta, new DateTime(2026, 10, 12));

                using var wb = new XLWorkbook(ruta);
                var ws = wb.Worksheet("Bernafon");

                Assert.Equal("Control de Consignaciones - Bernafon", ws.Cell(1, 1).Value.ToString());
                Assert.Contains("Series: 3", ws.Cell(2, 1).Value.ToString());

                string[] esperados = { "Serie", "Código", "Depósito Actual", "Fecha Salida", "Días Transcurridos", "Entregado", "Estado" };
                for (int c = 0; c < esperados.Length; c++)
                {
                    Assert.Equal(esperados[c], ws.Cell(4, c + 1).Value.ToString());
                }

                Assert.Equal("AAA100", ws.Cell(5, 1).Value.ToString());
                Assert.Equal("240319", ws.Cell(5, 2).Value.ToString());
                Assert.Equal("200", ws.Cell(5, 3).Value.ToString());
                Assert.Equal("04/03/2026", ws.Cell(5, 4).Value.ToString());
                Assert.Equal(12, ws.Cell(5, 5).GetValue<int>());
                Assert.Equal("No", ws.Cell(5, 6).Value.ToString());
                Assert.Equal("Consignación en Plazo", ws.Cell(5, 7).Value.ToString());

                Assert.Equal(3, ws.LastRowUsed()?.RowNumber() - 4);

                // Colores de estado
                Assert.Equal(System.Drawing.ColorTranslator.FromHtml("#FFF3CD").ToArgb(), ws.Cell(5, 7).Style.Fill.BackgroundColor.Color.ToArgb());
                Assert.Equal(System.Drawing.ColorTranslator.FromHtml("#F8D7DA").ToArgb(), ws.Cell(6, 7).Style.Fill.BackgroundColor.Color.ToArgb());
                Assert.Equal(System.Drawing.ColorTranslator.FromHtml("#D4EDD8").ToArgb(), ws.Cell(7, 7).Style.Fill.BackgroundColor.Color.ToArgb());
            }
            finally
            {
                File.Delete(ruta);
            }
        }

        [Fact]
        public void Excel_ReflejaSerieSinMovimientoYEntregado()
        {
            string ruta = Path.Combine(Path.GetTempPath(), $"bern_excel_{Guid.NewGuid():N}.xlsx");
            try
            {
                var items = new List<ItemConsignacion>
                {
                    Item("ZZZ999", "241111", "200", ConsignacionEstado.Vencida, 5, sinMovimiento: true),
                    Item("ZZZ888", "242222", "", ConsignacionEstado.Entregado, 8, entregado: true)
                };
                ConsignacionExcelExporter.Exportar(items, ruta, DateTime.Today);

                using var wb = new XLWorkbook(ruta);
                var ws = wb.Worksheet("Bernafon");

                Assert.Equal(System.Drawing.ColorTranslator.FromHtml("#FFF9E6").ToArgb(), ws.Cell(5, 7).Style.Fill.BackgroundColor.Color.ToArgb());
                Assert.Equal("Sí", ws.Cell(6, 6).Value.ToString());
            }
            finally
            {
                File.Delete(ruta);
            }
        }

        [Fact]
        public void Excel_LanzaSiNoHayItems()
        {
            Assert.Throws<ArgumentException>(() =>
                ConsignacionExcelExporter.Exportar(new List<ItemConsignacion>(), "x.xlsx", DateTime.Today));
        }

        // ------------------------------------------------------------------ PDF

        [Fact]
        public void Pdf_GeneraEstructuraValidaCon1Pagina()
        {
            string ruta = Path.Combine(Path.GetTempPath(), $"bern_pdf_{Guid.NewGuid():N}.pdf");
            try
            {
                ConsignacionPdfExporter.Exportar(TresItems(), ruta, new DateTime(2026, 10, 12));

                byte[] pdf = File.ReadAllBytes(ruta);
                Assert.True(pdf.Length > 500);
                Assert.Equal("%PDF-1.4", Encoding.ASCII.GetString(pdf, 0, 8));

                var (size, offsets) = ParseXref(pdf);
                Assert.Equal(size, offsets.Length);

                for (int i = 1; i < offsets.Length; i++)
                {
                    string linea = Encoding.ASCII.GetString(pdf, (int)offsets[i], 20);
                    Assert.StartsWith($"{i} 0 obj", linea);
                }

                // La cabecera del documento y el texto de una fila viajan en el stream (Latin-1)
                string latin1 = Encoding.GetEncoding(1252).GetString(pdf);
                Assert.Contains("Control de Consignaciones - Bernafon", latin1);
                Assert.Contains("Consignación Vencida", latin1);

                // Una página con 3 filas
                Assert.Equal(1, CantidadPaginas(pdf));
            }
            finally
            {
                File.Delete(ruta);
            }
        }

        [Fact]
        public void Pdf_PaginaSegunCantidadDeFilas()
        {
            string ruta = Path.Combine(Path.GetTempPath(), $"bern_pdf_{Guid.NewGuid():N}.pdf");
            try
            {
                var items = new List<ItemConsignacion>();
                for (int i = 0; i < 300; i++)
                {
                    items.Add(Item($"SER{i:D6}", "240319", "200", ConsignacionEstado.EnPlazo, 10));
                }

                ConsignacionPdfExporter.Exportar(items, ruta, DateTime.Today);

                byte[] pdf = File.ReadAllBytes(ruta);
                // Primera página: 25 filas; siguientes: 27 por página.
                int esperadas = 1 + (int)Math.Ceiling((300 - 25) / 27.0);
                Assert.Equal(esperadas, CantidadPaginas(pdf));
            }
            finally
            {
                File.Delete(ruta);
            }
        }

        [Fact]
        public void Pdf_LanzaSiNoHayItems()
        {
            Assert.Throws<ArgumentException>(() =>
                ConsignacionPdfExporter.Exportar(new List<ItemConsignacion>(), "x.pdf", DateTime.Today));
        }

        // ------------------------------------------------------------------ helpers

        private static int CantidadPaginas(byte[] pdf)
        {
            string text = Encoding.ASCII.GetString(pdf);
            int idx = text.IndexOf("/Count ", StringComparison.Ordinal);
            Assert.True(idx > 0);
            int start = idx + "/Count ".Length;
            int end = text.IndexOf(" >>", start);
            return int.Parse(text.Substring(start, end - start).Trim());
        }

        private static (int size, long[] offsets) ParseXref(byte[] pdf)
        {
            string text = Encoding.ASCII.GetString(pdf);
            int idxStartXref = text.IndexOf("startxref", StringComparison.Ordinal);
            Assert.True(idxStartXref > 0);
            int numStart = idxStartXref + "startxref".Length;
            while (numStart < text.Length && (text[numStart] < '0' || text[numStart] > '9')) numStart++;
            int numEnd = numStart;
            while (numEnd < text.Length && char.IsDigit(text[numEnd])) numEnd++;
            long posXref = long.Parse(text.Substring(numStart, numEnd - numStart));

            int posObj = (int)posXref;
            Assert.Equal("xref", Encoding.ASCII.GetString(pdf, posObj, 4));

            // "xref\n0 12\n" -> first entry offset
            int cursor = posObj + 4;
            while (text[cursor] == '\r' || text[cursor] == '\n') cursor++;
            int begin = cursor;
            while (text[cursor] is not '\r' and not '\n') cursor++;
            string[] parts = text.Substring(begin, cursor - begin).Trim().Split(' ');
            int size = int.Parse(parts[1]);

            while (text[cursor] == '\r' || text[cursor] == '\n') cursor++;
            var offsets = new long[size];
            string entryPattern = new string(text.Skip(cursor).Take(19).ToArray());
            for (int i = 0; i < size; i++)
            {
                string line = new string(text.Skip(cursor + i * 20).Take(19).ToArray());
                offsets[i] = long.Parse(line.Substring(0, 10));
            }

            Assert.StartsWith("0000000000 65535 f", entryPattern);
            return (size, offsets);
        }
    }
}