using Control.Logic;
using Control.Models.Entities;
using Control.Models.Responses;
using Control.Models.Settings;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmRegistrationInomed : Form
    {
        List<ItemAnexo> itemsReceived = new List<ItemAnexo>();
        List<ItemAnexo> items = new List<ItemAnexo>();

        private Color differenceColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
        private Color missingColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);

        public FrmRegistrationInomed()
        {
            InitializeComponent();
        }

        private void FrmInventoryInomed_Load(object sender, EventArgs e)
        {
            panelDiffAnexo.BackColor = differenceColor;
            panelMissItemAnexo.BackColor = missingColor;

            BtnTests.Visible = AppSettings.settings.Test;
        }

        private void BtnPasteAnexo_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            Headers header = new Headers();
            header.ArtCode.Name = AppSettings.settings.IngresoInomed.ColumnCode.ToString();
            header.Qty.Name = AppSettings.settings.IngresoInomed.ColumnUnits.ToString();
            header.Description.Name = AppSettings.settings.IngresoInomed.ColumnDescription.ToString();
            header.SerialNr.Name = AppSettings.settings.IngresoInomed.ColumnSerialNumber.ToString();
            header.DueDate.Name = AppSettings.settings.IngresoInomed.ColumnDueDate.ToString();

            List<ItemAnexo>? itemsAnexo = Functions.ReadAnexo(clipboardText, header);

            if (itemsAnexo == null)
            {
                return;
            }

            if (itemsAnexo.Count == 0)
            {
                return;
            }

            foreach (var item in itemsAnexo)
            {
                dataGridView1.Rows.Add(
                    item.Quantity.ToString(),
                    item.CodItem,
                    item.Description,
                    item.SerialNumber,
                    item.DueDate
                );
            }
        }

        private void BtnCleanAnexo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void BtnCleanReceived_Click(object sender, EventArgs e)
        {
            dataGridViewReceived.Rows.Clear();
            TxtPickCodeReceived.Clear();
            itemsReceived.Clear();
        }

        private void TxtPickCodeReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                string codeInput = TxtPickCodeReceived.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeInput))
                {
                    ItemAnexo? itemInput = Functions.GetItemFromInput(codeInput, eProductLine.Inomed);

                    if (itemInput == null)
                    {
                        MessageBox.Show("Formato de cadena de texto incorrecto.", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    AddNewItem(itemInput);


                }

            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                Compare();
            }
        }

        private void AddNewItem(ItemAnexo itemInput)
        {
            ItemAnexo? existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == itemInput.CodItem && x.SerialNumber == itemInput.SerialNumber && (x.DueDate == itemInput.DueDate || string.Equals(itemInput.DueDate, "")));

            if (existingItem != null)
            {
                existingItem.Quantity += itemInput.Quantity;
            }
            else
            {
                itemsReceived.Add(itemInput);
            }

            ReloadDataGridViewReceived();

            TxtPickCodeReceived.Focus();
            TxtPickCodeReceived.Clear();
        }



        private void ReloadDataGridViewReceived(bool isFromPicking = true)
        {
            if (isFromPicking)
            {
                dataGridViewReceived.Rows.Clear();
                foreach (var item in itemsReceived)
                {
                    dataGridViewReceived.Rows.Add(item.Quantity, item.CodItem, item.SerialNumber, item.DueDate);
                }
            }
            else
            {
                dataGridViewReceived.Rows.Clear();
                foreach (var item in itemsReceived)
                {
                    int rowIndex = dataGridViewReceived.Rows.Add(
                        item.Quantity,
                        item.CodItem,
                        item.SerialNumber,
                        item.DueDate
                    );

                    dataGridViewReceived.Rows[rowIndex].Tag = eArticle.oldArticle;
                    dataGridViewReceived.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            Compare();
        }

        private void Compare()
        {
            setItemsAnexo();
            if (items.Count == 0)
            {
                return;
            }

            setItemsReceived();
            if (itemsReceived != null && itemsReceived.Count == 0)
            {
                return;
            }

            compareItems();
        }

        private void setItemsAnexo()
        {
            items.Clear();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No se cargó el Anexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int codeHeaderPosition = dataGridView1.Columns["CodItem"].Index;
            int qtyHeaderPosition = dataGridView1.Columns["QuantityItem"].Index;
            int descriptionHeaderPosition = dataGridView1.Columns["DescriptionItem"].Index;
            int serialHeaderPosition = dataGridView1.Columns["SerialNumber"].Index;
            int expireHeaderPosition = dataGridView1.Columns["DueDate"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if (row.Cells[1].Value == null)
                {
                    continue;
                }

                string? quantity = "";
                string? code = "";
                string? description = "";
                string? serialNum = "";
                string? dueDate = "";

                if (row.Cells[qtyHeaderPosition].Value != null &&
                    row.Cells[codeHeaderPosition].Value != null &&
                    row.Cells[descriptionHeaderPosition].Value != null &&
                    row.Cells[serialHeaderPosition].Value != null &&
                    row.Cells[expireHeaderPosition].Value != null)
                {
                    quantity = row.Cells[qtyHeaderPosition].Value.ToString();
                    code = row.Cells[codeHeaderPosition].Value.ToString();
                    description = row.Cells[descriptionHeaderPosition].Value.ToString();
                    serialNum = row.Cells[serialHeaderPosition].Value.ToString();
                    dueDate = row.Cells[expireHeaderPosition].Value.ToString();
                }
                else
                {
                    MessageBox.Show("El anexo no fue cargado correctamente. Hay celdas vacías.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    items.Clear();
                    break;
                }
                int quantityInt = 0;

                ItemAnexo? existingItem = items.FirstOrDefault(x => x.CodItem == code && x.SerialNumber == serialNum);

                if (existingItem != null)
                {
                    existingItem.Quantity += 1;
                }
                else
                {
                    ItemAnexo newItem = new ItemAnexo();

                    newItem.CodItem = code;
                    newItem.SerialNumber = serialNum;
                    newItem.Description = description;
                    if (int.TryParse(quantity, out quantityInt))
                    {
                        newItem.Quantity = quantityInt;
                    }
                    newItem.DueDate = dueDate;

                    items.Add(newItem);
                }
            }

            if (items.Count == 0)
            {
                MessageBox.Show("No se cargó el anexo con el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setItemsReceived()
        {
            itemsReceived.Clear();

            if (dataGridViewReceived.Rows.Count == 0)
            {
                MessageBox.Show("No se cargó la Valija.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < dataGridViewReceived.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewReceived.Rows[i];

                if (row.Cells[2].Value == null)
                {
                    continue;
                }

                string? quantity = "";
                string? code = "";
                string? serialNum = "";
                string? dueDate = "";
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    quantity = row.Cells[0].Value.ToString();
                    code = row.Cells[1].Value.ToString();
                    serialNum = row.Cells[2].Value.ToString();
                    dueDate = row.Cells[3].Value.ToString();
                }
                else
                {
                    MessageBox.Show("La valija no fue cargada correctamente. Hay celdas vacías.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    items.Clear();
                    break;
                }
                int quantityInt = 0;

                ItemAnexo? existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == code && x.SerialNumber == serialNum);

                if (existingItem != null)
                {
                    existingItem.Quantity += 1;
                }
                else
                {
                    ItemAnexo newItem = new ItemAnexo();

                    newItem.CodItem = code;
                    newItem.SerialNumber = serialNum;
                    if (int.TryParse(quantity, out quantityInt))
                    {
                        newItem.Quantity = quantityInt;
                    }
                    newItem.DueDate = dueDate;

                    itemsReceived.Add(newItem);
                }
            }

            if (itemsReceived.Count == 0)
            {
                MessageBox.Show("No se cargó la valija con el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void compareItems()
        {

            ComparisonResult comparisonResult = ComparisonResult.CompareItemsNew(items, itemsReceived);


            ReloadDataGridView(items);
            ReloadDataGridViewReceived(false); // Para identificar los artículos diferentes.

            if (items.Count == 0 && itemsReceived.Count == 0)
            {
                MessageBox.Show("No quedan artículos por comparar.", "Inventario finalizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ReloadDataGridView(List<ItemAnexo> items)
        {
            int line = 0;
            dataGridView1.Rows.Clear();
            foreach (var item in items)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[line].Cells["QuantityItem"].Value = item.Quantity;
                dataGridView1.Rows[line].Cells["CodItem"].Value = item.CodItem;
                dataGridView1.Rows[line].Cells["DescriptionItem"].Value = item.Description;
                dataGridView1.Rows[line].Cells["SerialNumber"].Value = item.SerialNumber;
                dataGridView1.Rows[line].Cells["DueDate"].Value = item.DueDate;
                line++;
            }
        }

        public void setToolTip(DataGridViewRow row, string tooltip)
        {
            row.Cells["CodItemReceivedInventory"].ToolTipText = tooltip;
            row.Cells["UnitsReceivedInventory"].ToolTipText = tooltip;
            //row.Cells["DescriptionItem"].ToolTipText = tooltip;
            row.Cells["SerialReceivedInventory"].ToolTipText = tooltip;
            row.Cells["DueDateReceivedInventory"].ToolTipText = tooltip;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Muestra el cursor de copiar
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
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

            dataGridView1.Rows.Clear();
            int line = 0;

            foreach (string ruta in archivos)
            {
                string ext = Path.GetExtension(ruta).ToLower();
                if (ext != ".xls" && ext != ".xlsx")
                {
                    MessageBox.Show($"El formato del archivo {ext} no es válido. Solo le permiten archivos .xsl o .xlsx", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Headers header = new Headers();
                header.ArtCode.Name = AppSettings.settings.IngresoInomed.ColumnCode;
                header.Qty.Name = AppSettings.settings.IngresoInomed.ColumnUnits;
                header.Description.Name = AppSettings.settings.IngresoInomed.ColumnDescription;
                header.SerialNr.Name = AppSettings.settings.IngresoInomed.ColumnSerialNumber;
                header.DueDate.Name = AppSettings.settings.IngresoInomed.ColumnDueDate;

                try
                {
                    var lista = Functions.ReadAnexoFile(ruta, header);

                    if (lista == null)
                    {
                        return;
                    }

                    foreach (var item in lista)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[line].Cells["QuantityItem"].Value = item.Quantity;
                        dataGridView1.Rows[line].Cells["CodItem"].Value = item.CodItem;
                        dataGridView1.Rows[line].Cells["DescriptionItem"].Value = item.Description;
                        dataGridView1.Rows[line].Cells["SerialNumber"].Value = item.SerialNumber;
                        dataGridView1.Rows[line].Cells["DueDate"].Value = item.DueDate;
                        line++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un error al obtener los datos del archivo: {ex}", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void BtnTests_Click(object sender, EventArgs e)
        {
            items = new List<ItemAnexo> {
                    new ItemAnexo("7204", "", "2310002", 17, ""),
                    new ItemAnexo("7205", "", "2011228", 1, ""),
                    new ItemAnexo("7215", "", "2108182", 4, ""),
                    new ItemAnexo("7215", "", "2307154", 5, ""),
                    new ItemAnexo("7246", "", "2009240", 6, ""),
                    new ItemAnexo("7260", "", "2409131", 9, ""),
                    new ItemAnexo("7270", "", "2008190", 3, ""),
                    new ItemAnexo("7270", "", "2104201", 3, ""),
                    new ItemAnexo("7275", "", "2305288", 7, ""),
                    new ItemAnexo("7275", "", "2402375", 3, ""),
                    new ItemAnexo("7275", "", "2403260", 5, ""),
                    new ItemAnexo("7276", "", "2105002", 3, ""),
                    new ItemAnexo("7276", "", "2106252", 3, "")
                };

            dataGridView1.Rows.Clear();
            dataGridViewReceived.Rows.Clear();

            foreach (var item in items)
            {
                dataGridView1.Rows.Add(
                    item.Quantity,
                    item.CodItem,
                    item.Description,
                    item.SerialNumber,
                    item.DueDate
                );

                dataGridViewReceived.Rows.Add(
                    item.Quantity,
                    item.CodItem,
                    item.SerialNumber,
                    item.DueDate
                );
            }

        }

        private void BtnManualArticle_Click(object sender, EventArgs e)
        {
            FrmManualArticle manualArticle = new FrmManualArticle();
            manualArticle.productLine = eProductLine.Inomed;

            if (manualArticle.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ItemAnexo itemInput = new ItemAnexo();

                    itemInput.CodItem = manualArticle.articleCode;
                    itemInput.SerialNumber = manualArticle.articleSerie;
                    itemInput.DueDate = manualArticle.articleDueDate;

                    if (decimal.TryParse(manualArticle.articleQuantity, out decimal quantity))
                    {
                        itemInput.Quantity = quantity;
                    }

                    AddNewItem(itemInput);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error al cargar el artículo manual a la tabla.", "Error Articulo Manual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void BtnCreateOpenOrange_Click(object sender, EventArgs e)
        {
            setItemsAnexo();
            dataGridViewResult.Rows.Clear();

            if (items.Count == 0)
            {
                MessageBox.Show("No se cargó el anexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var color = dataGridView1.DefaultCellStyle.BackColor;

            bool areErrorsInData = dataGridView1.Rows
                                    .Cast<DataGridViewRow>()
                                    .Any(row => row.DefaultCellStyle.BackColor == differenceColor || row.DefaultCellStyle.BackColor == missingColor);

            if (areErrorsInData)
            {
                if (MessageBox.Show("Hay errores en el anexo, ¿Desea generar la tabla de todas maneras?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                string expireDate = item.DueDate == "" ? "" : item.DueDate;
                string batchStatus = item.DueDate == "" ? "" : "APRO";
                string kitPrefij = "";
                string kitNumber = "";
                string articlePrice = AppSettings.settings.ArticlePrice;

                dataGridViewResult.Rows.Add(item.CodItem, item.Quantity, item.SerialNumber, expireDate, articlePrice, batchStatus, kitNumber);
            }

            dataGridViewResult.Columns["ColumnCodeResult"].Visible = AppSettings.settings.OpenOrange.ColumnCode.isActive;
            dataGridViewResult.Columns["ColumnQtyResult"].Visible = AppSettings.settings.OpenOrange.ColumnUnits.isActive;
            dataGridViewResult.Columns["ColumnSerieResult"].Visible = AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive;
            dataGridViewResult.Columns["ColumnPriceResult"].Visible = AppSettings.settings.OpenOrange.ColumnPrice.isActive;
            dataGridViewResult.Columns["ColumnExpireResult"].Visible = AppSettings.settings.OpenOrange.ColumnDueDate.isActive;
            dataGridViewResult.Columns["ColumnBatchResult"].Visible = AppSettings.settings.OpenOrange.ColumnBatch.isActive;
            dataGridViewResult.Columns["ColumnKitResult"].Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;

            MessageBox.Show("Ya fue generada la tabla correctamente.", "Completado");
        }

        private void BtnCopyResult_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.Rows.Count == 0)
            {
                MessageBox.Show("La tabla aún no fue generada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Functions.CopyGridViewResult(dataGridViewResult);

        }

        private void BtnCleanResult_Click(object sender, EventArgs e)
        {

        }
    }

}
