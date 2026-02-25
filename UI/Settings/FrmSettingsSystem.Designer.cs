namespace Control.Models
{
    partial class FrmSettingsSystem
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
            label4 = new Label();
            txtArticlePrice = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            PanelMissItemColorSetting = new Panel();
            PanelColorDiffSetting = new Panel();
            btnChangeMissItemColor = new Button();
            btnChangeDiffColor = new Button();
            chbKitOpenOrange = new CheckBox();
            label26 = new Label();
            txtKitOpenOrange = new TextBox();
            chbBatchOpenOrange = new CheckBox();
            label25 = new Label();
            txtBatchOpenOrange = new TextBox();
            chbDueDateOpenOrange = new CheckBox();
            chbSerieOpenOrange = new CheckBox();
            chbPriceOpenOrange = new CheckBox();
            chbQtyOpenOrange = new CheckBox();
            chbCodeOpenOrange = new CheckBox();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            txtDueDateOpenOrange = new TextBox();
            txtSerieOpenOrange = new TextBox();
            txtPriceOpenOrange = new TextBox();
            txtQtyOpenOrange = new TextBox();
            txtCodeOpenOrange = new TextBox();
            SuspendLayout();

            // 
            // SECCIÓN: GENERAL
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(39, 39, 58);
            label4.Location = new Point(30, 25);
            label4.Name = "label4";
            label4.Size = new Size(93, 30);
            label4.Text = "General";

            // Color Diferencias
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(40, 85);
            label1.Name = "label1";
            label1.Size = new Size(131, 19);
            label1.Text = "Color de diferencias";

            PanelColorDiffSetting.BorderStyle = BorderStyle.None;
            PanelColorDiffSetting.BackColor = Color.Gainsboro;
            PanelColorDiffSetting.Location = new Point(200, 83);
            PanelColorDiffSetting.Name = "PanelColorDiffSetting";
            PanelColorDiffSetting.Size = new Size(80, 25);

            btnChangeDiffColor.FlatStyle = FlatStyle.Flat;
            btnChangeDiffColor.Font = new Font("Segoe UI", 8.5F);
            btnChangeDiffColor.Location = new Point(290, 80);
            btnChangeDiffColor.Name = "btnChangeDiffColor";
            btnChangeDiffColor.Size = new Size(90, 30);
            btnChangeDiffColor.Text = "Cambiar";
            btnChangeDiffColor.UseVisualStyleBackColor = true;
            btnChangeDiffColor.Click += btnChangeDiffColor_Click;

            // Color Faltantes
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(40, 125);
            label2.Name = "label2";
            label2.Size = new Size(119, 19);
            label2.Text = "Color de faltantes";

            PanelMissItemColorSetting.BorderStyle = BorderStyle.None;
            PanelMissItemColorSetting.BackColor = Color.Gainsboro;
            PanelMissItemColorSetting.Location = new Point(200, 123);
            PanelMissItemColorSetting.Name = "PanelMissItemColorSetting";
            PanelMissItemColorSetting.Size = new Size(80, 25);

            btnChangeMissItemColor.FlatStyle = FlatStyle.Flat;
            btnChangeMissItemColor.Font = new Font("Segoe UI", 8.5F);
            btnChangeMissItemColor.Location = new Point(290, 120);
            btnChangeMissItemColor.Name = "btnChangeMissItemColor";
            btnChangeMissItemColor.Size = new Size(90, 30);
            btnChangeMissItemColor.Text = "Cambiar";
            btnChangeMissItemColor.UseVisualStyleBackColor = true;
            btnChangeMissItemColor.Click += btnChangeMissItemColor_Click;

            // Precio Artículos
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(40, 168);
            label3.Name = "label3";
            label3.Size = new Size(122, 19);
            label3.Text = "Precio de artículos";

            txtArticlePrice.Font = new Font("Segoe UI", 10F);
            txtArticlePrice.Location = new Point(200, 165);
            txtArticlePrice.Name = "txtArticlePrice";
            txtArticlePrice.Size = new Size(180, 25);

            // 
            // SECCIÓN: OPEN ORANGE
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label24.ForeColor = Color.FromArgb(39, 39, 58);
            label24.Location = new Point(30, 225);
            label24.Name = "label24";
            label24.Size = new Size(225, 30);
            label24.Text = "Ingreso Open Orange";

            // Código
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 10F);
            label23.Location = new Point(45, 271);
            label23.Name = "label23";
            label23.Size = new Size(53, 19);
            label23.Text = "Código";

            txtCodeOpenOrange.Location = new Point(200, 270);
            txtCodeOpenOrange.Name = "txtCodeOpenOrange";
            txtCodeOpenOrange.Size = new Size(200, 25);

            chbCodeOpenOrange.Location = new Point(415, 275);
            chbCodeOpenOrange.Name = "chbCodeOpenOrange";
            chbCodeOpenOrange.Size = new Size(15, 14);

            // Unidades
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10F);
            label22.Location = new Point(45, 306);
            label22.Name = "label22";
            label22.Size = new Size(66, 19);
            label22.Text = "Unidades";

            txtQtyOpenOrange.Location = new Point(200, 305);
            txtQtyOpenOrange.Name = "txtQtyOpenOrange";
            txtQtyOpenOrange.Size = new Size(200, 25);

            chbQtyOpenOrange.Location = new Point(415, 310);
            chbQtyOpenOrange.Name = "chbQtyOpenOrange";

            // Precio
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 10F);
            label21.Location = new Point(45, 341);
            label21.Name = "label21";
            label21.Size = new Size(46, 19);
            label21.Text = "Precio";

            txtPriceOpenOrange.Location = new Point(200, 340);
            txtPriceOpenOrange.Name = "txtPriceOpenOrange";
            txtPriceOpenOrange.Size = new Size(200, 25);

            chbPriceOpenOrange.Location = new Point(415, 345);
            chbPriceOpenOrange.Name = "chbPriceOpenOrange";

            // Serie
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10F);
            label20.Location = new Point(45, 376);
            label20.Name = "label20";
            label20.Size = new Size(111, 19);
            label20.Text = "Número de Serie";

            txtSerieOpenOrange.Location = new Point(200, 375);
            txtSerieOpenOrange.Name = "txtSerieOpenOrange";
            txtSerieOpenOrange.Size = new Size(200, 25);

            chbSerieOpenOrange.Location = new Point(415, 380);
            chbSerieOpenOrange.Name = "chbSerieOpenOrange";

            // Vencimiento
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10F);
            label19.Location = new Point(45, 411);
            label19.Name = "label19";
            label19.Size = new Size(122, 19);
            label19.Text = "Fecha Vencimiento";

            txtDueDateOpenOrange.Location = new Point(200, 410);
            txtDueDateOpenOrange.Name = "txtDueDateOpenOrange";
            txtDueDateOpenOrange.Size = new Size(200, 25);

            chbDueDateOpenOrange.Location = new Point(415, 415);
            chbDueDateOpenOrange.Name = "chbDueDateOpenOrange";

            // Batch
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 10F);
            label25.Location = new Point(45, 446);
            label25.Name = "label25";
            label25.Size = new Size(84, 19);
            label25.Text = "Batch Status";

            txtBatchOpenOrange.Location = new Point(200, 445);
            txtBatchOpenOrange.Name = "txtBatchOpenOrange";
            txtBatchOpenOrange.Size = new Size(200, 25);

            chbBatchOpenOrange.Location = new Point(415, 450);
            chbBatchOpenOrange.Name = "chbBatchOpenOrange";

            // Kit
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 10F);
            label26.Location = new Point(45, 481);
            label26.Name = "label26";
            label26.Size = new Size(24, 19);
            label26.Text = "Kit";

            txtKitOpenOrange.Location = new Point(200, 480);
            txtKitOpenOrange.Name = "txtKitOpenOrange";
            txtKitOpenOrange.Size = new Size(200, 25);

            chbKitOpenOrange.Location = new Point(415, 485);
            chbKitOpenOrange.Name = "chbKitOpenOrange";

            // 
            // FrmSettingsSystem (Formulario)
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(983, 550);

            // Agregar controles
            Controls.Add(chbKitOpenOrange);
            Controls.Add(label26);
            Controls.Add(txtKitOpenOrange);
            Controls.Add(chbBatchOpenOrange);
            Controls.Add(label25);
            Controls.Add(txtBatchOpenOrange);
            // ... (Agregar el resto de controles de la misma forma)
            Controls.Add(label4);
            Controls.Add(txtArticlePrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PanelMissItemColorSetting);
            Controls.Add(PanelColorDiffSetting);
            Controls.Add(btnChangeMissItemColor);
            Controls.Add(btnChangeDiffColor);
            // Asegurarse de agregar TODOS los controles que faltan aquí
            Controls.Add(chbDueDateOpenOrange);
            Controls.Add(chbSerieOpenOrange);
            Controls.Add(chbPriceOpenOrange);
            Controls.Add(chbQtyOpenOrange);
            Controls.Add(chbCodeOpenOrange);
            Controls.Add(label19);
            Controls.Add(label20);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(label24);
            Controls.Add(txtDueDateOpenOrange);
            Controls.Add(txtSerieOpenOrange);
            Controls.Add(txtPriceOpenOrange);
            Controls.Add(txtQtyOpenOrange);
            Controls.Add(txtCodeOpenOrange);

            Name = "FrmSettingsSystem";
            Text = "Configuraciones del Sistema";
            Load += FrmSettingSystem_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label4;
        private TextBox txtArticlePrice;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel PanelMissItemColorSetting;
        private Panel PanelColorDiffSetting;
        private Button btnChangeMissItemColor;
        private Button btnChangeDiffColor;
        private CheckBox chbKitOpenOrange;
        private Label label26;
        private TextBox txtKitOpenOrange;
        private CheckBox chbBatchOpenOrange;
        private Label label25;
        private TextBox txtBatchOpenOrange;
        private CheckBox chbDueDateOpenOrange;
        private CheckBox chbSerieOpenOrange;
        private CheckBox chbPriceOpenOrange;
        private CheckBox chbQtyOpenOrange;
        private CheckBox chbCodeOpenOrange;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private TextBox txtDueDateOpenOrange;
        private TextBox txtSerieOpenOrange;
        private TextBox txtPriceOpenOrange;
        private TextBox txtQtyOpenOrange;
        private TextBox txtCodeOpenOrange;
    }
}