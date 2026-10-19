using Control.Models.Settings;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmSettingsReportes : Form
    {
        public string movCode => txtMovCode.Text;
        public string movSerial => txtMovSerial.Text;
        public string movDate => txtMovDate.Text;
        public string movFrom => txtMovFrom.Text;
        public string movTo => txtMovTo.Text;

        public string stockCode => txtStockCode.Text;
        public string stockSerial => txtStockSerial.Text;
        public string stockDepot => txtStockDepot.Text;
        public string stockQty => txtStockQty.Text;

        public int plazoLimite => (int)numPlazoLimite.Value;

        public FrmSettingsReportes()
        {
            InitializeComponent();
        }

        private void FrmSettingsReportes_Load(object sender, EventArgs e)
        {
            try
            {
                ConsignacionSettings s = AppSettings.settings.ConsignacionReporte;

                txtMovCode.Text = s.MovColCode;
                txtMovSerial.Text = s.MovColSerial;
                txtMovDate.Text = s.MovColDate;
                txtMovFrom.Text = s.MovColFrom;
                txtMovTo.Text = s.MovColTo;

                txtStockCode.Text = s.StockColCode;
                txtStockSerial.Text = s.StockColSerial;
                txtStockDepot.Text = s.StockColDepot;
                txtStockQty.Text = s.StockColQty;

                numPlazoLimite.Value = s.PlazoLimite;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de reportes: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}