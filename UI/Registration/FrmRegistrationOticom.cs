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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmRegistrationOticom : FrmRegistrationBase
    {
        int aux = 0; //  Para Test

        List<ItemAnexo> itemsTest = new List<ItemAnexo>();

        public FrmRegistrationOticom() : base()
        {
            InitializeComponent();
            this.ConfigMarca = AppSettings.settings.IngresoOticom;
            this.btnQrReceived.Visible = false;
            this.isMenuResultOpen = false;
            this.isMenuReceivedOpen = false;
            this.MAX_HEIGHT_RECEIVED = 110;
            this.MAX_HEIGHT_RESULT = 110;
            this.SPEED = 12;
            this.productLine = eProductLine.Oticom;
            this.productName = "Oticom";
        }

        private void FrmRegistrationOticom_Load(object sender, EventArgs e)
        {
            LoadGridViews();
            LoadNames();

            this.BtnHasPila.Visible = false;
            this.lblSerieInputAnexo.Visible = false;
            this.TxtSerialNumProcessor.Visible = false;
        }

        private void LoadNames()
        {
            this.lblTitleAnexo.Text = "Ingreso Oticom";
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


        #region Resultado

        //private void BtnCopyResult_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewResult.Rows.Count == 0)
        //    {
        //        MessageBox.Show("La tabla aún no fue generada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    Functions.CopyGridViewResult(dataGridViewResult);
        //}

        //private void BtnCleanResult_Click(object sender, EventArgs e)
        //{
        //    dataGridViewResult.Rows.Clear();
        //}

        #endregion

        #region Recibido

        protected override void TxtPickCodeReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                TxtPickSerialNumReceived.Focus();
            }            
        }

        protected override void TxtPickSerialNumReceived_Virtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                try
                {
                    string codeInput = TxtPickCodeReceived.Text.Trim().ToUpper();
                    string serialInput = TxtPickSerialNumReceived.Text.Trim().ToUpper();

                    ItemAnexo? itemInput = Functions.GetItemFromInput(codeInput, serialInput, eProductLine.Oticom);

                    if (itemInput != null)
                    {
                        AddNewItem(itemInput);

                        TxtPickCodeReceived.Focus();
                        TxtPickCodeReceived.Clear();
                        TxtPickSerialNumReceived.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener la información del producto.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al obtener la información del producto.", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
             #endregion

        protected override void BtnTests_Virtual_Click(object sender, EventArgs e)
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
                    0,
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


    }

}
