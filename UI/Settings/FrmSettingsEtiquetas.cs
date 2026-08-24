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

namespace Control.Models
{
    public partial class FrmSettingsEtiquetas : Form
    {
        public string codeEtiquetas => txtCode.Text;
        public string serieEtiquetas => txtSerie.Text;
        public string unitsEtiquetas => txtUnits.Text;
        public string despachoEtiquetas => txtDespacho.Text;

        public bool codeEtiquetasActive => chbCode.Checked;
        public bool serieEtiquetasActive => chbSerie.Checked;
        public bool unitsEtiquetasActive => chbUnits.Checked;
        public bool despachoEtiquetasActive => chbDespacho.Checked;

        public string exportPathEtiquetas => txtExportPath.Text;
        public string fileNameEtiquetas => txtFileName.Text;

        public FrmSettingsEtiquetas()
        {
            InitializeComponent();
        }

        private void FrmSettingsEtiquetas_Load(object sender, EventArgs e)
        {
            try
            {
                var etiquetas = AppSettings.settings.Etiquetas;

                txtCode.Text = etiquetas.ColumnCode.name.ToString();
                txtSerie.Text = etiquetas.ColumnSerialNumber.name.ToString();
                txtUnits.Text = etiquetas.ColumnUnits.name.ToString();
                txtDespacho.Text = etiquetas.ColumnDespacho.name.ToString();

                chbCode.Checked = etiquetas.ColumnCode.isActive;
                chbSerie.Checked = etiquetas.ColumnSerialNumber.isActive;
                chbUnits.Checked = etiquetas.ColumnUnits.isActive;
                chbDespacho.Checked = etiquetas.ColumnDespacho.isActive;

                txtExportPath.Text = etiquetas.ExportPath ?? "";
                txtFileName.Text = etiquetas.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de Etiquetas: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnBrowseExportPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccione la carpeta donde se exportarán las etiquetas";
                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrWhiteSpace(txtExportPath.Text) && Directory.Exists(txtExportPath.Text))
                {
                    dialog.SelectedPath = txtExportPath.Text;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtExportPath.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
