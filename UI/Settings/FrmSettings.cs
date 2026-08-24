using Control.Models;
using Control.Models.Settings;
using System;
using System.CodeDom;
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
    public partial class FrmSettings : Form
    {
        Form activeForm = null;

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            showPanel(new FrmSettingsSystem());

        }

        private void btnSaveChangesSettings_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        #region Settings – Change Validation

        // Compare form info with XML setting info
        private bool hasSettingsChanged()
        {
            switch (activeForm)
            {
                case FrmSettingsSystem:
                    return hasSettingsSystemChanged();
                case FrmSettingsAB:
                    return hasSettingsABChanged();
                case FrmSettingsAtos:
                    return hasSettingsAtosChanged();
                case FrmSettingsBernafon:
                    return hasSettingsBernafonChanged();
                case FrmSettingsInomed:
                    return hasSettingsInomedChanged();
                case FrmSettingsOticom:
                    return hasSettingsOticomChanged();
                case FrmSettingsEtiquetas:
                    return hasSettingsEtiquetasChanged();
                default:
                    return false;
            }
        }

        private bool hasSettingsSystemChanged()
        {
            if (activeForm is FrmSettingsSystem frm)
            {
                return AppSettings.settings.ArticlePrice != frm.ArticlePriceValue.Trim() ||

                    AppSettings.settings.OpenOrange.ColumnCode.name != frm.codeOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnUnits.name != frm.qtyOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnSerialNumber.name != frm.serieOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnDueDate.name != frm.dueDateOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnPrice.name != frm.priceOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnBatch.name != frm.batchOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnKit.name != frm.kitOpenOrange.Trim() ||
                    AppSettings.settings.OpenOrange.ColumnCode.isActive != frm.codeOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnUnits.isActive != frm.qtyOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive != frm.serieOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnDueDate.isActive != frm.dueDateOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnPrice.isActive != frm.priceOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnBatch.isActive != frm.batchOpenOrangeActive ||
                    AppSettings.settings.OpenOrange.ColumnKit.isActive != frm.kitOpenOrangeActive;
            }
            return false;
        }

        private bool hasSettingsABChanged()
        {
            if (activeForm is FrmSettingsAB frm)
            {
                return
                    AppSettings.settings.ValijasAB.ColumnCode != frm.codeReceipt.Trim() ||
                    AppSettings.settings.ValijasAB.ColumnUnits != frm.quantityReceipt.Trim() ||
                    AppSettings.settings.ValijasAB.ColumnDescription != frm.descriptionReceipt.Trim() ||
                    AppSettings.settings.ValijasAB.ColumnSerialNumber != frm.serialReceipt.Trim() ||
                    AppSettings.settings.ValijasAB.ColumnDueDate != frm.dueDateReceipt.Trim() ||

                    AppSettings.settings.InventoryAB.ColumnCode != frm.codeInventory.Trim() ||
                    AppSettings.settings.InventoryAB.ColumnUnits != frm.quantityInventory.Trim() ||
                    AppSettings.settings.InventoryAB.ColumnDescription != frm.descriptionInventory.Trim() ||
                    AppSettings.settings.InventoryAB.ColumnSerialNumber != frm.serialInventory.Trim() ||
                    AppSettings.settings.InventoryAB.ColumnDueDate != frm.dueDateInventory.Trim() ||

                    AppSettings.settings.AccessoriesAB.ColumnCode != frm.codeAccesories.Trim() ||
                    AppSettings.settings.AccessoriesAB.ColumnUnits != frm.quantityAccesories.Trim() ||
                    AppSettings.settings.AccessoriesAB.ColumnDescription != frm.descriptionAccesories.Trim() ||
                    AppSettings.settings.AccessoriesAB.ColumnSerialNumber != frm.serialAccesories.Trim() ||
                    AppSettings.settings.AccessoriesAB.ColumnDueDate != frm.dueDateAccesories.Trim();

                //AppSettings.settings.OpenOrange.ColumnCode.name != frm.codeOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnUnits.name != frm.qtyOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnSerialNumber.name != frm.serieOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnDueDate.name != frm.dueDateOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnPrice.name != frm.priceOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnBatch.name != frm.batchOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnKit.name != frm.kitOpenOrange.Trim() ||
                //AppSettings.settings.OpenOrange.ColumnCode.isActive != frm.codeOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnUnits.isActive != frm.qtyOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive != frm.serieOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnDueDate.isActive != frm.dueDateOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnPrice.isActive != frm.priceOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnBatch.isActive != frm.batchOpenOrangeActive ||
                //AppSettings.settings.OpenOrange.ColumnKit.isActive != frm.kitOpenOrangeActive;

            }
            return false;
        }

        private bool hasSettingsAtosChanged()
        {
            if (activeForm is FrmSettingsAtos frm)
            {
                return
                    AppSettings.settings.IngresoAtos.ColumnCode != frm.codeReceipt.Trim() ||
                    AppSettings.settings.IngresoAtos.ColumnUnits != frm.quantityReceipt.Trim() ||
                    AppSettings.settings.IngresoAtos.ColumnDescription != frm.descriptionReceipt.Trim() ||
                    AppSettings.settings.IngresoAtos.ColumnSerialNumber != frm.serialReceipt.Trim() ||
                    AppSettings.settings.IngresoAtos.ColumnDueDate != frm.dueDateReceipt.Trim() ||

                    AppSettings.settings.InventoryAtos.ColumnCode != frm.codeInventory.Trim() ||
                    AppSettings.settings.InventoryAtos.ColumnUnits != frm.quantityInventory.Trim() ||
                    AppSettings.settings.InventoryAtos.ColumnDescription != frm.descriptionInventory.Trim() ||
                    AppSettings.settings.InventoryAtos.ColumnSerialNumber != frm.serialInventory.Trim() ||
                    AppSettings.settings.InventoryAtos.ColumnDueDate != frm.dueDateInventory.Trim();
            }

            return false;
        }

        private bool hasSettingsBernafonChanged()
        {
            if (activeForm is FrmSettingsBernafon frm)
            {
                if (HasDataGridViewBernafonChanged(frm))
                {
                    return true;
                }
                return
                    AppSettings.settings.IngresoBernafon.ColumnCode != frm.codeReceipt.Trim() ||
                    AppSettings.settings.IngresoBernafon.ColumnUnits != frm.quantityReceipt.Trim() ||
                    AppSettings.settings.IngresoBernafon.ColumnDescription != frm.descriptionReceipt.Trim() ||
                    AppSettings.settings.IngresoBernafon.ColumnSerialNumber != frm.serialReceipt.Trim() ||
                    AppSettings.settings.IngresoBernafon.ColumnDueDate != frm.dueDateReceipt.Trim() ||

                    AppSettings.settings.InventoryBernafon.ColumnCode != frm.codeInventory.Trim() ||
                    AppSettings.settings.InventoryBernafon.ColumnUnits != frm.quantityInventory.Trim() ||
                    AppSettings.settings.InventoryBernafon.ColumnDescription != frm.descriptionInventory.Trim() ||
                    AppSettings.settings.InventoryBernafon.ColumnSerialNumber != frm.serialInventory.Trim() ||
                    AppSettings.settings.InventoryBernafon.ColumnDueDate != frm.dueDateInventory.Trim() ||

                    AppSettings.settings.MovementsBernafon.ColumnCode != frm.codeMovements.Trim() ||
                    AppSettings.settings.MovementsBernafon.ColumnUnits != frm.quantityMovements.Trim();

            }
            return false;
        }

        // Retorna true si los códigos del gridView para desglose no coinciden con los guardados en Codigos_Desglose
        private bool HasDataGridViewBernafonChanged(FrmSettingsBernafon frm)
        {
            List<string> codigosSaved = AppSettings.settings.MovementsBernafon.Codigos_Desglose.Split(";").ToList();

            foreach (DataGridViewRow row in frm.CodigosDesglose.Rows)
            {
                if (row.Cells["ArtCode"].Value == null || row.Cells["ArtCode"].Value == DBNull.Value)
                {
                    continue;
                }
                string codArticle = row.Cells["ArtCode"].Value.ToString();

                if (codigosSaved.Contains(codArticle))
                {
                    codigosSaved.Remove(codArticle);
                }
                else
                {
                    return true;
                }
            }

            return codigosSaved.Count != 0 && codigosSaved.All(x => !string.IsNullOrEmpty(x)); // Si quedan códigos en la lista hay diferencias debido a que el usuario eliminó códigos del gridView.
        }

        private bool hasSettingsInomedChanged()
        {
            if (activeForm is FrmSettingsInomed frm)
            {
                return
                    AppSettings.settings.IngresoInomed.ColumnCode != frm.codeReceipt.Trim() ||
                    AppSettings.settings.IngresoInomed.ColumnUnits != frm.quantityReceipt.Trim() ||
                    AppSettings.settings.IngresoInomed.ColumnDescription != frm.descriptionReceipt.Trim() ||
                    AppSettings.settings.IngresoInomed.ColumnSerialNumber != frm.serialReceipt.Trim() ||
                    AppSettings.settings.IngresoInomed.ColumnDueDate != frm.dueDateReceipt.Trim() ||

                    AppSettings.settings.InventoryInomed.ColumnCode != frm.codeInventory.Trim() ||
                    AppSettings.settings.InventoryInomed.ColumnUnits != frm.quantityInventory.Trim() ||
                    AppSettings.settings.InventoryInomed.ColumnDescription != frm.descriptionInventory.Trim() ||
                    AppSettings.settings.InventoryInomed.ColumnSerialNumber != frm.serialInventory.Trim() ||
                    AppSettings.settings.InventoryInomed.ColumnDueDate != frm.dueDateInventory.Trim();
            }
            return false;
        }

        private bool hasSettingsOticomChanged()
        {
            if (activeForm is FrmSettingsOticom frm)
            {
                return
                    AppSettings.settings.IngresoOticom.ColumnCode != frm.codeReceipt.Trim() ||
                    AppSettings.settings.IngresoOticom.ColumnUnits != frm.quantityReceipt.Trim() ||
                    AppSettings.settings.IngresoOticom.ColumnDescription != frm.descriptionReceipt.Trim() ||
                    AppSettings.settings.IngresoOticom.ColumnSerialNumber != frm.serialReceipt.Trim() ||
                    AppSettings.settings.IngresoOticom.ColumnDueDate != frm.dueDateReceipt.Trim() ||

                    AppSettings.settings.InventoryOticom.ColumnCode != frm.codeInventory.Trim() ||
                    AppSettings.settings.InventoryOticom.ColumnUnits != frm.quantityInventory.Trim() ||
                    AppSettings.settings.InventoryOticom.ColumnDescription != frm.descriptionInventory.Trim() ||
                    AppSettings.settings.InventoryOticom.ColumnSerialNumber != frm.serialInventory.Trim() ||
                    AppSettings.settings.InventoryOticom.ColumnDueDate != frm.dueDateInventory.Trim();
            }
            return false;
        }

        private bool hasSettingsEtiquetasChanged()
        {
            if (activeForm is FrmSettingsEtiquetas frm)
            {
                return
                    AppSettings.settings.Etiquetas.ColumnCode.name != frm.codeEtiquetas.Trim() ||
                    AppSettings.settings.Etiquetas.ColumnSerialNumber.name != frm.serieEtiquetas.Trim() ||
                    AppSettings.settings.Etiquetas.ColumnUnits.name != frm.unitsEtiquetas.Trim() ||
                    AppSettings.settings.Etiquetas.ColumnDespacho.name != frm.despachoEtiquetas.Trim() ||

                    AppSettings.settings.Etiquetas.ColumnCode.isActive != frm.codeEtiquetasActive ||
                    AppSettings.settings.Etiquetas.ColumnSerialNumber.isActive != frm.serieEtiquetasActive ||
                    AppSettings.settings.Etiquetas.ColumnUnits.isActive != frm.unitsEtiquetasActive ||
                    AppSettings.settings.Etiquetas.ColumnDespacho.isActive != frm.despachoEtiquetasActive ||

                    AppSettings.settings.Etiquetas.ExportPath != frm.exportPathEtiquetas.Trim() ||
                    AppSettings.settings.Etiquetas.FileName != frm.fileNameEtiquetas.Trim();
            }
            return false;
        }


        #endregion

        #region Settings – Persist / Apply Changes

        // Save changes on XML
        private void saveChanges()
        {

            switch (activeForm)
            {
                case FrmSettingsSystem:
                    saveSettingSystem();
                    break;
                case FrmSettingsAB:
                    saveSettingsAB();
                    break;
                case FrmSettingsAtos:
                    saveSettingsAtos();
                    break;
                case FrmSettingsBernafon:
                    saveSettingsBernafon();
                    break;
                case FrmSettingsInomed:
                    saveSettingsInomed();
                    break;
                case FrmSettingsOticom:
                    saveSettingsOticom();
                    break;
                case FrmSettingsEtiquetas:
                    saveSettingsEtiquetas();
                    break;
            }
        }


        private void saveSettingSystem()
        {
            if (activeForm is FrmSettingsSystem frm)
            {
                AppSettings.settings.ArticlePrice = frm.ArticlePriceValue.Trim();

                AppSettings.settings.OpenOrange.ColumnCode.name = frm.codeOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnUnits.name = frm.qtyOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnSerialNumber.name = frm.serieOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnDueDate.name = frm.dueDateOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnPrice.name = frm.priceOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnBatch.name = frm.batchOpenOrange.Trim();
                AppSettings.settings.OpenOrange.ColumnKit.name = frm.kitOpenOrange.Trim();

                AppSettings.settings.OpenOrange.ColumnCode.isActive = frm.codeOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnUnits.isActive = frm.qtyOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive = frm.serieOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnDueDate.isActive = frm.dueDateOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnPrice.isActive = frm.priceOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnBatch.isActive = frm.batchOpenOrangeActive;
                AppSettings.settings.OpenOrange.ColumnKit.isActive = frm.kitOpenOrangeActive;

                saveSettings();
            }
        }

        private void saveSettingsAB()
        {
            if (activeForm is FrmSettingsAB frm)
            {
                AppSettings.settings.ValijasAB.ColumnCode = frm.codeReceipt.Trim();
                AppSettings.settings.ValijasAB.ColumnUnits = frm.quantityReceipt.Trim();
                AppSettings.settings.ValijasAB.ColumnDescription = frm.descriptionReceipt.Trim();
                AppSettings.settings.ValijasAB.ColumnSerialNumber = frm.serialReceipt.Trim();
                AppSettings.settings.ValijasAB.ColumnDueDate = frm.dueDateReceipt.Trim();

                AppSettings.settings.InventoryAB.ColumnCode = frm.codeInventory.Trim();
                AppSettings.settings.InventoryAB.ColumnUnits = frm.quantityInventory.Trim();
                AppSettings.settings.InventoryAB.ColumnDescription = frm.descriptionInventory.Trim();
                AppSettings.settings.InventoryAB.ColumnSerialNumber = frm.serialInventory.Trim();
                AppSettings.settings.InventoryAB.ColumnDueDate = frm.dueDateInventory.Trim();

                AppSettings.settings.AccessoriesAB.ColumnCode = frm.codeAccesories.Trim();
                AppSettings.settings.AccessoriesAB.ColumnUnits = frm.quantityAccesories.Trim();
                AppSettings.settings.AccessoriesAB.ColumnDescription = frm.descriptionAccesories.Trim();
                AppSettings.settings.AccessoriesAB.ColumnSerialNumber = frm.serialAccesories.Trim();
                AppSettings.settings.AccessoriesAB.ColumnDueDate = frm.dueDateAccesories.Trim();

                //AppSettings.settings.OpenOrange.ColumnCode.name = frm.codeOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnUnits.name = frm.qtyOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnSerialNumber.name = frm.serieOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnDueDate.name = frm.dueDateOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnPrice.name = frm.priceOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnBatch.name = frm.batchOpenOrange.Trim();
                //AppSettings.settings.OpenOrange.ColumnKit.name = frm.kitOpenOrange.Trim();

                //AppSettings.settings.OpenOrange.ColumnCode.isActive = frm.codeOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnUnits.isActive = frm.qtyOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnSerialNumber.isActive = frm.serieOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnDueDate.isActive = frm.dueDateOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnPrice.isActive = frm.priceOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnBatch.isActive = frm.batchOpenOrangeActive;
                //AppSettings.settings.OpenOrange.ColumnKit.isActive = frm.kitOpenOrangeActive;

                saveSettings();
            }
        }

        private void saveSettingsAtos()
        {
            if (activeForm is FrmSettingsAtos frm)
            {
                AppSettings.settings.IngresoAtos.ColumnCode = frm.codeReceipt.Trim();
                AppSettings.settings.IngresoAtos.ColumnUnits = frm.quantityReceipt.Trim();
                AppSettings.settings.IngresoAtos.ColumnDescription = frm.descriptionReceipt.Trim();
                AppSettings.settings.IngresoAtos.ColumnSerialNumber = frm.serialReceipt.Trim();
                AppSettings.settings.IngresoAtos.ColumnDueDate = frm.dueDateReceipt.Trim();

                AppSettings.settings.InventoryAtos.ColumnCode = frm.codeInventory.Trim();
                AppSettings.settings.InventoryAtos.ColumnUnits = frm.quantityInventory.Trim();
                AppSettings.settings.InventoryAtos.ColumnDescription = frm.descriptionInventory.Trim();
                AppSettings.settings.InventoryAtos.ColumnSerialNumber = frm.serialInventory.Trim();
                AppSettings.settings.InventoryAtos.ColumnDueDate = frm.dueDateInventory.Trim();

                saveSettings();
            }
        }

        private void saveSettingsBernafon()
        {
            if (activeForm is FrmSettingsBernafon frm)
            {
                saveSettigsGridViewBernafon(frm);

                AppSettings.settings.IngresoBernafon.ColumnCode = frm.codeReceipt.Trim();
                AppSettings.settings.IngresoBernafon.ColumnUnits = frm.quantityReceipt.Trim();
                AppSettings.settings.IngresoBernafon.ColumnDescription = frm.descriptionReceipt.Trim();
                AppSettings.settings.IngresoBernafon.ColumnSerialNumber = frm.serialReceipt.Trim();
                AppSettings.settings.IngresoBernafon.ColumnDueDate = frm.dueDateReceipt.Trim();

                AppSettings.settings.InventoryBernafon.ColumnCode = frm.codeInventory.Trim();
                AppSettings.settings.InventoryBernafon.ColumnUnits = frm.quantityInventory.Trim();
                AppSettings.settings.InventoryBernafon.ColumnDescription = frm.descriptionInventory.Trim();
                AppSettings.settings.InventoryBernafon.ColumnSerialNumber = frm.serialInventory.Trim();
                AppSettings.settings.InventoryBernafon.ColumnDueDate = frm.dueDateInventory.Trim();


                AppSettings.settings.MovementsBernafon.ColumnCode = frm.codeMovements.Trim();
                AppSettings.settings.MovementsBernafon.ColumnUnits = frm.quantityMovements.Trim();

                saveSettings();
            }
        }

        private void saveSettigsGridViewBernafon(FrmSettingsBernafon frm)
        {
            List<string> newCodes = new List<string>();

            foreach (DataGridViewRow row in frm.CodigosDesglose.Rows)
            {
                if (row.Cells["ArtCode"].Value == null || row.Cells["ArtCode"].Value == DBNull.Value)
                {
                    continue;
                }

                string code = row.Cells["ArtCode"].Value.ToString().Trim();

                if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
                {
                    continue;
                }

                if (!newCodes.Contains(code))
                {
                    newCodes.Add(code);
                }
            }
            newCodes.Sort();
            string codigos_desglose = string.Join(";", newCodes);

            AppSettings.settings.MovementsBernafon.Codigos_Desglose = codigos_desglose;
        }

        private void saveSettingsEtiquetas()
        {
            if (activeForm is FrmSettingsEtiquetas frm)
            {
                AppSettings.settings.Etiquetas.ColumnCode.name = frm.codeEtiquetas.Trim();
                AppSettings.settings.Etiquetas.ColumnSerialNumber.name = frm.serieEtiquetas.Trim();
                AppSettings.settings.Etiquetas.ColumnUnits.name = frm.unitsEtiquetas.Trim();
                AppSettings.settings.Etiquetas.ColumnDespacho.name = frm.despachoEtiquetas.Trim();

                AppSettings.settings.Etiquetas.ColumnCode.isActive = frm.codeEtiquetasActive;
                AppSettings.settings.Etiquetas.ColumnSerialNumber.isActive = frm.serieEtiquetasActive;
                AppSettings.settings.Etiquetas.ColumnUnits.isActive = frm.unitsEtiquetasActive;
                AppSettings.settings.Etiquetas.ColumnDespacho.isActive = frm.despachoEtiquetasActive;

                AppSettings.settings.Etiquetas.ExportPath = frm.exportPathEtiquetas.Trim();
                AppSettings.settings.Etiquetas.FileName = frm.fileNameEtiquetas.Trim();

                saveSettings();
            }
        }

        private void saveSettingsInomed()
        {
            if (activeForm is FrmSettingsInomed frm)
            {
                AppSettings.settings.IngresoInomed.ColumnCode = frm.codeReceipt.Trim();
                AppSettings.settings.IngresoInomed.ColumnUnits = frm.quantityReceipt.Trim();
                AppSettings.settings.IngresoInomed.ColumnDescription = frm.descriptionReceipt.Trim();
                AppSettings.settings.IngresoInomed.ColumnSerialNumber = frm.serialReceipt.Trim();
                AppSettings.settings.IngresoInomed.ColumnDueDate = frm.dueDateReceipt.Trim();

                AppSettings.settings.InventoryInomed.ColumnCode = frm.codeInventory.Trim();
                AppSettings.settings.InventoryInomed.ColumnUnits = frm.quantityInventory.Trim();
                AppSettings.settings.InventoryInomed.ColumnDescription = frm.descriptionInventory.Trim();
                AppSettings.settings.InventoryInomed.ColumnSerialNumber = frm.serialInventory.Trim();
                AppSettings.settings.InventoryInomed.ColumnDueDate = frm.dueDateInventory.Trim();

                saveSettings();
            }
        }

        private void saveSettingsOticom()
        {
            if (activeForm is FrmSettingsOticom frm)
            {
                AppSettings.settings.IngresoOticom.ColumnCode = frm.codeReceipt.Trim();
                AppSettings.settings.IngresoOticom.ColumnUnits = frm.quantityReceipt.Trim();
                AppSettings.settings.IngresoOticom.ColumnDescription = frm.descriptionReceipt.Trim();
                AppSettings.settings.IngresoOticom.ColumnSerialNumber = frm.serialReceipt.Trim();
                AppSettings.settings.IngresoOticom.ColumnDueDate = frm.dueDateReceipt.Trim();

                AppSettings.settings.InventoryOticom.ColumnCode = frm.codeInventory.Trim();
                AppSettings.settings.InventoryOticom.ColumnUnits = frm.quantityInventory.Trim();
                AppSettings.settings.InventoryOticom.ColumnDescription = frm.descriptionInventory.Trim();
                AppSettings.settings.InventoryOticom.ColumnSerialNumber = frm.serialInventory.Trim();
                AppSettings.settings.InventoryOticom.ColumnDueDate = frm.dueDateInventory.Trim();

                saveSettings();
            }
        }


        #endregion


        private void saveSettings()
        {
            try
            {
                AppSettings.saveSettings();
                MessageBox.Show("Configuración guardada con éxito.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error al guardar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            evaluateChanges();
        }

        private void evaluateChanges()
        {
            if (hasSettingsChanged())
            {
                if (MessageBox.Show("¿Desea guardar los cambios?", "Cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveChanges();
                }
            }
        }

        #region Button Panel

        private void ShowPanelIfNotActive(Type formType, string titleForm)
        {
            if (activeForm == null || activeForm.GetType() != formType)
            {
                try
                {
                    evaluateChanges();
                    Form frm = (Form)Activator.CreateInstance(formType);
                    LblTitleSettingMenu.Text = titleForm;
                    showPanel(frm);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void showPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainerSettings.Controls.Add(childForm);
            panelContainerSettings.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnSettingsSystem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsSystem), "Configuraciones Sistema");
        }

        private void BtnSettingsAB_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsAB), "Configuraciones AB");
        }

        private void BtnSettingsAtos_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsAtos), "Configuraciones Atos");
        }

        private void btnSettingsBernafon_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsBernafon), "Configuraciones Bernafon");
        }

        private void btnSettingsInomed_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsInomed), "Configuraciones Inomed");
        }

        private void btnSettingsOticom_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsOticom), "Configuraciones Oticom");
        }

        private void BtnSettingsEtiquetas_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettingsEtiquetas), "Configuraciones Etiquetas");
        }

        #endregion

        
    }
}
