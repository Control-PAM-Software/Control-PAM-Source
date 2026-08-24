namespace Control.Models
{
    partial class FrmSettingsEtiquetas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitleSection = new Label();
            lblCode = new Label();
            txtCode = new TextBox();
            chbCode = new CheckBox();
            lblUnits = new Label();
            txtUnits = new TextBox();
            chbUnits = new CheckBox();
            lblSerie = new Label();
            txtSerie = new TextBox();
            chbSerie = new CheckBox();
            lblDespacho = new Label();
            txtDespacho = new TextBox();
            chbDespacho = new CheckBox();
            lblExportPath = new Label();
            txtExportPath = new TextBox();
            btnBrowseExportPath = new Button();
            lblFileName = new Label();
            txtFileName = new TextBox();
            SuspendLayout();

            //
            // SECCIÓN: ETIQUETAS
            //
            lblTitleSection.AutoSize = true;
            lblTitleSection.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitleSection.ForeColor = Color.FromArgb(39, 39, 58);
            lblTitleSection.Location = new Point(30, 25);
            lblTitleSection.Name = "lblTitleSection";
            lblTitleSection.Size = new Size(103, 30);
            lblTitleSection.Text = "Etiquetas";

            // Código
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 10F);
            lblCode.Location = new Point(45, 76);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(53, 19);
            lblCode.Text = "Código";

            txtCode.Location = new Point(200, 75);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(200, 25);

            chbCode.Location = new Point(415, 80);
            chbCode.Name = "chbCode";
            chbCode.Size = new Size(15, 14);

            // Cantidad
            lblUnits.AutoSize = true;
            lblUnits.Font = new Font("Segoe UI", 10F);
            lblUnits.Location = new Point(45, 111);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(66, 19);
            lblUnits.Text = "Cantidad";

            txtUnits.Location = new Point(200, 110);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new Size(200, 25);

            chbUnits.Location = new Point(415, 115);
            chbUnits.Name = "chbUnits";

            // Serie
            lblSerie.AutoSize = true;
            lblSerie.Font = new Font("Segoe UI", 10F);
            lblSerie.Location = new Point(45, 146);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(41, 19);
            lblSerie.Text = "Serie";

            txtSerie.Location = new Point(200, 145);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(200, 25);

            chbSerie.Location = new Point(415, 150);
            chbSerie.Name = "chbSerie";

            // Despacho
            lblDespacho.AutoSize = true;
            lblDespacho.Font = new Font("Segoe UI", 10F);
            lblDespacho.Location = new Point(45, 181);
            lblDespacho.Name = "lblDespacho";
            lblDespacho.Size = new Size(70, 19);
            lblDespacho.Text = "Despacho";

            txtDespacho.Location = new Point(200, 180);
            txtDespacho.Name = "txtDespacho";
            txtDespacho.Size = new Size(200, 25);

            chbDespacho.Location = new Point(415, 185);
            chbDespacho.Name = "chbDespacho";

            // Carpeta de exportación
            lblExportPath.AutoSize = true;
            lblExportPath.Font = new Font("Segoe UI", 10F);
            lblExportPath.Location = new Point(45, 221);
            lblExportPath.Name = "lblExportPath";
            lblExportPath.Size = new Size(158, 19);
            lblExportPath.Text = "Carpeta de exportación";

            txtExportPath.Location = new Point(200, 218);
            txtExportPath.Name = "txtExportPath";
            txtExportPath.Size = new Size(280, 25);

            btnBrowseExportPath.FlatStyle = FlatStyle.Flat;
            btnBrowseExportPath.Font = new Font("Segoe UI", 8.5F);
            btnBrowseExportPath.Location = new Point(490, 216);
            btnBrowseExportPath.Name = "btnBrowseExportPath";
            btnBrowseExportPath.Size = new Size(90, 28);
            btnBrowseExportPath.Text = "Examinar...";
            btnBrowseExportPath.UseVisualStyleBackColor = true;
            btnBrowseExportPath.Click += btnBrowseExportPath_Click;

            // Nombre del archivo
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Segoe UI", 10F);
            lblFileName.Location = new Point(45, 256);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(139, 19);
            lblFileName.Text = "Nombre del archivo";

            txtFileName.Location = new Point(200, 253);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(280, 25);

            //
            // FrmSettingsEtiquetas (Formulario)
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(983, 550);

            // Agregar controles
            Controls.Add(lblTitleSection);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(chbCode);
            Controls.Add(lblUnits);
            Controls.Add(txtUnits);
            Controls.Add(chbUnits);
            Controls.Add(lblSerie);
            Controls.Add(txtSerie);
            Controls.Add(chbSerie);
            Controls.Add(lblDespacho);
            Controls.Add(txtDespacho);
            Controls.Add(chbDespacho);
            Controls.Add(lblExportPath);
            Controls.Add(txtExportPath);
            Controls.Add(btnBrowseExportPath);
            Controls.Add(lblFileName);
            Controls.Add(txtFileName);

            Name = "FrmSettingsEtiquetas";
            Text = "Configuraciones Etiquetas";
            Load += FrmSettingsEtiquetas_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label lblTitleSection;
        private Label lblCode;
        private TextBox txtCode;
        private CheckBox chbCode;
        private Label lblUnits;
        private TextBox txtUnits;
        private CheckBox chbUnits;
        private Label lblSerie;
        private TextBox txtSerie;
        private CheckBox chbSerie;
        private Label lblDespacho;
        private TextBox txtDespacho;
        private CheckBox chbDespacho;
        private Label lblExportPath;
        private TextBox txtExportPath;
        private Button btnBrowseExportPath;
        private Label lblFileName;
        private TextBox txtFileName;
    }
}
