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
                        existingItem.Quantity += 1;
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
                ("1", "CI-5293-120", "233273", "31/08/2030"),
                ("1", "CI-5837-200", "310134546", "30/11/2029"),
                ("1", "CI-5320-001", "310134550", "30/12/2031"),
                ("1", "CI-5320-001", "310134549", "30/06/2029"),
                ("1", "CI-7131-004", "310134551", "30/07/2031"),
                ("1", "CI-7313-001", "310134556", ""),
                ("1", "CI-5321-008", "310163463", ""),
                ("1", "CI-7131-006", "310163487", ""),
                ("1", "CI-7323", "310163489", ""),
                ("1", "CI-7525-003", "310163250", ""),
                ("1", "CI-7525-004", "310163439", ""),
                ("1", "CI-7525-004", "310163424", ""),
                ("1", "CI-5555-120", "310138473", ""),
                ("1", "CI-5555-120", "310138472", ""),
                ("1", "CI-5607", "310139874", ""),
                ("1", "CI-5615", "310134557", ""),
                ("1", "305-Q160", "310134555", ""),
                ("1", "CI-5068", "134042", ""),
                ("1", "CI-7435-001", "310163490", ""),
                ("1", "CI-5293-120", "233273", "31/08/2030"),
                ("1", "CI-5837-200", "310134546", "30/11/2029"),
                ("1", "CI-5320-001", "310134550", "30/12/2031"),
                ("1", "CI-5320-001", "310134549", "30/06/2029"),
                ("1", "CI-7131-004", "310134551", "30/07/2031"),
                ("1", "CI-7313-001", "310134556", ""),
                ("1", "CI-5321-008", "310163463", ""),
                ("1", "CI-7131-006", "310163487", ""),
                ("1", "CI-7323", "310163489", ""),
                ("1", "CI-7525-003", "310163250", ""),
                ("1", "CI-7525-004", "310163439", ""),
                ("1", "CI-7525-004", "310163424", ""),
                ("1", "CI-5555-120", "310138473", ""),
                ("1", "CI-5555-120", "310138472", ""),
                ("1", "CI-5607", "310139874", ""),
                ("1", "CI-5615", "310134557", ""),
                ("1", "305-Q160", "310134555", ""),
                ("1", "CI-5068", "134042", ""),
                ("1", "CI-7435-001", "310163490", "")
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
