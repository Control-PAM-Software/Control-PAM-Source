using Control.Logic;
using Control.Models.Entities;
using Control.Models.Responses;
using Control.Models.Settings;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmRegistrationBase : Form
    {
        protected List<ItemAnexo> items = new List<ItemAnexo>(); // items del anexo
        protected List<ItemAnexo> itemsReceived = new List<ItemAnexo>(); // items de la valija
        protected dynamic ConfigMarca { get; set; }

        protected int MAX_HEIGHT_RECEIVED = 165; // Altura total de los 3 sub-botones (55px cada uno)
        protected int MAX_HEIGHT_RESULT = 110; // Altura total de los 2 sub-botones (55px cada uno)
        protected int SPEED = 12;        // Píxeles por cada 'tick' del reloj

        protected bool isMenuResultOpen = false;
        protected bool isMenuReceivedOpen = false;

        protected eProductLine productLine;
        protected string productName = "";

        protected bool groupItems = true;

        public FrmRegistrationBase()
        {
            InitializeComponent();
        }

        private void FrmRegistrationBase_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return; // Crucial para que el diseñador no intente leer settings

            LoadGridViews();
            BtnTests.Visible = AppSettings.settings.Test;
            btnConvertLP.Visible = false; // Se visualiza únicamente para Accesorios AB

            panelDiffAnexo.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
            panelMissItemAnexo.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);

            dataGridViewReceived.Columns["QtyReceived"].ValueType = typeof(decimal);
            dataGridViewResult.Columns["ColumnQtyResult"].ValueType = typeof(decimal);

        }

        protected virtual void LoadGridViews()
        {
            dataGridViewResult.Columns["ColumnCodeResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnCode.name;
            dataGridViewResult.Columns["ColumnQtyResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnUnits.name;
            dataGridViewResult.Columns["ColumnSerieResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnSerialNumber.name;
            dataGridViewResult.Columns["ColumnPriceResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnPrice.name;
            dataGridViewResult.Columns["ColumnExpireResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnDueDate.name;
            dataGridViewResult.Columns["ColumnBatchResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnBatch.name;
            dataGridViewResult.Columns["ColumnKitResult"].HeaderText = AppSettings.settings.OpenOrange.ColumnKit.name;

            dataGridViewResult.Columns["ColumnCodeResult"].Visible = AppSettings.settings.OpenOrange.ColumnCode.isActive;
            dataGridViewResult.Columns["ColumnQtyResult"].Visible = AppSettings.settings.OpenOrange.ColumnUnits.isActive;
            dataGridViewResult.Columns["ColumnSerieResult"].Visible = AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive;
            dataGridViewResult.Columns["ColumnPriceResult"].Visible = AppSettings.settings.OpenOrange.ColumnPrice.isActive;
            dataGridViewResult.Columns["ColumnExpireResult"].Visible = AppSettings.settings.OpenOrange.ColumnDueDate.isActive;
            dataGridViewResult.Columns["ColumnBatchResult"].Visible = AppSettings.settings.OpenOrange.ColumnBatch.isActive;
            dataGridViewResult.Columns["ColumnKitResult"].Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;
        }


        /// <summary>
        /// Métodos virtuales para la sobreescritura de los hijos del formulario.
        /// </summary>
        #region Virtual Methods

        protected virtual void TxtPickCodeReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void TxtPickSerialNumReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void BtnTests_Virtual_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Anexo

        #region Ingreso

        private void BtnPasteAnexo_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            Models.Entities.Headers header = new Models.Entities.Headers();
            header.ArtCode.Name = ConfigMarca.ColumnCode.ToString();
            header.Qty.Name = ConfigMarca.ColumnUnits.ToString();
            header.Description.Name = ConfigMarca.ColumnDescription.ToString();
            header.SerialNr.Name = ConfigMarca.ColumnSerialNumber.ToString();
            header.DueDate.Name = ConfigMarca.ColumnDueDate.ToString();

            List<ItemAnexo>? itemsAnexo = Functions.ReadAnexo(clipboardText, header, false, groupItems);

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
                    item.IsAquaKit,
                    item.Quantity.ToString(),
                    item.CodItem,
                    item.Description,
                    item.SerialNumber,
                    item.DueDate
                );
            }
        }

        protected void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // 1. Cambiamos el overlay al modo "Procesando"
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

                dataGridView1.Rows.Clear();
                int line = 0;

                foreach (string ruta in archivos)
                {
                    string ext = Path.GetExtension(ruta).ToLower();
                    if (ext != ".xls" && ext != ".xlsx")
                    {
                        MessageBox.Show($"El formato del archivo {ext} no es válido. Solo se permiten .xls o .xlsx", "Archivo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // ... (Tu lógica de Headers se mantiene igual) ...
                    Models.Entities.Headers header = new Models.Entities.Headers();
                    header.ArtCode.Name = ConfigMarca.ColumnCode;
                    header.Qty.Name = ConfigMarca.ColumnUnits;
                    header.Description.Name = ConfigMarca.ColumnDescription;
                    header.SerialNr.Name = ConfigMarca.ColumnSerialNumber;
                    header.DueDate.Name = ConfigMarca.ColumnDueDate;

                    try
                    {
                        var lista = Functions.ReadAnexoFile(ruta, header, false, groupItems);
                        if (lista == null) return;


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
            finally
            {
                // 2. Pase lo que pase, al terminar ocultamos el mensaje
                MostrarMensajeProcesando(false);
                dataGridView1.BackgroundColor = System.Drawing.Color.White;
            }
        }

        protected void dataGridView1_DragEnter(object sender, DragEventArgs e)
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

        protected void dataGridView1_DragLeave(object sender, EventArgs e)
        {
            OcultarFeedbackDragDrop();
        }

        protected void MostrarMensajeProcesando(bool procesando)
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



        #endregion

        #region Seteo Listados

        protected void setItemsAnexo()
        {
            items.Clear();

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No se cargó el Anexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
                if (row.Cells[1].Value != null &&
                    row.Cells[2].Value != null &&
                    row.Cells[4].Value != null &&
                    row.Cells[5].Value != null)
                {
                    quantity = row.Cells[1].Value.ToString();
                    code = row.Cells[2].Value.ToString();
                    serialNum = row.Cells[4].Value.ToString();
                    dueDate = row.Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("El anexo no fue cargado correctamente. Hay celdas vacías.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    items.Clear();
                    break;
                }
                int quantityInt = 0;

                ItemAnexo? existingItem = items.FirstOrDefault(x => x.CodItem == code && x.SerialNumber == serialNum);

                if (existingItem != null && groupItems)
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
                    newItem.IsAquaKit = Convert.ToBoolean(row.Cells[0].Value);

                    items.Add(newItem);
                }
            }

            if (items.Count == 0)
            {
                MessageBox.Show("No se cargó el anexo con el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void setItemsReceived()
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

                if (existingItem != null && groupItems)
                {
                    if (int.TryParse(quantity, out quantityInt))
                    {
                        existingItem.Quantity += quantityInt;
                    }
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

        /// <summary>
        /// Evento asociado al botón de Comparar.
        /// Valijas AB (FrmRegistrationAB) sobreescribe este método.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void BtnCompare_Click(object sender, EventArgs e)
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
            // Este listado nos permite recordar qué artículos ya pintamos para no volver a pintar en caso de que el listado no agrupe por código - serie - vencimiento.
            List<MismatchedDetail> ArticulosYaPintados = new List<MismatchedDetail>();

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
                    if (ArticulosYaPintados.Any(x => x.Expected.CodItem == codItem && x.Expected.SerialNumber == serialNumber))
                        continue;

                    ArticulosYaPintados.Add(mismatch);

                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences); // Mismatched general

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
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem); // Rojo suave
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
            row.Cells["IsAquaKit"].ToolTipText = tooltip;
            row.Cells["QuantityItem"].ToolTipText = tooltip;
            row.Cells["DescriptionItem"].ToolTipText = tooltip;
            row.Cells["SerialNumber"].ToolTipText = tooltip;
            row.Cells["DueDate"].ToolTipText = tooltip;
        }

        #endregion

        #region Open Orange

        protected void BtnCreateOpenOrange_Click(object sender, EventArgs e)
        {
            dataGridViewResult.Rows.Clear();
            if (items.Count == 0)
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No se cargó el anexo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

            }

            var color = dataGridView1.DefaultCellStyle.BackColor;

            bool areErrorsInData = dataGridView1.Rows
                                    .Cast<DataGridViewRow>()
                                    .Any(row => row.DefaultCellStyle.BackColor == ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences) || row.DefaultCellStyle.BackColor == ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem));

            if (areErrorsInData)
            {
                if (MessageBox.Show("Hay errores en el anexo, ¿Desea generar la tabla de todas maneras?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            setItemsAnexo();

            string serialNumProcessor = TxtSerialNumProcessor.Text;

            if (string.IsNullOrEmpty(serialNumProcessor) && TxtSerialNumProcessor.Visible)
            {
                if (MessageBox.Show("No está cargado el número de serie del procesador. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                Functions.GenerateResultOpenOrangeGrid(dataGridViewResult, items, serialNumProcessor);

                //Functions.GenerateNumericalRows(dataGridViewResult);

                MessageBox.Show("Ya fue generada la tabla correctamente.", "Completado");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al generar la tabla de Open Orange:\n {ex}", "Error de generación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        protected virtual void btnConvertLP_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }
            // Verifica que sea la columna del CheckBox y que no sea el encabezado
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool valorActual = (checkCell.Value != null && (bool)checkCell.Value);
                checkCell.Value = !valorActual;

                // Forzamos commit y repintado para que se vea al instante
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView1.EndEdit();
                dataGridView1.InvalidateCell(e.ColumnIndex, e.RowIndex); // Opcional, pero asegura el redibujado
            }
        }

        private void BtnCleanAnexo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            TxtSerialNumProcessor.Clear();
            items.Clear();
        }


        #endregion


        #region Received Tab

        #region Ingreso

        /// <summary>
        /// Evento de tecleo sobre el textBox de código del Tab Received. Cada clase debe sobrescribir su lógica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPickCodeReceived_KeyDown(object sender, KeyEventArgs e)
        {
            TxtPickCodeReceived_Virtual_KeyDown(sender, e);
        }

        /// <summary>
        /// Evento de tecleo sobre el textBox de número de serie del Tab Received. Cada clase debe sobrescribir su lógica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPickSerialNumReceived_KeyDown(object sender, KeyEventArgs e)
        {
            TxtPickSerialNumReceived_Virtual_KeyDown(sender, e);
        }

        private void BtnHasPila_Click(object sender, EventArgs e)
        {
            ItemAnexo hasPila = new ItemAnexo();
            hasPila.CodItem = "070-0329";
            hasPila.SerialNumber = "150650";
            hasPila.DueDate = "";
            hasPila.Quantity = 1;

            ItemAnexo existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == hasPila.CodItem && x.SerialNumber == hasPila.SerialNumber);

            if (existingItem != null)
            {
                existingItem.Quantity += 1;
                ReloadDataGridViewReceived();
            }
            else
            {
                dataGridViewReceived.Rows.Add(hasPila.Quantity.ToString(), hasPila.CodItem, hasPila.SerialNumber, hasPila.DueDate);
                itemsReceived.Add(hasPila);
            }

        }

        private void BtnManualArticle_Click(object sender, EventArgs e)
        {
            FrmManualArticle manualArticle = new FrmManualArticle();
            manualArticle.productLine = productLine;

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un error al cargar el artículo manual a la tabla:\n\n{ex}", "Error Articulo Manual", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        protected void AddNewItem(ItemAnexo itemInput)
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

        #endregion

        protected void ReloadDataGridViewReceived()
        {
            dataGridViewReceived.Rows.Clear();
            foreach (var item in itemsReceived)
            {
                dataGridViewReceived.Rows.Add(item.Quantity, item.CodItem, item.SerialNumber, item.DueDate);
            }
        }

        private void dataGridViewReceived_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            if (row != null)
            {
                ItemAnexo existingItem = itemsReceived.FirstOrDefault(x => x.CodItem == row.Cells[1].Value.ToString() && x.SerialNumber == row.Cells[2].Value.ToString());

                if (existingItem != null)
                {
                    itemsReceived.Remove(existingItem);
                }
            }
        }

        private void BtnCleanReceived_Click(object sender, EventArgs e)
        {
            dataGridViewReceived.Rows.Clear();
            TxtPickCodeReceived.Clear();
            TxtPickSerialNumReceived.Clear();
            itemsReceived.Clear();
        }


        #region Actions

        private void btnActionsReceived_Click(object sender, EventArgs e)
        {
            isMenuReceivedOpen = !isMenuReceivedOpen;

            btnActionsReceived.Text = isMenuReceivedOpen ? btnActionsReceived.Text = "   Acciones  ▲" : btnActionsReceived.Text = "   Acciones  ▼";

            timerMenu.Start();

        }

        private void btnPrintReceived_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceived.Rows.Count == 0 || (dataGridViewReceived.Rows.Count == 1 && dataGridViewReceived.AllowUserToAddRows))
            {
                MessageBox.Show(Properties.Resources.TablaVaciaImprimir, "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                PrintManager printer = new PrintManager();
                printer.PrintGrid(dataGridViewReceived, $"Recepción de {productName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.ErrorDeImpresion}: \n\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Evento asociado para generar un Excel del GridView de la Tab Recibido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelReceived_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceived.Rows.Count == 0 || (dataGridViewReceived.Rows.Count == 1 && dataGridViewReceived.AllowUserToAddRows))
            {
                MessageBox.Show(Properties.Resources.TablaVaciaExportarExcel, "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setItemsReceived();

            try
            {
                List<string> headers = new List<string>();
                bool useOpenOrangeHeaders = false;

                string message = "¿Desea exportar con los encabezados de Open Orange?\n\n" +
                    "Si: Utilizar encabezados Open Orange.\n" +
                    "No: Utilizar encabezado de la tabla.";

                if (MessageBox.Show(message, "Seleccionar encabezados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    headers.Add(AppSettings.settings.OpenOrange.ColumnUnits.name);
                    headers.Add(AppSettings.settings.OpenOrange.ColumnCode.name);
                    headers.Add(AppSettings.settings.OpenOrange.ColumnSerialNumber.name);
                    headers.Add(AppSettings.settings.OpenOrange.ColumnDueDate.name);

                    useOpenOrangeHeaders = true;
                }

                //Functions.ExportarExcelPrueba(dataGridViewReceived, "Valija", "Exportar Valija AB");
                Functions.ExportGridToExcel(dataGridViewReceived, headers, useOpenOrangeHeaders, productName, $"Exportar {productName.ToUpper()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar la valija a un Excel:\n\n{ex}", "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        /// <summary>
        /// Evento asociado para generar el Qr de la Tab Recibido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQrReceived_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceived.Rows.Count == 0 || (dataGridViewReceived.Rows.Count == 1 && dataGridViewReceived.AllowUserToAddRows))
            {
                MessageBox.Show(Properties.Resources.TablaVaciaGenerarQr, "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            setItemsReceived();

            using (FrmGenerateQr generateQr = new FrmGenerateQr())
            {
                // Pre-cargar serie si hay selección
                if (dataGridViewReceived.SelectedRows.Count != 0)
                {
                    var cell = dataGridViewReceived.SelectedRows[0].Cells["SerialNrReceived"].Value;
                    generateQr.serialNumber = cell?.ToString() ?? "";
                }

                if (generateQr.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 2. Instanciar el manager y delegar todo el trabajo
                        QRManager qrPrinter = new QRManager();

                        // Pasamos los datos del form y la lista de objetos original
                        qrPrinter.ImprimirEtiquetaValija(
                            generateQr.nameCustomer,
                            generateQr.lastNameCustomer,
                            generateQr.serialNumber,
                            itemsReceived.Cast<object>().ToList() // Convertimos a lista genérica
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Properties.Resources.ErrorGenerarQr}: \n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #endregion


        #region Result Tab

        private void BtnCleanResult_Click(object sender, EventArgs e)
        {
            dataGridViewResult.Rows.Clear();
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

        #region Actions

        private void btnActionsResult_Click(object sender, EventArgs e)
        {
            isMenuResultOpen = !isMenuResultOpen;

            btnActionsResult.Text = isMenuResultOpen ? btnActionsResult.Text = "   Acciones  ▲" : btnActionsResult.Text = "   Acciones  ▼";

            timerMenu.Start();
        }

        private void btnPrintResult_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.Rows.Count == 0 || (dataGridViewResult.Rows.Count == 1 && dataGridViewResult.AllowUserToAddRows))
            {
                MessageBox.Show(Properties.Resources.TablaVaciaImprimir, "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                PrintManager printer = new PrintManager();
                printer.PrintGrid(dataGridViewResult, $"Ingreso {productName} Open Orange");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Properties.Resources.ErrorDeImpresion}: \n\n{ex.Message}", "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnExcelResult_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.Rows.Count == 0 || (dataGridViewResult.Rows.Count == 1 && dataGridViewResult.AllowUserToAddRows))
            {
                MessageBox.Show(Properties.Resources.TablaVaciaExportarExcel, "Sin información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Functions.ExportGridToExcel(dataGridViewResult, new List<string>(), false, "Open Orange", $"Exportar {productName.ToUpper()} Open Orange");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar la valija a un Excel:\n\n{ex}", "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #endregion


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Functions.EnumerarFilasDataGrid(sender, e);
        }

        // El Timer debe estar configurado con un Interval de aprox 15ms
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            // Si estamos en el diseñador, ¡no hagas nada!
            if (this.DesignMode) return;

            if (tabControl.SelectedTab == tabControl.TabPages[1])
            {
                UpdatePanelActions(panelActionsResult, MAX_HEIGHT_RESULT, isMenuResultOpen);
                BtnCleanResult.Top = panelActionsResult.Bottom + 5;
            }
            else
            {
                UpdatePanelActions(panelActionsReceived, MAX_HEIGHT_RECEIVED, isMenuReceivedOpen);
                // Movemos el botón "Limpiar" dinámicamente según la altura actual del panel
                BtnCleanReceived.Top = panelActionsReceived.Bottom + 5;
            }
        }

        private void UpdatePanelActions(Panel panel, int MAX_HEIGHT, bool isMenuOpen)
        {
            if (isMenuOpen)
            {
                // Expandir
                panel.Height += SPEED;
                if (panel.Height >= MAX_HEIGHT)
                {
                    panel.Height = MAX_HEIGHT;
                    timerMenu.Stop();
                }
            }
            else
            {
                // Contraer
                panel.Height -= SPEED;
                if (panel.Height <= 0)
                {
                    panel.Height = 0;
                    timerMenu.Stop();
                }
            }
        }


        /// <summary>
        /// Carga la inforamción de Test. Cada clase debe sobrescribir su lógica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTests_Click(object sender, EventArgs e)
        {
            BtnTests_Virtual_Click(sender, e);
        }

        
    }
}
