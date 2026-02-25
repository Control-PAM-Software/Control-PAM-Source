namespace Control
{
    partial class FrmGenerateQr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerateQr));
            lblName = new Label();
            lblLastName = new Label();
            lblSerie = new Label();
            txtName = new TextBox();
            txtLastName = new TextBox();
            txtSerie = new TextBox();
            btnGenerateQr = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F);
            lblName.ForeColor = Color.FromArgb(200, 200, 220);
            lblName.Location = new Point(40, 75);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 17);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9.5F);
            lblLastName.ForeColor = Color.FromArgb(200, 200, 220);
            lblLastName.Location = new Point(40, 135);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(56, 17);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Apellido";
            // 
            // lblSerie
            // 
            lblSerie.AutoSize = true;
            lblSerie.Font = new Font("Segoe UI", 9.5F);
            lblSerie.ForeColor = Color.FromArgb(200, 200, 220);
            lblSerie.Location = new Point(40, 195);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(130, 17);
            lblSerie.TabIndex = 2;
            lblSerie.Text = "Serie del Procesador";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(64, 64, 95);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(40, 97);
            txtName.Name = "txtName";
            txtName.Size = new Size(330, 25);
            txtName.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(64, 64, 95);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.ForeColor = Color.White;
            txtLastName.Location = new Point(40, 157);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 25);
            txtLastName.TabIndex = 4;
            // 
            // txtSerie
            // 
            txtSerie.BackColor = Color.FromArgb(64, 64, 95);
            txtSerie.BorderStyle = BorderStyle.FixedSingle;
            txtSerie.Font = new Font("Segoe UI", 10F);
            txtSerie.ForeColor = Color.White;
            txtSerie.Location = new Point(40, 217);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(330, 25);
            txtSerie.TabIndex = 5;
            // 
            // btnGenerateQr
            // 
            btnGenerateQr.BackColor = Color.FromArgb(0, 122, 204);
            btnGenerateQr.Cursor = Cursors.Hand;
            btnGenerateQr.FlatAppearance.BorderSize = 0;
            btnGenerateQr.FlatStyle = FlatStyle.Flat;
            btnGenerateQr.Font = new Font("Segoe UI Semibold", 10F);
            btnGenerateQr.ForeColor = Color.White;
            btnGenerateQr.Location = new Point(40, 270);
            btnGenerateQr.Name = "btnGenerateQr";
            btnGenerateQr.Size = new Size(330, 40);
            btnGenerateQr.TabIndex = 6;
            btnGenerateQr.Text = "GENERAR QR";
            btnGenerateQr.UseVisualStyleBackColor = false;
            btnGenerateQr.Click += btnGenerateQr_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(215, 28);
            label1.TabIndex = 7;
            label1.Text = "Generar QR para Valija";
            // 
            // FrmGenerateQr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 76);
            ClientSize = new Size(415, 340);
            Controls.Add(label1);
            Controls.Add(btnGenerateQr);
            Controls.Add(txtSerie);
            Controls.Add(txtLastName);
            Controls.Add(txtName);
            Controls.Add(lblSerie);
            Controls.Add(lblLastName);
            Controls.Add(lblName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmGenerateQr";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Generador de Códigos QR";
            Load += FrmGenerateQr_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblLastName;
        private Label lblSerie;
        private TextBox txtName;
        private TextBox txtLastName;
        private TextBox txtSerie;
        private Button btnGenerateQr;
        private Label label1;
    }
}