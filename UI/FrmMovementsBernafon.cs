using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Diagnostics;
using DocumentFormat.OpenXml.Vml;
using Control.Models.Settings;
using Control.Models.Entities;
using Control.Logic;

namespace Control
{
    public partial class FrmMovementsBernafon : Form
    {
        List<string> listItems = new List<string>();
        List<ItemAnexo> itemAnexos = new List<ItemAnexo>();
        bool loteCompared = false;  // Identifico si el lote de series recibidos se comparó con el anexo

        int aux = 30;
        int limite = 300;

        public FrmMovementsBernafon()
        {
            InitializeComponent();
            BtnTests.Visible = AppSettings.settings.Test;
        }

        private void FrmMovementsBernafon_Load(object sender, EventArgs e)
        {

        }

        private void GetFromQR()
        {

        }


        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            MostrarMensajeProcesando(true);

            try
            {
                string[] archivos;

                try
                {
                    archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ha ocurrido un error al leer la ruta del archivo: {ex}.", "Error de lectura de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (archivos.Length == 0)
                {
                    MessageBox.Show("El archivo no pudo ser capturado correctamente.", "Error de captura de archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //CleanFrm();
                dataGridView1.Rows.Clear();
                int line = 0;

                foreach (string ruta in archivos)
                {
                    string ext = System.IO.Path.GetExtension(ruta).ToLower();
                    if (ext != ".xls" && ext != ".xlsx")
                    {
                        MessageBox.Show($"El formato del archivo {ext} no es válido. Solo le permiten archivos .xsl o .xlsx", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Headers header = new Headers();
                    header.ArtCode.Name = AppSettings.settings.MovementsBernafon.ColumnCode;
                    header.Qty.Name = AppSettings.settings.MovementsBernafon.ColumnUnits;

                    try
                    {
                        var lista = Functions.ReadAnexoFile(ruta, header, true);

                        if (lista == null)
                        {
                            return;
                        }

                        FillDataGridView(lista);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hubo un error al obtener los datos del archivo: {ex}", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                //Functions.GenerateNumericalRows(dataGridView1);

            }
            finally
            {
                MostrarMensajeProcesando(false);
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Muestra el cursor de copiar

                // 1. Mostramos el panel de superposición
                var overlay = dataGridView1.Controls["pnlDropOverlay"];
                if (overlay != null) overlay.Visible = true;

                dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(229, 235, 244); // El azul tenue de selección
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragLeave(object sender, EventArgs e)
        {
            OcultarFeedbackDragDrop();
        }

        private void MostrarMensajeProcesando(bool procesando)
        {
            var overlay = dataGridView1.Controls["pnlDropOverlay"] as Panel;
            var label = overlay?.Controls[0] as Label;

            if (overlay != null && label != null)
            {
                if (procesando)
                {
                    label.Text = "⚙️\n\nProcesando archivo...\nPor favor, espere.";
                    overlay.BackColor = System.Drawing.Color.FromArgb(200, 39, 39, 58); // Un azul más sólido para el proceso
                    overlay.Visible = true;
                    overlay.BringToFront(); // Aseguramos que esté arriba de todo
                    overlay.Refresh(); // FORZAMOS que se dibuje antes de que empiece el bucle
                }
                else
                {
                    label.Text = "📥\n\nSuelte el archivo aquí para procesar";
                    overlay.Visible = false;
                }
            }
        }

        private void OcultarFeedbackDragDrop()
        {
            var overlay = dataGridView1.Controls["pnlDropOverlay"];
            if (overlay != null) overlay.Visible = false;

            dataGridView1.BackgroundColor = System.Drawing.Color.White;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Functions.EnumerarFilasDataGrid(sender, e);
        }


        private void BtnCleanAnexo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            loteCompared = false;
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Functions.GenerateNumericalRows(dataGridView1);
        }

        private void BtnTests_Click(object sender, EventArgs e)
        {

        }

        private void BtnPasteAnexo_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            Headers header = new Headers();
            header.ArtCode.Name = AppSettings.settings.MovementsBernafon.ColumnCode.ToString();
            header.Qty.Name = AppSettings.settings.MovementsBernafon.ColumnUnits.ToString();

            List<ItemAnexo>? itemsAnexo = Functions.ReadAnexo(clipboardText, header, true);

            if (itemsAnexo == null)
            {
                return;
            }

            if (itemsAnexo.Count == 0)
            {
                return;
            }

            FillDataGridView(itemsAnexo);

            //Functions.GenerateNumericalRows(dataGridView1);
        }

        private void FillDataGridView(List<ItemAnexo> pItems)
        {
            // Se agrega color solo para diferencias los audífonos y cargadores de forma visual
            Dictionary<string, Color> colorPorCodigo = new Dictionary<string, Color>();

            string audifonos = AppSettings.settings.MovementsBernafon.Codigos_Desglose;
            int line = 0;
            foreach (var item in pItems)
            {
                bool esAudifono = audifonos.Contains(item.CodItem);
                Color rawColor = Color.White;

                if (esAudifono)
                {
                    if (!colorPorCodigo.ContainsKey(item.CodItem))
                    {
                        colorPorCodigo[item.CodItem] = GetPastelColor(item.CodItem);
                    }

                    rawColor = colorPorCodigo[item.CodItem];
                }

                if (esAudifono && item.Quantity > 1)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[line].Cells["Qty"].Value = 1;
                        dataGridView1.Rows[line].Cells["ArtCode"].Value = item.CodItem;
                        dataGridView1.Rows[line].DefaultCellStyle.BackColor = rawColor;
                        line++;
                    }
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[line].Cells["Qty"].Value = item.Quantity;
                    dataGridView1.Rows[line].Cells["ArtCode"].Value = item.CodItem;
                    line++;
                }

                itemAnexos.Add(item);
            }
        }

        // Generador estable de colores pastel
        private Color GetPastelColor(string key)
        {
            int intensity = 20;
            intensity = Math.Clamp(intensity, 0, 100);

            int hash = key.GetHashCode();
            Random rnd = new Random(hash);

            int baseColor = 240 - intensity;   // cuanto más bajo, más fuerte
            int variation = intensity / 2;     // rango de variación

            int r = baseColor + rnd.Next(variation);
            int g = baseColor + rnd.Next(variation);
            int b = baseColor + rnd.Next(variation);

            return Color.FromArgb(r, g, b);
        }


        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var codeObj = dataGridView1.Rows[e.RowIndex].Cells["ArtCode"].Value;

            if (codeObj == null || codeObj == DBNull.Value)
                return;

            string code = codeObj.ToString();

            if (MessageBox.Show($"Se desglosará el código {code}. ¿Desea continuar?", "Desglose de artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int oldQty = 0;

            var cellValue = dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value;

            if (cellValue != null && int.TryParse(cellValue.ToString(), out int result))
            {
                oldQty = result;
            }

            dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value = "1";

            int artCodeIndex = dataGridView1.Columns["ArtCode"].Index;
            int qtyIndex = dataGridView1.Columns["Qty"].Index;
            int serialIndex = dataGridView1.Columns["SerialNr"].Index;
            List<DataGridViewRow> rowsToAdd = new List<DataGridViewRow>();

            // Utilizo oldQty - 1 ya que está la fila original del producto
            for (int i = 0; i < oldQty - 1; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                row.Cells[artCodeIndex].Value = code;
                row.Cells[qtyIndex].Value = 1;
                row.Cells[serialIndex].Value = "";

                rowsToAdd.Add(row);
            }

            //dataGridView1.Rows.InsertCopies(e.RowIndex, e.RowIndex + 1, oldQty - 1);
            dataGridView1.Rows.InsertRange(e.RowIndex, rowsToAdd.ToArray());
            //Functions.GenerateNumericalRows(dataGridView1);
        }

        private void BtnCopyResult_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            Functions.CopyGridViewResult(dataGridView1);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name != "SerialNr")
                return;

            var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (string.IsNullOrWhiteSpace(cellValue))
                return;

            if (!cellValue.Contains(';'))
                return;

            // Separadores comunes de QR
            var serials = cellValue
                .Split(new[] { '\n', '\r', ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            if (serials.Count <= 1)
                return;

            FillSerials(e.RowIndex, serials);
        }


        private void FillSerials(int startRow, List<string> serials)
        {
            int lastRowUsed = startRow;

            for (int i = 0; i < serials.Count; i++)
            {
                int rowIndex = startRow + i;

                // No pasar la última fila vacía
                if (rowIndex >= dataGridView1.Rows.Count - 1)
                    break;

                dataGridView1.Rows[rowIndex].Cells["SerialNr"].Value = serials[i];
                lastRowUsed = rowIndex;
            }

            //MoveFocusToNextRow(lastRowUsed);
        }

        private void MoveFocusToNextRow(int lastRow)
        {
            int nextRow = lastRow + 1;

            if (nextRow < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.CurrentCell =
                    dataGridView1.Rows[nextRow].Cells["SerialNr"];

                dataGridView1.BeginEdit(true);
            }
        }

        private void btnPrintReceived_Click(object sender, EventArgs e)
        {
            try
            {
                PrintManager printer = new PrintManager();
                printer.PrintGrid(dataGridView1, "Movimiento Bernafon");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.ErrorDeImpresion}: \n\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
