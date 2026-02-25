using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace Control.Logic
{
    public class PrintManager
    {
        private DataGridView _dgv;
        private string _title;
        private int _currentRowIndex;
        private int _pageNumber;
        private PrintPreviewDialog _ppd;

        // Configuración de estilo centralizada
        private readonly Font _fontTitle = new Font("Segoe UI", 18, FontStyle.Bold);
        private readonly Font _fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fontBody = new Font("Segoe UI", 9, FontStyle.Regular);
        private readonly Pen _penThick = new Pen(Color.Black, 1.5f);
        private readonly Pen _penThin = new Pen(Color.LightGray, 0.5f);

        public void PrintGrid(DataGridView dgv, string title)
        {
            _dgv = dgv;
            _title = title;

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            // SUSCRIBIR ESTE NUEVO EVENTO
            pd.BeginPrint += (s, ev) =>
            {
                _currentRowIndex = 0;
                _pageNumber = 1;
            };

            pd.PrintPage += PrintPageEvent;
            using (PrintPreviewDialog ppd = new PrintPreviewDialog())
            {
                ppd.Document = pd;
                ppd.WindowState = FormWindowState.Maximized; // Abrir en pantalla completa
                ppd.ShowDialog();
            }

        }

        private void PrintPageEvent(object sender, PrintPageEventArgs e)
        {
            // Variables de control de posición
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int availableWidth = e.MarginBounds.Width;

            // Obtener columnas visibles una sola vez por página
            var cols = _dgv.Columns.Cast<DataGridViewColumn>()
                                   .Where(c => c.Visible)
                                   .ToList();

            // 1. Dibujar Encabezado del Documento (Título y Pág)
            DibujarCabeceraDocumento(e.Graphics, ref y, x, availableWidth);

            // 2. Dibujar Encabezado de la Tabla (Nombres de columnas)
            DibujarEncabezadosTabla(e.Graphics, ref y, x, availableWidth, cols);

            // 3. Dibujar Contenido (Las filas)
            bool necesitaNuevaPagina = DibujarFilasTabla(e.Graphics, ref y, x, availableWidth, cols, e.MarginBounds.Bottom);

            if (necesitaNuevaPagina)
            {
                _pageNumber++;
                e.HasMorePages = true;
                return;
            }

            // 4. Si terminamos todas las filas, dibujar Resumen
            if (_currentRowIndex >= _dgv.Rows.Count)
            {
                DibujarResumenFinal(e.Graphics, ref y, x, availableWidth, cols);
            }

            // 5. Dibujar Pie de Página (Fecha y hora)
            DibujarFooter(e.Graphics, e.MarginBounds.Bottom, x);

            e.HasMorePages = false;
        }

        // --- SUB-FUNCIONES DE APOYO ---

        private void DibujarCabeceraDocumento(Graphics g, ref int y, int x, int width)
        {
            g.DrawString(_title.ToUpper(), _fontTitle, Brushes.Black, x, y);
            g.DrawString($"Pág. {_pageNumber}", _fontBody, Brushes.Gray, x + width - 60, y + 10);
            y += 45;
        }

        private void DibujarEncabezadosTabla(Graphics g, ref int y, int x, int width, List<DataGridViewColumn> cols)
        {
            g.DrawLine(_penThick, x, y, x + width, y);
            int xPos = x;
            foreach (var col in cols)
            {
                int colWidth = GetColumnWidth(col.HeaderText, width, cols.Count);
                g.DrawString(col.HeaderText.ToUpper(), _fontHeader, Brushes.Black, xPos + 3, y + 5);
                xPos += colWidth;
            }
            y += 28; // rowHeight
            g.DrawLine(_penThick, x, y, x + width, y);
        }

        private bool DibujarFilasTabla(Graphics g, ref int y, int x, int width, List<DataGridViewColumn> cols, int limitBottom)
        {
            while (_currentRowIndex < _dgv.Rows.Count)
            {
                DataGridViewRow row = _dgv.Rows[_currentRowIndex];
                if (!row.IsNewRow)
                {
                    int xPos = x;
                    foreach (var col in cols)
                    {
                        int colWidth = GetColumnWidth(col.HeaderText, width, cols.Count);
                        string val = row.Cells[col.Index].Value?.ToString() ?? "";
                        g.DrawString(val, _fontBody, Brushes.Black, xPos + 3, y + 6);
                        xPos += colWidth;
                    }
                    y += 28;
                    g.DrawLine(_penThin, x, y, x + width, y);
                }

                _currentRowIndex++;

                // Verificar si saltamos de página
                if (y > limitBottom - 60) return true;
            }
            return false;
        }

        private void DibujarResumenFinal(Graphics g, ref int y, int x, int width, List<DataGridViewColumn> cols)
        {
            y += 20;
            int lineSpacing = 18;
            g.DrawLine(_penThick, x, y, x + width, y);
            y += 10;

            g.DrawString("RESUMEN DEL REPORTE", _fontHeader, Brushes.Black, x, y);
            y += lineSpacing + 5;

            int totalFilas = _dgv.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
            g.DrawString($"Total de ítems listados: {totalFilas}", _fontBody, Brushes.Black, x, y);
            y += lineSpacing;

            // Sumatorias automáticas mejoradas
            foreach (var col in cols)
            {
                // Intenta detectar si es numérico basándose en el tipo o en el primer valor
                if (EsColumnaNumerica(col))
                {
                    decimal total = 0;
                    foreach (DataGridViewRow row in _dgv.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow))
                    {
                        decimal.TryParse(row.Cells[col.Index].Value?.ToString(), out decimal val);
                        total += val;
                    }

                    string unidadTexto = total == 1 ? "Unidad" : "Unidades";
                    g.DrawString($"Total {col.HeaderText}: {total:N0} {unidadTexto}", _fontBody, Brushes.Black, x, y);
                    y += lineSpacing;
                }
            }
        }

        private void DibujarFooter(Graphics g, int bottom, int x)
        {
            string footer = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}";
            g.DrawString(footer, _fontBody, Brushes.DarkGray, x, bottom + 10);
        }

        // Función auxiliar para detectar números
        private bool EsColumnaNumerica(DataGridViewColumn col)
        {
            if (col.ValueType == typeof(int) || col.ValueType == typeof(decimal) || col.ValueType == typeof(double)) return true;

            return false;
        }
        // Lógica opcional: Hacer que ciertas columnas sean más anchas
        private int GetColumnWidth(string headerText, int totalWidth, int colCount)
        {
            // Si quieres que "Descripción" o "Código" ocupen más espacio, podrías programarlo aquí.
            // Por ahora, dividimos el ancho total equitativamente.
            return totalWidth / colCount;
        }

    }
}
