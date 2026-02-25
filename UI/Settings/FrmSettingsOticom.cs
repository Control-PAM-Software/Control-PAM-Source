using Control.Models.Settings;
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
    public partial class FrmSettingsOticom : Form
    {
        public string codeInventory => txtCodeInventory.Text;
        public string quantityInventory => txtQtyInventory.Text;
        public string descriptionInventory => txtDescriptionInventory.Text;
        public string serialInventory => txtSerialInventory.Text;
        public string dueDateInventory => txtDueDateInventory.Text;

        public string codeReceipt => txtCodeReceipt.Text;
        public string quantityReceipt => txtQtyReceipt.Text;
        public string descriptionReceipt => txtDescriptionReceipt.Text;
        public string serialReceipt => txtSerialReceipt.Text;
        public string dueDateReceipt => txtDueDateReceipt.Text;

        public FrmSettingsOticom()
        {
            InitializeComponent();
        }

        private void FrmSettingsOticom_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodeReceipt.Text = AppSettings.settings.IngresoOticom.ColumnCode.ToString();
                txtQtyReceipt.Text = AppSettings.settings.IngresoOticom.ColumnUnits.ToString();
                txtDescriptionReceipt.Text = AppSettings.settings.IngresoOticom.ColumnDescription.ToString();
                txtSerialReceipt.Text = AppSettings.settings.IngresoOticom.ColumnSerialNumber.ToString();
                txtDueDateReceipt.Text = AppSettings.settings.IngresoOticom.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de ingreso Atos: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeInventory.Text = AppSettings.settings.InventoryOticom.ColumnCode.ToString();
                txtQtyInventory.Text = AppSettings.settings.InventoryOticom.ColumnUnits.ToString();
                txtDescriptionInventory.Text = AppSettings.settings.InventoryOticom.ColumnDescription.ToString();
                txtSerialInventory.Text = AppSettings.settings.InventoryOticom.ColumnSerialNumber.ToString();
                txtDueDateInventory.Text = AppSettings.settings.InventoryOticom.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones del inventario: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
