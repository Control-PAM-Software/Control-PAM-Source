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
    public partial class FrmSettingsInomed : Form
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

        public FrmSettingsInomed()
        {
            InitializeComponent();
        }

        private void FrmSettingsInomed_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodeReceipt.Text = AppSettings.settings.IngresoInomed.ColumnCode.ToString();
                txtQtyReceipt.Text = AppSettings.settings.IngresoInomed.ColumnUnits.ToString();
                txtDescriptionReceipt.Text = AppSettings.settings.IngresoInomed.ColumnDescription.ToString();
                txtSerialReceipt.Text = AppSettings.settings.IngresoInomed.ColumnSerialNumber.ToString();
                txtDueDateReceipt.Text = AppSettings.settings.IngresoInomed.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de ingreso Atos: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeInventory.Text = AppSettings.settings.InventoryInomed.ColumnCode.ToString();
                txtQtyInventory.Text = AppSettings.settings.InventoryInomed.ColumnUnits.ToString();
                txtDescriptionInventory.Text = AppSettings.settings.InventoryInomed.ColumnDescription.ToString();
                txtSerialInventory.Text = AppSettings.settings.InventoryInomed.ColumnSerialNumber.ToString();
                txtDueDateInventory.Text = AppSettings.settings.InventoryInomed.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones del inventario: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
