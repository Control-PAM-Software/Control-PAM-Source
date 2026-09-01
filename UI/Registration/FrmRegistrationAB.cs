using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ExcelDataReader;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using static QRCoder.PayloadGenerator.SwissQrCode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using DrawingColor = System.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing.Printing;
using Newtonsoft.Json;
using QRCoder;
using Control.Models.Settings;
using Control.Models.Entities;
using Control.Logic;
using System.Drawing;
using Control.Models.Responses;
using Control.UI.Registration;

namespace Control
{
    public partial class FrmRegistrationAB : FrmRegistrationBase
    {
        public FrmRegistrationAB() : base()
        {
            InitializeComponent();
            this.ConfigMarca = AppSettings.settings.ValijasAB;
            this.isMenuResultOpen = false;
            this.isMenuReceivedOpen = false;
            this.MAX_HEIGHT_RECEIVED = 165;
            this.MAX_HEIGHT_RESULT = 110;
            this.SPEED = 12;
            this.productLine = eProductLine.AB;
            this.productName = "Valija AB";
            this.groupItems = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGridViews();

            this.lblSerieInputAnexo.Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;
            this.TxtSerialNumProcessor.Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;
        }


        private void LoadGridViews()
        {
            dataGridView1.Columns["IsAquaKit"].Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;
        }

        #region Anexo

