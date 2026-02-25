using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control.Models.Settings;

namespace Control
{
    public partial class FrmSettingsAB : Form
    {
        public string codeReceipt => txtCodeReceipt.Text;
        public string quantityReceipt => txtQtyReceipt.Text;
        public string descriptionReceipt => txtDescriptionReceipt.Text;
        public string serialReceipt => txtSerialReceipt.Text;
        public string dueDateReceipt => txtDueDateReceipt.Text;

        public string codeInventory => txtCodeInventory.Text;
        public string quantityInventory => txtQtyInventory.Text;
        public string descriptionInventory => txtDescriptionInventory.Text;
        public string serialInventory => txtSerialInventory.Text;
        public string dueDateInventory => txtDueDateInventory.Text;

        public string codeAccesories => txtCodeAccessories.Text;
        public string quantityAccesories => txtQtyAccessories.Text;
        public string descriptionAccesories => txtDescriptionAccessories.Text;
        public string serialAccesories => txtserialAccessories.Text;
        public string dueDateAccesories => txtDueDateAccessories.Text;

        //public string codeOpenOrange => txtCodeOpenOrange.Text;
        //public string qtyOpenOrange => txtQtyOpenOrange.Text;
        //public string serieOpenOrange => txtSerieOpenOrange.Text;
        //public string dueDateOpenOrange => txtDueDateOpenOrange.Text;
        //public string priceOpenOrange => txtPriceOpenOrange.Text;
        //public string batchOpenOrange => txtBatchOpenOrange.Text;
        //public string kitOpenOrange => txtKitOpenOrange.Text;
        //public bool codeOpenOrangeActive => chbCodeOpenOrange.Checked;
        //public bool qtyOpenOrangeActive => chbQtyOpenOrange.Checked;
        //public bool serieOpenOrangeActive => chbSerieOpenOrange.Checked;
        //public bool dueDateOpenOrangeActive => chbDueDateOpenOrange.Checked;
        //public bool priceOpenOrangeActive => chbPriceOpenOrange.Checked;
        //public bool batchOpenOrangeActive => chbBatchOpenOrange.Checked;
        //public bool kitOpenOrangeActive => chbKitOpenOrange.Checked;

        public FrmSettingsAB()
        {
            InitializeComponent();
        }

        private void FrmSettingsAB_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodeReceipt.Text = AppSettings.settings.ValijasAB.ColumnCode.ToString();
                txtQtyReceipt.Text = AppSettings.settings.ValijasAB.ColumnUnits.ToString();
                txtDescriptionReceipt.Text = AppSettings.settings.ValijasAB.ColumnDescription.ToString();
                txtSerialReceipt.Text = AppSettings.settings.ValijasAB.ColumnSerialNumber.ToString();
                txtDueDateReceipt.Text = AppSettings.settings.ValijasAB.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de las valijas: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeInventory.Text = AppSettings.settings.InventoryAB.ColumnCode.ToString();
                txtQtyInventory.Text = AppSettings.settings.InventoryAB.ColumnUnits.ToString();
                txtDescriptionInventory.Text = AppSettings.settings.InventoryAB.ColumnDescription.ToString();
                txtSerialInventory.Text = AppSettings.settings.InventoryAB.ColumnSerialNumber.ToString();
                txtDueDateInventory.Text = AppSettings.settings.InventoryAB.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones del inventario: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeAccessories.Text = AppSettings.settings.AccessoriesAB.ColumnCode.ToString();
                txtQtyAccessories.Text = AppSettings.settings.AccessoriesAB.ColumnUnits.ToString();
                txtDescriptionAccessories.Text = AppSettings.settings.AccessoriesAB.ColumnDescription.ToString();
                txtserialAccessories.Text = AppSettings.settings.AccessoriesAB.ColumnSerialNumber.ToString();
                txtDueDateAccessories.Text = AppSettings.settings.AccessoriesAB.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de los accesorios: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


            //try
            //{
            //    txtCodeOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnCode.name.ToString();
            //    txtQtyOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnUnits.name.ToString();
            //    txtSerieOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnSerialNumber.name.ToString();
            //    txtDueDateOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnDueDate.name.ToString();
            //    txtPriceOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnPrice.name.ToString();
            //    txtBatchOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnBatch.name.ToString();
            //    txtKitOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnKit.name.ToString();

            //    chbCodeOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnCode.isActive;
            //    chbQtyOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnUnits.isActive;
            //    chbSerieOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive;
            //    chbDueDateOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnDueDate.isActive;
            //    chbPriceOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnPrice.isActive;
            //    chbBatchOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnBatch.isActive;
            //    chbKitOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnKit.isActive;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al cargar las configuraciones de OpenOrange: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    throw;
            //}


        }
    }
}
