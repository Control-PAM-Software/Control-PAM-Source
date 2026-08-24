using Control.Logic;
using Control.Models.Entities;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmRegistrationAtos : FrmRegistrationBase
    {

        public FrmRegistrationAtos() : base()
        {
            InitializeComponent();
            this.ConfigMarca = AppSettings.settings.IngresoAtos;
            this.btnQrReceived.Visible = false;
            this.isMenuResultOpen = false;
            this.isMenuReceivedOpen = false;
            this.MAX_HEIGHT_RECEIVED = 110;
            this.MAX_HEIGHT_RESULT = 110;
            this.SPEED = 12;
            this.productLine = eProductLine.Atos;
            this.productName = "Atos";
        }

        private void FrmRegistrationAtos_Load(object sender, EventArgs e)
        {
            LoadGridViews();
            LoadNames();

            this.BtnHasPila.Visible = false;
            this.lblSerieInputReceived.Visible = false;
            this.TxtPickSerialNumReceived.Visible = false;
            this.lblSerieInputAnexo.Visible = false;
            this.TxtSerialNumProcessor.Visible = false;
        }

        private void LoadNames()
        {
            this.lblTitleAnexo.Text = "Ingreso Atos";
            this.lblTitleReceived.Text = "Productos";
            this.tabControl.TabPages[2].Text = "📦 Productos";
        }

        protected override void LoadGridViews()
        {
            base.LoadGridViews(); // Esto ya configura todas las columnas comunes (OpenOrange)

            // Ahora solo pon lo que cambia en Atos:
            this.dataGridView1.Columns["IsAquaKit"].Visible = false;
            dataGridViewResult.Columns["ColumnKitResult"].Visible = false;
        }

        #region Received


        protected override void TxtPickCodeReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                string codeInput = TxtPickCodeReceived.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeInput))
                {
                    ItemAnexo? newItem = Functions.GetItemFromInput(codeInput, eProductLine.Atos);

                    if (newItem != null)
                    {
                        AddNewItem(newItem);
                        ReloadDataGridViewReceived();
                        TxtPickCodeReceived.Focus();
                        TxtPickCodeReceived.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener la información del producto.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        #endregion

        protected override void BtnTests_Virtual_Click(object sender, EventArgs e)
        {
            items = new List<ItemAnexo> {
                new ItemAnexo("7204", "", "2405006", 35, "27/05/2029"),
                new ItemAnexo("7248", "", "2508072", 3, "31/03/2028"),
                new ItemAnexo("7248", "", "2508296", 16, "31/03/2028"),
                new ItemAnexo("7248", "", "2510367", 1, "31/08/2028"),
                new ItemAnexo("7260", "", "2506158", 25, "31/03/2028"),
                new ItemAnexo("7270", "", "2505137", 10, "30/04/2030"),
                new ItemAnexo("7271", "", "2509148", 6, "31/08/2030"),
                new ItemAnexo("7271", "", "2509148", 1, "31/08/2030"),
                new ItemAnexo("7271", "", "2511311", 13, "31/10/2030"),
                new ItemAnexo("7290", "", "2504246", 300, "31/03/2028"),
                new ItemAnexo("7290", "", "2504244", 1500, "31/03/2028"),
                new ItemAnexo("7291", "", "2506006", 300, "30/04/2028"),
                new ItemAnexo("7291", "", "2510011", 4500, "31/08/2028"),
                new ItemAnexo("7601", "", "2510095", 3, "31/08/2028"),
                new ItemAnexo("7602", "", "2509048", 15, "31/07/2028"),
                new ItemAnexo("7603", "", "2510026", 10, "31/07/2028"),
                new ItemAnexo("7605", "", "2507008", 6, "31/03/2028"),
                new ItemAnexo("7606", "", "2506170", 20, "31/01/2028"),
                new ItemAnexo("7607", "", "2510066", 20, "31/08/2028"),
                new ItemAnexo("7610", "", "2510103", 15, "31/08/2028"),
                new ItemAnexo("7611", "", "2510104", 15, "31/08/2028"),
                new ItemAnexo("7615", "", "2506027", 10, "31/03/2028"),
                new ItemAnexo("7668", "", "2520013", 90, "12/05/2030"),
                new ItemAnexo("7671", "", "2506030", 5, "31/05/2030"),
                new ItemAnexo("7672", "", "2507066", 5, "30/06/2030"),
                new ItemAnexo("7673", "", "2505053", 5, "30/04/2030"),
                new ItemAnexo("7674", "", "2503103", 5, "28/02/2030"),
                new ItemAnexo("8013", "", "2503110", 270, "31/12/2026"),
                new ItemAnexo("8109", "", "2509058", 10, "31/08/2030"),
                new ItemAnexo("8129", "", "2510135", 20, "30/09/2030"),
                new ItemAnexo("8139", "", "2510136", 5, "30/09/2030"),
                new ItemAnexo("8139", "", "2511140", 10, "31/10/2030"),
                new ItemAnexo("8144", "", "2509205", 13, "31/05/2030"),
                new ItemAnexo("8145", "", "2510168", 5, "30/06/2030"),
                new ItemAnexo("8145", "", "2509214", 5, "30/06/2030"),
                new ItemAnexo("8145", "", "2510150", 1, "30/06/2030"),
                new ItemAnexo("8145", "", "2508181", 1, "30/06/2030"),
                new ItemAnexo("8147", "", "2501139", 4, "31/10/2029"),
                new ItemAnexo("8147", "", "2502099", 6, "30/11/2029"),
                new ItemAnexo("8161", "", "2509119", 11, "30/06/2028"),
                new ItemAnexo("8162", "", "2510231", 3, "31/08/2028"),
                new ItemAnexo("8162", "", "2511114", 13, "31/08/2028"),
                new ItemAnexo("8221", "", "2510369", 150, "30/09/2028"),
                new ItemAnexo("8221", "", "2508081", 450, "31/07/2028"),
                new ItemAnexo("8278", "", "2510387", 10, "31/08/2030"),
                new ItemAnexo("8283", "", "2510155", 10, "30/06/2030"),
                new ItemAnexo("8284", "", "2509213", 20, "30/06/2030"),
                new ItemAnexo("8301", "", "2510325", 2, "30/06/2030"),
                new ItemAnexo("8301", "", "2510293", 8, "30/06/2030"),
                new ItemAnexo("8303", "", "2510206", 15, "30/06/2030"),
                new ItemAnexo("7796", "", "2505033", 1, "31/08/2027"),
                new ItemAnexo("7796", "", "2511145", 19, "31/08/2027"),
                new ItemAnexo("7797", "", "2505034", 20, "30/06/2027"),
                new ItemAnexo("8013", "", "2510197", 30, "31/08/2028"),
                new ItemAnexo("8302", "", "2510171", 20, "30/06/2030"),
                new ItemAnexo("8277", "", "2510081", 3, "30/06/2030"),
                new ItemAnexo("8279", "", "2510257", 20, "31/08/2030"),
                new ItemAnexo("8280", "", "2510217", 5, "31/08/2030"),
                new ItemAnexo("8285", "", "2509182", 10, "30/06/2030"),
                new ItemAnexo("8286", "", "2508269", 5, "31/05/2030"),
                new ItemAnexo("8296", "", "2510110", 15, "30/06/2030"),
                new ItemAnexo("8297", "", "2510111", 10, "30/06/2030")
            };

            dataGridViewReceived.Rows.Clear();
            itemsEtiquetas.Clear(); // El botón de pruebas también carga el acumulador interno de etiquetas

            foreach (var item in items)
            {
                AddToLabelAccumulator(item);

                dataGridViewReceived.Rows.Add(
                    item.Quantity,
                    item.CodItem,
                    item.SerialNumber,
                    item.DueDate
                );
            }
        }

        
    }

}