        /// <summary>
        /// Método virtual sobrescrito del botón Comparar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnCompare_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Procesa la comparación de Anexo vs Valija
        /// </summary>
        private void compareItems()
        {
            ComparisonResult compareData = InventoryComparer.CompareLists(items, itemsReceived);

            showErrorsInDataGridView(compareData);

            if (compareData.IsComparisonCorrect())
            {
                MessageBox.Show("Todos los artículos están correctos", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                // 3. Si hay sobrantes, abrimos el nuevo formulario
                if (compareData.ExtraItems.Count > 0)
                {
                    using (var frmExtras = new FrmExtraItems(compareData.ExtraItems))
                    {
                        if (frmExtras.ShowDialog() == DialogResult.OK)
                        {
                            // El usuario eligió incluirlos
                            IncludeExtraItemsInGrid(compareData.ExtraItems);
                            return;
                        }
                    }
                }

                MessageBox.Show("Conciliación finalizada con diferencias. Revise la grilla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void IncludeExtraItemsInGrid(List<ItemAnexo> extras)
        {
            foreach (var item in extras)
            {
                // Agregamos a la lista que alimenta la grilla
                // Si tu grilla es manual (dgv.Rows.Add), usa la lógica comentada abajo
                dataGridView1.Rows.Add(
                    item.IsAquaKit,
                    item.Quantity.ToString(),
                    item.CodItem,
                    item.Description,
                    item.SerialNumber,
                    item.DueDate
                );
            }

            // Refrescamos el binding si es necesario
            // bindingSource.ResetBindings(false); 

            // Pintamos las nuevas filas de un color distintivo (ej. Naranja para Sobrantes)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var cod = row.Cells["CodItem"].Value?.ToString();
                var sn = row.Cells["SerialNumber"].Value?.ToString();

                // Si este item está en la lista de extras que acabamos de agregar
                if (extras.Any(x => x.CodItem == cod && x.SerialNumber == sn))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSalmon; // Color para ítems agregados manualmente
                    setToolTip(row, "Ítem agregado automáticamente desde la Valija (Sobrante).");
                }
            }
        }

        /// <summary>
        /// Pinta las filas según diferencias/faltantes/correctos.
        /// </summary>
        /// <param name="compareData">Objeto resultado de la comparación entre Anexo vs Valija.</param>
        private void showErrorsInDataGridView(ComparisonResult compareData)
        {
            // 1. Agrupamos los resultados por una clave única para saber cuántas unidades de cada tipo de estado tenemos
            var statusDict = new Dictionary<string, UIAggregateStatus>(StringComparer.OrdinalIgnoreCase);

            UIAggregateStatus GetStatus(ItemAnexo item)
            {
                string key = $"{item.CodItem}|{item.SerialNumber}|{item.DueDate}";
                if (!statusDict.TryGetValue(key, out var st))
                {
                    st = new UIAggregateStatus();
                    statusDict[key] = st;
                }
                return st;
            }

            // Contabilizamos las unidades Faltantes
            foreach (var m in compareData.MissingItems)
                GetStatus(m).MissingQty += m.Quantity;

            // Contabilizamos las unidades Correctas
            foreach (var c in compareData.CorrectItems)
                GetStatus(c).CorrectQty += c.Quantity;

            // Contabilizamos las unidades con Diferencias (Mismatched)
            foreach (var m in compareData.MismatchedItems)
            {
                var st = GetStatus(m.Expected);
                st.MismatchedQty += m.Expected.Quantity;
                if (m.SerialNumberDiffers) st.SerialDiffers = true;
                if (m.QuantityDiffers) st.QtyDiffers = true;
                if (m.DueDateDiffers) st.DueDateDiffers = true;
            }

            // 2. Recorremos la grilla y "consumimos" los estados
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string codItem = row.Cells["CodItem"].Value?.ToString() ?? "";
                string serialNumber = row.Cells["SerialNumber"].Value?.ToString() ?? "";
                string dueDate = row.Cells["DueDate"].Value?.ToString() ?? "";

                // Obtenemos la cantidad de esta fila específica en la grilla
                decimal rowQty = 0;
                if (row.Cells["QuantityItem"].Value != null)
                    decimal.TryParse(row.Cells["QuantityItem"].Value.ToString(), out rowQty);

                string key = $"{codItem}|{serialNumber}|{dueDate}";

                // Si no hay registro en nuestro diccionario, lo marcamos como correcto por defecto
                if (!statusDict.TryGetValue(key, out var st))
                {
                    ResetRowColor(row);
                    continue;
                }

                // 3. Lógica de consumo en cascada para la fila
                decimal missingInRow = Math.Min(rowQty, st.MissingQty);
                st.MissingQty -= missingInRow;
                rowQty -= missingInRow;

                decimal mismatchedInRow = Math.Min(rowQty, st.MismatchedQty);
                st.MismatchedQty -= mismatchedInRow;
                rowQty -= mismatchedInRow;

                decimal correctInRow = Math.Min(rowQty, st.CorrectQty);
                st.CorrectQty -= correctInRow;
                rowQty -= correctInRow;

                // 4. Pintamos y asignamos Tooltip según el "peor" caso de la fila
                if (missingInRow > 0)
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);

                    string tooltip = $"Faltan {missingInRow} unidad(es).";
                    if (mismatchedInRow > 0)
                        tooltip += $" Además, {mismatchedInRow} unidad(es) con diferencias.";

                    setToolTip(row, tooltip);
                }
                else if (mismatchedInRow > 0)
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);

                    string tooltip = $"Diferencias en {mismatchedInRow} unidad(es): ";
                    if (st.SerialDiffers) tooltip += "N° de Serie, ";
                    if (st.QtyDiffers) tooltip += "Cantidad, ";
                    if (st.DueDateDiffers) tooltip += "Vencimiento, ";

