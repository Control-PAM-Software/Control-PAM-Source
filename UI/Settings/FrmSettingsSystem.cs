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
    public partial class FrmSettingsSystem : Form
    {
        public string ArticlePriceValue => txtArticlePrice.Text;

        #region Open Orange

        public string codeOpenOrange => txtCodeOpenOrange.Text;
        public string qtyOpenOrange => txtQtyOpenOrange.Text;
        public string serieOpenOrange => txtSerieOpenOrange.Text;
        public string dueDateOpenOrange => txtDueDateOpenOrange.Text;
        public string priceOpenOrange => txtPriceOpenOrange.Text;
        public string batchOpenOrange => txtBatchOpenOrange.Text;
        public string kitOpenOrange => txtKitOpenOrange.Text;
        public bool codeOpenOrangeActive => chbCodeOpenOrange.Checked;
        public bool qtyOpenOrangeActive => chbQtyOpenOrange.Checked;
        public bool serieOpenOrangeActive => chbSerieOpenOrange.Checked;
        public bool dueDateOpenOrangeActive => chbDueDateOpenOrange.Checked;
        public bool priceOpenOrangeActive => chbPriceOpenOrange.Checked;
        public bool batchOpenOrangeActive => chbBatchOpenOrange.Checked;
        public bool kitOpenOrangeActive => chbKitOpenOrange.Checked;

        #endregion

        public FrmSettingsSystem()
        {
            InitializeComponent();
        }

        private void FrmSettingSystem_Load(object sender, EventArgs e)
        {
            PanelColorDiffSetting.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
            PanelMissItemColorSetting.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);

            txtArticlePrice.Text = AppSettings.settings.ArticlePrice;

            try
            {
                txtCodeOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnCode.name.ToString();
                txtQtyOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnUnits.name.ToString();
                txtSerieOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnSerialNumber.name.ToString();
                txtDueDateOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnDueDate.name.ToString();
                txtPriceOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnPrice.name.ToString();
                txtBatchOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnBatch.name.ToString();
                txtKitOpenOrange.Text = AppSettings.settings.OpenOrange.ColumnKit.name.ToString();

                chbCodeOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnCode.isActive;
                chbQtyOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnUnits.isActive;
                chbSerieOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive;
                chbDueDateOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnDueDate.isActive;
                chbPriceOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnPrice.isActive;
                chbBatchOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnBatch.isActive;
                chbKitOpenOrange.Checked = AppSettings.settings.OpenOrange.ColumnKit.isActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de OpenOrange: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnChangeDiffColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color colorSelected = colorDialog.Color;
                    try
                    {
                        AppSettings.settings.ColorDifferences = ColorTranslator.ToHtml(colorSelected);
                        AppSettings.saveSettings();
                        PanelColorDiffSetting.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorDifferences);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hubo un error al guardar la configuración.");
                    }
                }
            }
        }

        private void btnChangeMissItemColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color colorSelected = colorDialog.Color;
                    try
                    {
                        AppSettings.settings.ColorMissingItem = ColorTranslator.ToHtml(colorSelected);
                        AppSettings.saveSettings();
                        PanelMissItemColorSetting.BackColor = ColorTranslator.FromHtml(AppSettings.settings.ColorMissingItem);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hubo un error al guardar la configuración.");
                    }
                }
            }
        }

    }
}
