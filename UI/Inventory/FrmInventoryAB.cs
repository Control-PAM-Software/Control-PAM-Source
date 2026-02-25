using Control.Logic;
using Control.Models.Entities;
using Control.Models.Responses;
using Control.Models.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmInventoryAB : Form
    {
        private List<ItemAnexo> items = new List<ItemAnexo>(); // items del anexo
        private List<ItemAnexo> itemsReceived = new List<ItemAnexo>(); // items de la valija

        private Color differenceColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
        private Color missingColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);

        public FrmInventoryAB()
        {
            InitializeComponent();
        }
        private void FrmInventoryAB_Load(object sender, EventArgs e)
        {
            panelDiffAnexo.BackColor = differenceColor;
            panelMissItemAnexo.BackColor = missingColor;
            BtnTests.Visible = AppSettings.settings.Test;
        }


        #region Anexo Tab

        #region Ingreso

        private void BtnPasteAnexo_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            Headers header = new Headers();
            header.ArtCode.Name = AppSettings.settings.InventoryAB.ColumnCode.ToString();
            header.Qty.Name = AppSettings.settings.InventoryAB.ColumnUnits.ToString();
            header.Description.Name = AppSettings.settings.InventoryAB.ColumnDescription.ToString();
            header.SerialNr.Name = AppSettings.settings.InventoryAB.ColumnSerialNumber.ToString();
            header.DueDate.Name = AppSettings.settings.InventoryAB.ColumnDueDate.ToString();

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

            Functions.GenerateNumericalRows(dataGridView1);

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {

            //MessageBox.Show("Aún no se puede soltar archivos a la tabla. Pronto se podrá.", "Trabajando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;
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
                string ext = Path.GetExtension(ruta).ToLower();
                if (ext != ".xls" && ext != ".xlsx")
                {
                    MessageBox.Show($"El formato del archivo {ext} no es válido. Solo le permiten archivos .xsl o .xlsx", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Headers header = new Headers();
                header.ArtCode.Name = AppSettings.settings.InventoryAB.ColumnCode;
                header.Qty.Name = AppSettings.settings.InventoryAB.ColumnUnits;
                header.Description.Name = AppSettings.settings.InventoryAB.ColumnDescription;
                header.SerialNr.Name = AppSettings.settings.InventoryAB.ColumnSerialNumber;
                header.DueDate.Name = AppSettings.settings.InventoryAB.ColumnDueDate;

                try
                {
                    var lista = Functions.ReadAnexoFile(ruta, header, header.ArtCode.Name);
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
            Functions.GenerateNumericalRows(dataGridView1);

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

        #endregion

        #region Seteo Listados

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
            int serialHeaderPosition = dataGridView1.Columns["SerialNumber"].Index;
            int expireHeaderPosition = dataGridView1.Columns["DueDate"].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if (row.Cells[2].Value == null)
                {
                    continue;
                }

                string? quantity = "";
                string? code = "";
                string? serialNum = "";
                string? dueDate = "";
                if (row.Cells[qtyHeaderPosition].Value != null &&
                    row.Cells[codeHeaderPosition].Value != null &&
                    row.Cells[serialHeaderPosition].Value != null &&
                    row.Cells[expireHeaderPosition].Value != null)
                {
                    quantity = row.Cells[qtyHeaderPosition].Value.ToString();
                    code = row.Cells[codeHeaderPosition].Value.ToString();
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

        #endregion

        #region Comparar

        private void BtnCompare_Click(object sender, EventArgs e)
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

            if (items.Count != itemsReceived.Count)
            {
                MessageBox.Show($"El anexo y la valija no contienen la misma cantidad de artículos.\n" +
                                $"Anexo: {items.Count} artículos\n" +
                                $"Valija: {itemsReceived.Count} artículos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void compareItems()
        {
            ComparisonResult compareData = ComparisonResult.CompareItems(items, itemsReceived);

            if (compareData.MismatchedItems.Count == 0 && compareData.ExtraItems.Count == 0 && compareData.MissingItems.Count == 0)
            {
                MessageBox.Show("Todos los artículos están correctos", "Correcto", MessageBoxButtons.OK);
            }

            showErrorsInDataGridView(compareData);
        }

        private void showErrorsInDataGridView(ComparisonResult compareData)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string codItem = row.Cells["CodItem"].Value?.ToString();
                string serialNumber = row.Cells["SerialNumber"].Value?.ToString();

                // Buscar en mismatches (nuevo tipo MismatchedDetail)
                var mismatch = compareData.MismatchedItems
                    .FirstOrDefault(x => x.Expected.CodItem == codItem && x.Expected.SerialNumber == serialNumber);

                if (mismatch != null)
                {
                    row.DefaultCellStyle.BackColor = differenceColor; // Mismatched general

                    // Opcional: marcar diferencias con tooltip
                    string tooltip = "Diferencias: ";
                    if (mismatch.SerialNumberDiffers) tooltip += "N° de Serie, ";
                    if (mismatch.QuantityDiffers) tooltip += "Cantidad, ";
                    if (mismatch.DueDateDiffers) tooltip += "Vencimiento, ";

                    tooltip = tooltip.TrimEnd(',', ' ');

                    setToolTip(row, tooltip);

                    continue;
                }

                // Buscar en faltantes
                bool isMissing = compareData.MissingItems.Any(x => x.CodItem == codItem && x.SerialNumber == serialNumber);
                if (isMissing)
                {
                    row.DefaultCellStyle.BackColor = missingColor; // Rojo suave
                    setToolTip(row, "Ítem no recibido.");
                    continue;
                }

                // Correcto
                row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                setToolTip(row, string.Empty);
            }
        }
        
        public void setToolTip(DataGridViewRow row, string tooltip)
        {
            row.Cells["CodItem"].ToolTipText = tooltip;
            row.Cells["QuantityItem"].ToolTipText = tooltip;
            row.Cells["DescriptionItem"].ToolTipText = tooltip;
            row.Cells["SerialNumber"].ToolTipText = tooltip;
            row.Cells["DueDate"].ToolTipText = tooltip;
        }

        #endregion

        private void BtnCleanAnexo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        #endregion

        #region Received Tab

        private void TxtPickCodeReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (TxtPickCodeReceived.Text.Length > 15)
                {
                    string jsonOriginal = Functions.DecompressString(TxtPickCodeReceived.Text);

                    // 3. Volver a convertir en objetos (usando las abreviaturas c, s, q, v)
                    var listaAnonima = JsonConvert.DeserializeObject<List<dynamic>>(jsonOriginal);

                    foreach (var item in listaAnonima)
                    {
                        string codigo = item.c;
                        string serial = item.s;
                        decimal cantidad = item.q;
                        string vencimiento = item.v;

                        ItemAnexo newItem = new ItemAnexo();
                        newItem.CodItem = codigo;
                        newItem.SerialNumber = serial;
                        newItem.Quantity = cantidad;
                        newItem.DueDate = vencimiento;

                        AddNewItem(newItem);
                    }
                    TxtPickCodeReceived.Clear();
                    TxtPickCodeReceived.Focus();
                }
                else
                {
                    TxtPickSerialNumReceived.Focus();
                }
            }
        }

        private void TxtPickSerialNumReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                string codeNewItem = TxtPickCodeReceived.Text.Trim().ToUpper();
                string serialNumNewItem = TxtPickSerialNumReceived.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeNewItem) && !string.IsNullOrEmpty(serialNumNewItem))
                {
                    ItemAnexo newItem = Functions.GetItemFromInput(codeNewItem, serialNumNewItem, eProductLine.AB);

                    AddNewItem(newItem);
                }

            }
        }

        private void ReloadDataGridViewReceived()
        {
            dataGridViewReceived.Rows.Clear();
            foreach (var item in itemsReceived)
            {
                dataGridViewReceived.Rows.Add(item.Quantity, item.CodItem, item.SerialNumber, item.DueDate);
            }
            Functions.GenerateNumericalRows(dataGridViewReceived);

        }

        private void BtnHasPila_Click(object sender, EventArgs e)
        {
            ItemAnexo hasPila = new ItemAnexo();
            hasPila.CodItem = "070-0329";
            hasPila.SerialNumber = "150650";
            hasPila.DueDate = "";
            hasPila.Quantity = 1;

            ItemAnexo? existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == hasPila.CodItem && x.SerialNumber == hasPila.SerialNumber);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
            }
            else
            {
                dataGridViewReceived.Rows.Add(hasPila.Quantity.ToString(), hasPila.CodItem, hasPila.SerialNumber, hasPila.DueDate);
                itemsReceived.Add(hasPila);
            }
            ReloadDataGridViewReceived();
        }

        private void dataGridViewReceived_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            if (row != null)
            {
                ItemAnexo? existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == row.Cells[1].Value.ToString() && x.SerialNumber == row.Cells[2].Value.ToString());

                if (existingItem != null)
                {
                    itemsReceived.Remove(existingItem);
                }
            }
        }

        private void BtnManualArticle_Click(object sender, EventArgs e)
        {
            FrmManualArticle manualArticle = new FrmManualArticle();
            manualArticle.productLine = eProductLine.AB;

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

        private void AddNewItem(ItemAnexo newItem)
        {
            ItemAnexo? existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == newItem.CodItem && x.SerialNumber == newItem.SerialNumber && x.DueDate == newItem.DueDate);
            if (existingItem != null)
            {
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                itemsReceived.Add(newItem);
            }

            ReloadDataGridViewReceived();

            TxtPickCodeReceived.Focus();
            TxtPickCodeReceived.Clear();
            TxtPickSerialNumReceived.Clear();
        }


        private void CleanFrm()
        {
            dataGridViewReceived.Rows.Clear();
            TxtPickCodeReceived.Clear();
            TxtPickSerialNumReceived.Clear();
            itemsReceived.Clear();
        }

        private void BtnCleanReceived_Click(object sender, EventArgs e)
        {
            CleanFrm();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            string helpString = "Tildar el campo de texto correspondiente a 'Código'.\n" +
                                "Utilizar la pistola de picking (primero código y luego número de serie), \n" +
                                "y el sistema automáticamente irá agregando los artículos a la tabla.";

            MessageBox.Show(helpString, "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        #endregion

        private void BtnTests_Click(object sender, EventArgs e)
        {
            // Limpiar filas existentes
            dataGridViewReceived.Rows.Clear();
            itemsReceived.Clear();

            var items = new List<(string unidades, string codigo, string serie, string vencimiento)>
            {
                ("3", "CI-5501-120", "310078287", ""),
                ("5", "CI-5501-120", "310110781", ""),
                ("5", "CI-5501-120", "31011074s9", ""),
                ("4", "CI-5501-130", "310078288", ""),
                ("5", "CI-5501-130", "310110782", ""),
                ("5", "CI-5501-130", "310110750", "")
            };



            // Cargar los datos en el DataGridView
            foreach (var item in items)
            {
                dataGridViewReceived.Rows.Add(item.unidades, item.codigo, item.serie, item.vencimiento);

                // Agregar a la lista ItemsReceived
                itemsReceived.Add(new ItemAnexo
                {
                    CodItem = item.codigo,
                    Quantity = int.Parse(item.unidades),
                    SerialNumber = item.serie,
                    DueDate = item.vencimiento
                });
            }
        }


    }
}