                    setToolTip(row, tooltip.TrimEnd(',', ' '));
                }
                else
                {
                    ResetRowColor(row);
                }
            }
        }

        // Función auxiliar para dejar la fila por defecto
        private void ResetRowColor(DataGridViewRow row)
        {
            row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
            setToolTip(row, string.Empty);
        }

        // Tu función setToolTip se mantiene igual, pero te sugiero asegurarte de que las celdas existan para evitar NullReferenceExceptions
        public void setToolTip(DataGridViewRow row, string tooltip)
        {
            if (row.Cells["CodItem"] != null) row.Cells["CodItem"].ToolTipText = tooltip;
            if (row.Cells["IsAquaKit"] != null) row.Cells["IsAquaKit"].ToolTipText = tooltip;
            if (row.Cells["QuantityItem"] != null) row.Cells["QuantityItem"].ToolTipText = tooltip;
            if (row.Cells["DescriptionItem"] != null) row.Cells["DescriptionItem"].ToolTipText = tooltip;
            if (row.Cells["SerialNumber"] != null) row.Cells["SerialNumber"].ToolTipText = tooltip;
            if (row.Cells["DueDate"] != null) row.Cells["DueDate"].ToolTipText = tooltip;
        }

        // Clase auxiliar necesaria para agrupar los resultados
        private class UIAggregateStatus
        {
            public decimal MissingQty { get; set; } = 0;
            public decimal MismatchedQty { get; set; } = 0;
            public decimal CorrectQty { get; set; } = 0;
            public bool SerialDiffers { get; set; } = false;
            public bool QtyDiffers { get; set; } = false;
            public bool DueDateDiffers { get; set; } = false;
        }

        #endregion


        #region Received Tab

        #region Ingreso

        /// <summary>
        /// Método virtual sobrescrito para procesar input sobre textBox código de tab Valija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void TxtPickCodeReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                // En caso de ser >15 se trata de lectura de Qr
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

                        itemsReceived.Add(newItem);
                    }
                    ReloadDataGridViewReceived();
                    TxtPickCodeReceived.Clear();
                    TxtPickCodeReceived.Focus();
                }
                else // Si es código normal pongo el focus en textBox del número de serie para que el usuario lo pickee
                {
                    TxtPickSerialNumReceived.Focus();
                }
            }
        }
        /// <summary>
        /// Método virtual sobrescrito para procesar input sobre textBox número de serie de tab Valija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void TxtPickSerialNumReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                string codeNewItem = TxtPickCodeReceived.Text.Trim().ToUpper();
                string serialNumNewItem = TxtPickSerialNumReceived.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeNewItem) && !string.IsNullOrEmpty(serialNumNewItem))
                {
                    ItemAnexo newItem = Functions.GetItemFromInput(codeNewItem, serialNumNewItem, eProductLine.AB);
                    
                    itemsReceived.Add(newItem);                    

                    ReloadDataGridViewReceived();

                    TxtPickCodeReceived.Focus();
                    TxtPickCodeReceived.Clear();
                    TxtPickSerialNumReceived.Clear();
                }

            }
        }

        #endregion

        #endregion

        protected override void BtnTests_Virtual_Click(object sender, EventArgs e)
        {
            // Limpiar filas existentes
            dataGridViewReceived.Rows.Clear();
            itemsReceived.Clear();

            // Lista hardcodeada en base a la imagen
            var items = new List<(string unidades, string codigo, string serie, string vencimiento)>
            {
                ("2", "CI-5293-120", "233273", "31/08/2030"),
                ("2", "CI-5837-200", "310134546", "30/11/2029"),
                ("2", "CI-5320-001", "310134550", "30/12/2031"),
                ("2", "CI-5320-001", "310134549", "30/06/2029"),
                ("2", "CI-7131-004", "310134551", "30/07/2031"),
                ("2", "CI-7313-001", "310134556", ""),
                ("2", "CI-5321-008", "310163463", ""),
                ("2", "CI-7131-006", "310163487", ""),
                ("2", "CI-7323", "310163489", ""),
                ("2", "CI-7525-003", "310163250", ""),
                ("2", "CI-7525-004", "310163439", ""),
                ("2", "CI-7525-004", "310163424", ""),
                ("2", "CI-5555-120", "310138473", ""),
                ("2", "CI-5555-120", "310138472", ""),
                ("2", "CI-5607", "310139874", ""),
                ("2", "CI-5615", "310134557", ""),
                ("2", "305-Q160", "310134555", ""),
                ("2", "CI-5068", "134042", ""),
                ("2", "CI-7435-001", "310163490", "")
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
