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
    public partial class FrmSettingsAtos : Form
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

        public FrmSettingsAtos()
        {
            InitializeComponent();
        }

        private void FrmSettingsAtos_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodeReceipt.Text = AppSettings.settings.IngresoAtos.ColumnCode.ToString();
                txtQtyReceipt.Text = AppSettings.settings.IngresoAtos.ColumnUnits.ToString();
                txtDescriptionReceipt.Text = AppSettings.settings.IngresoAtos.ColumnDescription.ToString();
                txtSerialReceipt.Text = AppSettings.settings.IngresoAtos.ColumnSerialNumber.ToString();
                txtDueDateReceipt.Text = AppSettings.settings.IngresoAtos.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de ingreso Atos: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeInventory.Text = AppSettings.settings.InventoryAtos.ColumnCode.ToString();
                txtQtyInventory.Text = AppSettings.settings.InventoryAtos.ColumnUnits.ToString();
                txtDescriptionInventory.Text = AppSettings.settings.InventoryAtos.ColumnDescription.ToString();
                txtSerialInventory.Text = AppSettings.settings.InventoryAtos.ColumnSerialNumber.ToString();
                txtDueDateInventory.Text = AppSettings.settings.InventoryAtos.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones del inventario: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
