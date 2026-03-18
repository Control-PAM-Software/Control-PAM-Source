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
using System.Runtime.Intrinsics.X86;
using Newtonsoft.Json;
using Control.Models.Settings;
using Control.Models.Entities;
using Control.Logic;

namespace Control
{
    public partial class FrmRegistrationABAccesories : FrmRegistrationBase
    {
        public FrmRegistrationABAccesories()
        {
            InitializeComponent();
            this.ConfigMarca = AppSettings.settings.AccessoriesAB;
            this.isMenuResultOpen = false;
            this.isMenuReceivedOpen = false;
            this.MAX_HEIGHT_RECEIVED = 165;
            this.MAX_HEIGHT_RESULT = 110;
            this.SPEED = 12;
            this.productLine = eProductLine.AB;
            this.productName = "Accesorios AB";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelDiffAnexo.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
            panelMissItemAnexo.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);
            BtnTests.Visible = AppSettings.settings.Test;
            btnConvertLP.Visible = true;

            LoadObjects();
            LoadGridViews();
            LoadNames();
        }

        private void LoadObjects()
        {
            BtnTests.Visible = AppSettings.settings.Test;

            panelActionsReceived.Visible = true;
            panelActionsResult.Visible = true;

            this.lblSerieInputAnexo.Visible = false;
            this.TxtSerialNumProcessor.Visible = false;
        }

        private void LoadGridViews()
        {
            dataGridView1.Columns["IsAquaKit"].Visible = AppSettings.settings.OpenOrange.ColumnKit.isActive;


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

        private void LoadNames()
        {
            this.lblTitleAnexo.Text = "Ingreso Accesorios";
            this.lblTitleReceived.Text = "Accesorios";
            this.tabControl.TabPages[2].Text = "📦 Productos";
        }

        #region Anexo Tab

        protected override void btnConvertLP_Click(object sender, EventArgs e)
        {
            // Deshabilitamos temporalmente el refresco visual para mejorar el rendimiento
            dataGridView1.SuspendLayout();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Verificamos que la fila no sea la fila nueva (vacía) al final de la tabla
                if (!row.IsNewRow)
                {
                    // Accedemos a la celda por el nombre de la columna "CodItem"
                    var cell = row.Cells["CodItem"];

                    if (cell.Value != null)
                    {
                        string valorActual = cell.Value.ToString();

                        if (valorActual.EndsWith("LP"))
                        {
                            // Si ya termina en LP, lo eliminamos
                            // Quitamos los últimos 2 caracteres
                            cell.Value = valorActual.Substring(0, valorActual.Length - 2);
                        }
                        else
                        {
                            // Si no lo tiene, lo agregamos
                            cell.Value = valorActual + "LP";
                        }
                    }
                }
            }

            dataGridView1.ResumeLayout();
        }

        #endregion

        #region Received Tab

        #region Ingreso

        protected override void TxtPickCodeReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
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

        protected override void TxtPickSerialNumReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                string codeNewItem = TxtPickCodeReceived.Text.Trim().ToUpper();
                string serialNumNewItem = TxtPickSerialNumReceived.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeNewItem) && !string.IsNullOrEmpty(serialNumNewItem))
                {
                    ItemAnexo newItem = Functions.GetItemFromInput(codeNewItem, serialNumNewItem, eProductLine.AB);

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
                ("15", "CI-5293-130", "176937", ""),
                ("8", "CI-5837-200", "310050540", ""),
                ("30", "CI-5322-001", "310058367", ""),
                ("11", "CI-5322-001", "310058367", ""),
                ("10", "CI-7131-005", "310049423", ""),
                ("10", "CI-7313-001", "310050551", ""),
                ("10", "CI-5321-008", "310050553", ""),
                ("5", "CI-7131-006", "310050552", ""),
                ("5", "CI-7322", "310049414", ""),
                ("16", "CI-7323", "310050554", ""),
                ("11", "CI-5555-130", "310049307", ""),
                ("10", "CI-5555-130", "310049307", ""),
                ("15", "CI-5607", "310050549", ""),
                ("20", "CI-5615", "410322822", ""),
                ("15", "305-M160", "310050551", ""),
                ("15", "CI-5068", "118752", ""),
                ("4", "CI-7524-003", "310048895", ""),
                ("5", "CI-7524-004", "310048897", ""),
                ("5", "CI-7524-004", "310048896", ""),
                ("6", "CI-7435-001", "310050556", "")
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
