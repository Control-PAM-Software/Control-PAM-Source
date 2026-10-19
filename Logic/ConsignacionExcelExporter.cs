using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using Control.Models.Entities;

namespace Control.Logic
{
    public static class ConsignacionExcelExporter
    {
        private static readonly string[] Encabezados = new[]
        {
            "Serie", "Código", "Depósito Actual", "Fecha Salida",
            "Días Transcurridos", "Entregado", "Estado"
        };

        private static readonly string HexCeldaPlazo = "#FFF3CD";
        private static readonly string HexCeldaVencida = "#F8D7DA";
        private static readonly string HexCeldaEntregado = "#D4EDD8";
        private static readonly string HexCeldaSinMovimiento = "#FFF9E6";

        public static void Exportar(IReadOnlyList<ItemConsignacion> items, string rutaDestino, DateTime fechaCorte)
        {
            if (items == null || items.Count == 0)
            {
                throw new ArgumentException("No hay ítems para exportar.", nameof(items));
            }

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Bernafon");

                ws.Style.Font.FontName = "Segoe UI";
                ws.Style.Font.FontSize = 10;

                const int titleRow = 1;
                const int subtitleRow = 2;
                const int headerRow = 4;
                int firstDataRow = headerRow + 1;
                int lastDataRow = firstDataRow + items.Count - 1;

                // Título y subtítulo
                ws.Range(titleRow, 1, titleRow, Encabezados.Length).Merge();
                ws.Cell(titleRow, 1).Value = "Control de Consignaciones - Bernafon";
                ws.Cell(titleRow, 1).Style.Font.Bold = true;
                ws.Cell(titleRow, 1).Style.Font.FontSize = 14;
                ws.Cell(titleRow, 1).Style.Font.FontColor = XLColor.FromArgb(39, 39, 58);
                ws.Row(titleRow).Height = 28;

                ws.Range(subtitleRow, 1, subtitleRow, Encabezados.Length).Merge();
                ws.Cell(subtitleRow, 1).Value = $"Fecha de corte: {fechaCorte:dd/MM/yyyy}  |  Series: {items.Count}";
                ws.Cell(subtitleRow, 1).Style.Font.FontSize = 10;
                ws.Cell(subtitleRow, 1).Style.Font.FontColor = XLColor.FromArgb(107, 107, 118);
                ws.Row(subtitleRow).Height = 20;

                // Encabezados de columna
                for (int c = 1; c <= Encabezados.Length; c++)
                {
                    var cell = ws.Cell(headerRow, c);
                    cell.Value = Encabezados[c - 1];
                    cell.Style.Font.Bold = true;
                    cell.Style.Font.FontColor = XLColor.White;
                    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(45, 45, 48);
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                }
                ws.Row(headerRow).Height = 26;

                // Datos
                int r = firstDataRow;
                foreach (var item in items)
                {
                    ws.Cell(r, 1).Value = item.Serial;
                    ws.Cell(r, 2).Value = item.Code;
                    ws.Cell(r, 3).Value = item.CurrentDepot;
                    ws.Cell(r, 4).Value = item.DepartureDate;
                    ws.Cell(r, 5).Value = item.DaysElapsed;
                    ws.Cell(r, 6).Value = item.Delivered ? "Sí" : "No";
                    ws.Cell(r, 7).Value = ConsignacionesLogic.EstadoTexto(item.State);

                    ws.Cell(r, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell(r, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    string hex = HexEstado(item);
                    ws.Range(r, 1, r, Encabezados.Length).Style.Fill.BackgroundColor = XLColor.FromHtml(hex);
                    ws.Range(r, 1, r, Encabezados.Length).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    r++;
                }

                var rangoDatos = ws.Range(headerRow, 1, lastDataRow, Encabezados.Length);
                rangoDatos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                rangoDatos.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                rangoDatos.Style.Border.OutsideBorderColor = XLColor.FromArgb(217, 221, 227);
                rangoDatos.Style.Border.InsideBorderColor = XLColor.FromArgb(217, 221, 227);

                // Filtros y paneles
                rangoDatos.SetAutoFilter();
                ws.SheetView.FreezeRows(headerRow);

                // Anchos razonables (AdjustToContents primero y luego mínimo por columna)
                ws.Columns().AdjustToContents();
                ws.Column(1).Width = 14;
                ws.Column(3).Width = 16;
                ws.Column(4).Width = 15;
                ws.Column(5).Width = 18;
                ws.Column(7).Width = 24;

                workbook.SaveAs(rutaDestino);
            }
        }

        private static string HexEstado(ItemConsignacion item)
        {
            if (item.SerieSinMovimiento)
            {
                return HexCeldaSinMovimiento;
            }

            return item.State switch
            {
                ConsignacionEstado.EnPlazo => HexCeldaPlazo,
                ConsignacionEstado.Entregado => HexCeldaEntregado,
                _ => HexCeldaVencida
            };
        }
    }
}