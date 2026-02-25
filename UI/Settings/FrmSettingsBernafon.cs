using Control.Logic;
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
    public partial class FrmSettingsBernafon : Form
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

        public string codeMovements => txtCodeMovements.Text;
        public string quantityMovements => txtQtyMovements.Text;
        public DataGridView CodigosDesglose => gdvCodigosDesglose;

        public FrmSettingsBernafon()
        {
            InitializeComponent();
        }

        private void FrmSettingsBernafon_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodeReceipt.Text = AppSettings.settings.IngresoBernafon.ColumnCode.ToString();
                txtQtyReceipt.Text = AppSettings.settings.IngresoBernafon.ColumnUnits.ToString();
                txtDescriptionReceipt.Text = AppSettings.settings.IngresoBernafon.ColumnDescription.ToString();
                txtSerialReceipt.Text = AppSettings.settings.IngresoBernafon.ColumnSerialNumber.ToString();
                txtDueDateReceipt.Text = AppSettings.settings.IngresoBernafon.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de ingreso Bernafon: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeInventory.Text = AppSettings.settings.InventoryBernafon.ColumnCode.ToString();
                txtQtyInventory.Text = AppSettings.settings.InventoryBernafon.ColumnUnits.ToString();
                txtDescriptionInventory.Text = AppSettings.settings.InventoryBernafon.ColumnDescription.ToString();
                txtSerialInventory.Text = AppSettings.settings.InventoryBernafon.ColumnSerialNumber.ToString();
                txtDueDateInventory.Text = AppSettings.settings.InventoryBernafon.ColumnDueDate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones del inventario de Bernafon: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                txtCodeMovements.Text = AppSettings.settings.MovementsBernafon.ColumnCode.ToString();
                txtQtyMovements.Text = AppSettings.settings.MovementsBernafon.ColumnUnits.ToString();

                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de movimientos de Bernafon: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void LoadGridView()
        {
            List<string> codesDesglose = AppSettings.settings.MovementsBernafon.Codigos_Desglose.Split(';').ToList();

            FillDataGridView(codesDesglose);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string codesDesglose = AppSettings.settings.MovementsBernafon.Codigos_Desglose;

            if (string.IsNullOrEmpty(codesDesglose))
                return;

            SaveFileTxt(codesDesglose);

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string? codesDesglose = ReadFileTxt();

            if (string.IsNullOrEmpty(codesDesglose)) 
                return;

            List<string> codes = codesDesglose.Split(";").ToList();

            FillDataGridView(codes);
        }

        private void SaveFileTxt(string pSettings)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                    saveFileDialog.Title = "Guardar archivo";
                    saveFileDialog.FileName = "Movimientos Bernafon.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, pSettings);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al exportar los códigos de desglose.", "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ReadFileTxt()
        {
            try
            {            
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                    openFileDialog.Title = "Seleccionar archivo";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return File.ReadAllText(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al importar los códigos de desglose.", "Error de importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // usuario canceló
        }

        private void FillDataGridView(List<string> pCodes)
        {
            if (pCodes.All(x => string.IsNullOrEmpty(x)))
                return;

            int line = 0;
            foreach (string code in pCodes)
            {
                gdvCodigosDesglose.Rows.Add();
                gdvCodigosDesglose.Rows[line].Cells["ArtCode"].Value = code;
                line++;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Functions.EnumerarFilasDataGrid(sender, e);
        }

    }
}
