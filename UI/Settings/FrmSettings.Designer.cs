using System.Windows.Forms;

namespace Control
{
    partial class FrmSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            panel8 = new Panel();
            panelFooter = new Panel();
            btnSaveChangesSettings = new Button();
            btnSettingsOticom = new Button();
            btnSettingsEtiquetas = new Button();
            btnSettingsInomed = new Button();
            btnSettingsBernafon = new Button();
            BtnSettingsAtos = new Button();
            BtnSettingsAB = new Button();
            BtnSettingsSystem = new Button();
            panel9 = new Panel();
            panel10 = new Panel();
            LblTitleSettingMenu = new Label();
            panelContainerSettings = new Panel();
            panel8.SuspendLayout();
            panelFooter.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(45, 45, 48);
            panel8.Controls.Add(panelFooter);
            panel8.Controls.Add(btnSettingsEtiquetas);
            panel8.Controls.Add(btnSettingsOticom);
            panel8.Controls.Add(btnSettingsInomed);
            panel8.Controls.Add(btnSettingsBernafon);
            panel8.Controls.Add(BtnSettingsAtos);
            panel8.Controls.Add(BtnSettingsAB);
            panel8.Controls.Add(BtnSettingsSystem);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(220, 588);
            panel8.TabIndex = 1;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(39, 39, 58);
            panelFooter.Controls.Add(btnSaveChangesSettings);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 522);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(10);
            panelFooter.Size = new Size(220, 66);
            panelFooter.TabIndex = 12;
            // 
            // btnSaveChangesSettings
            // 
            btnSaveChangesSettings.BackColor = Color.FromArgb(39, 39, 58);
            btnSaveChangesSettings.Cursor = Cursors.Hand;
            btnSaveChangesSettings.Dock = DockStyle.Fill;
            btnSaveChangesSettings.FlatAppearance.BorderSize = 0;
            btnSaveChangesSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 51, 76);
            btnSaveChangesSettings.FlatStyle = FlatStyle.Flat;
            btnSaveChangesSettings.Font = new Font("Segoe UI Semibold", 10F);
            btnSaveChangesSettings.ForeColor = Color.White;
            btnSaveChangesSettings.Image = Properties.Resources.SaveNew;
            btnSaveChangesSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaveChangesSettings.Location = new Point(10, 10);
            btnSaveChangesSettings.Name = "btnSaveChangesSettings";
            btnSaveChangesSettings.Padding = new Padding(10, 0, 0, 0);
            btnSaveChangesSettings.Size = new Size(200, 46);
            btnSaveChangesSettings.TabIndex = 7;
            btnSaveChangesSettings.Text = "    Guardar Cambios";
            btnSaveChangesSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveChangesSettings.UseVisualStyleBackColor = false;
            btnSaveChangesSettings.Click += btnSaveChangesSettings_Click;
            // 
            // btnSettingsEtiquetas
            // 
            btnSettingsEtiquetas.Cursor = Cursors.Hand;
            btnSettingsEtiquetas.Dock = DockStyle.Top;
            btnSettingsEtiquetas.FlatAppearance.BorderSize = 0;
            btnSettingsEtiquetas.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnSettingsEtiquetas.FlatStyle = FlatStyle.Flat;
            btnSettingsEtiquetas.Font = new Font("Segoe UI Semibold", 11F);
            btnSettingsEtiquetas.ForeColor = Color.Gainsboro;
            btnSettingsEtiquetas.Location = new Point(0, 410);
            btnSettingsEtiquetas.Name = "btnSettingsEtiquetas";
            btnSettingsEtiquetas.Padding = new Padding(15, 0, 0, 0);
            btnSettingsEtiquetas.Size = new Size(220, 55);
            btnSettingsEtiquetas.TabIndex = 12;
            btnSettingsEtiquetas.Text = "   Etiquetas";
            btnSettingsEtiquetas.TextAlign = ContentAlignment.MiddleLeft;
            btnSettingsEtiquetas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettingsEtiquetas.UseVisualStyleBackColor = true;
            btnSettingsEtiquetas.Click += BtnSettingsEtiquetas_Click;
            // 
            // btnSettingsOticom
            // 
            btnSettingsOticom.Cursor = Cursors.Hand;
            btnSettingsOticom.Dock = DockStyle.Top;
            btnSettingsOticom.FlatAppearance.BorderSize = 0;
            btnSettingsOticom.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnSettingsOticom.FlatStyle = FlatStyle.Flat;
            btnSettingsOticom.Font = new Font("Segoe UI Semibold", 11F);
            btnSettingsOticom.ForeColor = Color.Gainsboro;
            btnSettingsOticom.Location = new Point(0, 355);
            btnSettingsOticom.Name = "btnSettingsOticom";
            btnSettingsOticom.Padding = new Padding(15, 0, 0, 0);
            btnSettingsOticom.Size = new Size(220, 55);
            btnSettingsOticom.TabIndex = 11;
            btnSettingsOticom.Text = "   Oticom";
            btnSettingsOticom.TextAlign = ContentAlignment.MiddleLeft;
            btnSettingsOticom.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettingsOticom.UseVisualStyleBackColor = true;
            btnSettingsOticom.Click += btnSettingsOticom_Click;
            // 
            // btnSettingsInomed
            // 
            btnSettingsInomed.Cursor = Cursors.Hand;
            btnSettingsInomed.Dock = DockStyle.Top;
            btnSettingsInomed.FlatAppearance.BorderSize = 0;
            btnSettingsInomed.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnSettingsInomed.FlatStyle = FlatStyle.Flat;
            btnSettingsInomed.Font = new Font("Segoe UI Semibold", 11F);
            btnSettingsInomed.ForeColor = Color.Gainsboro;
            btnSettingsInomed.Location = new Point(0, 300);
            btnSettingsInomed.Name = "btnSettingsInomed";
            btnSettingsInomed.Padding = new Padding(15, 0, 0, 0);
            btnSettingsInomed.Size = new Size(220, 55);
            btnSettingsInomed.TabIndex = 10;
            btnSettingsInomed.Text = "   Inomed";
            btnSettingsInomed.TextAlign = ContentAlignment.MiddleLeft;
            btnSettingsInomed.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettingsInomed.UseVisualStyleBackColor = true;
            btnSettingsInomed.Click += btnSettingsInomed_Click;
            // 
            // btnSettingsBernafon
            // 
            btnSettingsBernafon.Cursor = Cursors.Hand;
            btnSettingsBernafon.Dock = DockStyle.Top;
            btnSettingsBernafon.FlatAppearance.BorderSize = 0;
            btnSettingsBernafon.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnSettingsBernafon.FlatStyle = FlatStyle.Flat;
            btnSettingsBernafon.Font = new Font("Segoe UI Semibold", 11F);
            btnSettingsBernafon.ForeColor = Color.Gainsboro;
            btnSettingsBernafon.Location = new Point(0, 245);
            btnSettingsBernafon.Name = "btnSettingsBernafon";
            btnSettingsBernafon.Padding = new Padding(15, 0, 0, 0);
            btnSettingsBernafon.Size = new Size(220, 55);
            btnSettingsBernafon.TabIndex = 9;
            btnSettingsBernafon.Text = "   Bernafon";
            btnSettingsBernafon.TextAlign = ContentAlignment.MiddleLeft;
            btnSettingsBernafon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettingsBernafon.UseVisualStyleBackColor = true;
            btnSettingsBernafon.Click += btnSettingsBernafon_Click;
            // 
            // BtnSettingsAtos
            // 
            BtnSettingsAtos.Cursor = Cursors.Hand;
            BtnSettingsAtos.Dock = DockStyle.Top;
            BtnSettingsAtos.FlatAppearance.BorderSize = 0;
            BtnSettingsAtos.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            BtnSettingsAtos.FlatStyle = FlatStyle.Flat;
            BtnSettingsAtos.Font = new Font("Segoe UI Semibold", 11F);
            BtnSettingsAtos.ForeColor = Color.Gainsboro;
            BtnSettingsAtos.Location = new Point(0, 190);
            BtnSettingsAtos.Name = "BtnSettingsAtos";
            BtnSettingsAtos.Padding = new Padding(15, 0, 0, 0);
            BtnSettingsAtos.Size = new Size(220, 55);
            BtnSettingsAtos.TabIndex = 8;
            BtnSettingsAtos.Text = "   Atos";
            BtnSettingsAtos.TextAlign = ContentAlignment.MiddleLeft;
            BtnSettingsAtos.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSettingsAtos.UseVisualStyleBackColor = true;
            BtnSettingsAtos.Click += BtnSettingsAtos_Click;
            // 
            // BtnSettingsAB
            // 
            BtnSettingsAB.Cursor = Cursors.Hand;
            BtnSettingsAB.Dock = DockStyle.Top;
            BtnSettingsAB.FlatAppearance.BorderSize = 0;
            BtnSettingsAB.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            BtnSettingsAB.FlatStyle = FlatStyle.Flat;
            BtnSettingsAB.Font = new Font("Segoe UI Semibold", 11F);
            BtnSettingsAB.ForeColor = Color.Gainsboro;
            BtnSettingsAB.Location = new Point(0, 135);
            BtnSettingsAB.Name = "BtnSettingsAB";
            BtnSettingsAB.Padding = new Padding(15, 0, 0, 0);
            BtnSettingsAB.Size = new Size(220, 55);
            BtnSettingsAB.TabIndex = 3;
            BtnSettingsAB.Text = "   AB";
            BtnSettingsAB.TextAlign = ContentAlignment.MiddleLeft;
            BtnSettingsAB.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSettingsAB.UseVisualStyleBackColor = true;
            BtnSettingsAB.Click += BtnSettingsAB_Click;
            // 
            // BtnSettingsSystem
            // 
            BtnSettingsSystem.Cursor = Cursors.Hand;
            BtnSettingsSystem.Dock = DockStyle.Top;
            BtnSettingsSystem.FlatAppearance.BorderSize = 0;
            BtnSettingsSystem.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            BtnSettingsSystem.FlatStyle = FlatStyle.Flat;
            BtnSettingsSystem.Font = new Font("Segoe UI Semibold", 11F);
            BtnSettingsSystem.ForeColor = Color.Gainsboro;
            BtnSettingsSystem.Location = new Point(0, 80);
            BtnSettingsSystem.Name = "BtnSettingsSystem";
            BtnSettingsSystem.Padding = new Padding(15, 0, 0, 0);
            BtnSettingsSystem.Size = new Size(220, 55);
            BtnSettingsSystem.TabIndex = 2;
            BtnSettingsSystem.Text = "   Sistema";
            BtnSettingsSystem.TextAlign = ContentAlignment.MiddleLeft;
            BtnSettingsSystem.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnSettingsSystem.UseVisualStyleBackColor = true;
            BtnSettingsSystem.Click += BtnSettingsSystem_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(39, 39, 58);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(220, 80);
            panel9.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(39, 39, 58);
            panel10.Controls.Add(LblTitleSettingMenu);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(220, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(987, 80);
            panel10.TabIndex = 2;
            // 
            // LblTitleSettingMenu
            // 
            LblTitleSettingMenu.Dock = DockStyle.Fill;
            LblTitleSettingMenu.Font = new Font("Segoe UI Light", 20F);
            LblTitleSettingMenu.ForeColor = Color.White;
            LblTitleSettingMenu.Location = new Point(0, 0);
            LblTitleSettingMenu.Name = "LblTitleSettingMenu";
            LblTitleSettingMenu.Padding = new Padding(30, 0, 0, 0);
            LblTitleSettingMenu.Size = new Size(987, 80);
            LblTitleSettingMenu.TabIndex = 42;
            LblTitleSettingMenu.Text = "Configuraciones del Sistema";
            LblTitleSettingMenu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelContainerSettings
            // 
            panelContainerSettings.AutoScroll = true;
            panelContainerSettings.BackColor = Color.FromArgb(245, 247, 251);
            panelContainerSettings.Dock = DockStyle.Fill;
            panelContainerSettings.Location = new Point(220, 80);
            panelContainerSettings.Name = "panelContainerSettings";
            panelContainerSettings.Padding = new Padding(10);
            panelContainerSettings.Size = new Size(987, 508);
            panelContainerSettings.TabIndex = 3;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1207, 588);
            Controls.Add(panelContainerSettings);
            Controls.Add(panel10);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración";
            FormClosing += FrmSettings_FormClosing;
            Load += FrmSettings_Load;
            panel8.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel8;
        private Button BtnSettingsSystem;
        private Panel panel9;
        private Panel panel10;
        private Label LblTitleSettingMenu;
        private Panel panelContainerSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ColorDialog colorDialog1;
        private Button BtnSettingsAB;
        private Button btnSaveChangesSettings;
        private Button BtnSettingsAtos;
        private Button btnSettingsInomed;
        private Button btnSettingsBernafon;
        private Button btnSettingsOticom;
        private Button btnSettingsEtiquetas;
        private Panel panelFooter;

    }
}