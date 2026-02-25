namespace Control
{
    partial class FrmManualArticle
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualArticle));
            label11 = new Label();
            txtCodeInputUser = new TextBox();
            label1 = new Label();
            txtSerie = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtQuantity = new TextBox();
            label4 = new Label();
            TxtCode = new TextBox();
            panel1 = new Panel();
            BtnCancel = new Button();
            BtnConfirm = new Button();
            label5 = new Label();
            lblSerieInput = new Label();
            txtSerieInputUser = new TextBox();
            dtpDueDate = new DateTimePicker();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(35, 140);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 29;
            label11.Text = "Código";
            // 
            // txtCodeInputUser
            // 
            txtCodeInputUser.BackColor = Color.FromArgb(64, 64, 95);
            txtCodeInputUser.BorderStyle = BorderStyle.FixedSingle;
            txtCodeInputUser.Font = new Font("Segoe UI", 10F);
            txtCodeInputUser.ForeColor = Color.White;
            txtCodeInputUser.Location = new Point(35, 88);
            txtCodeInputUser.Name = "txtCodeInputUser";
            txtCodeInputUser.Size = new Size(170, 25);
            txtCodeInputUser.TabIndex = 0;
            txtCodeInputUser.KeyDown += txtInputUser_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(35, 175);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 31;
            label1.Text = "Serie";
            // 
            // txtSerie
            // 
            txtSerie.BackColor = Color.FromArgb(51, 51, 76);
            txtSerie.BorderStyle = BorderStyle.FixedSingle;
            txtSerie.Font = new Font("Segoe UI", 10F);
            txtSerie.ForeColor = Color.FromArgb(200, 200, 200);
            txtSerie.Location = new Point(130, 172);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(255, 25);
            txtSerie.TabIndex = 3;
            txtSerie.TextChanged += OnTextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 210);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 33;
            label2.Text = "Vencimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(255, 210);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 35;
            label3.Text = "Cant";
            // 
            // txtQuantity
            // 
            txtQuantity.BackColor = Color.FromArgb(51, 51, 76);
            txtQuantity.BorderStyle = BorderStyle.FixedSingle;
            txtQuantity.Font = new Font("Segoe UI", 10F);
            txtQuantity.ForeColor = Color.White;
            txtQuantity.Location = new Point(300, 207);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(85, 25);
            txtQuantity.TabIndex = 5;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.TextChanged += OnTextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.FromArgb(170, 170, 190);
            label4.Location = new Point(35, 70);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 37;
            label4.Text = "Código Barra / Qr";
            // 
            // TxtCode
            // 
            TxtCode.BackColor = Color.FromArgb(51, 51, 76);
            TxtCode.BorderStyle = BorderStyle.FixedSingle;
            TxtCode.Font = new Font("Segoe UI", 10F);
            TxtCode.ForeColor = Color.FromArgb(200, 200, 200);
            TxtCode.Location = new Point(130, 137);
            TxtCode.Name = "TxtCode";
            TxtCode.Size = new Size(255, 25);
            TxtCode.TabIndex = 2;
            TxtCode.TextChanged += OnTextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(BtnCancel);
            panel1.Controls.Add(BtnConfirm);
            panel1.Location = new Point(35, 265);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 50);
            panel1.TabIndex = 38;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(80, 80, 100);
            BtnCancel.Cursor = Cursors.Hand;
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Image = Properties.Resources.Cancel;
            BtnCancel.Location = new Point(300, 2);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(45, 45);
            BtnCancel.TabIndex = 7;
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnConfirm
            // 
            BtnConfirm.BackColor = Color.FromArgb(0, 122, 204);
            BtnConfirm.Cursor = Cursors.Hand;
            BtnConfirm.FlatAppearance.BorderSize = 0;
            BtnConfirm.FlatStyle = FlatStyle.Flat;
            BtnConfirm.Image = (Image)resources.GetObject("BtnConfirm.Image");
            BtnConfirm.Location = new Point(245, 2);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(45, 45);
            BtnConfirm.TabIndex = 6;
            BtnConfirm.UseVisualStyleBackColor = false;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(25, 20);
            label5.Name = "label5";
            label5.Size = new Size(253, 30);
            label5.TabIndex = 39;
            label5.Text = "Ingreso Artículo Manual";
            // 
            // lblSerieInput
            // 
            lblSerieInput.AutoSize = true;
            lblSerieInput.Font = new Font("Segoe UI", 9F);
            lblSerieInput.ForeColor = Color.FromArgb(170, 170, 190);
            lblSerieInput.Location = new Point(215, 70);
            lblSerieInput.Name = "lblSerieInput";
            lblSerieInput.Size = new Size(95, 15);
            lblSerieInput.TabIndex = 19;
            lblSerieInput.Text = "Número de Serie";
            // 
            // txtSerieInputUser
            // 
            txtSerieInputUser.BackColor = Color.FromArgb(64, 64, 95);
            txtSerieInputUser.BorderStyle = BorderStyle.FixedSingle;
            txtSerieInputUser.Font = new Font("Segoe UI", 10F);
            txtSerieInputUser.ForeColor = Color.White;
            txtSerieInputUser.Location = new Point(215, 88);
            txtSerieInputUser.Name = "txtSerieInputUser";
            txtSerieInputUser.Size = new Size(170, 25);
            txtSerieInputUser.TabIndex = 1;
            txtSerieInputUser.KeyDown += txtSerieInputUser_KeyDown;
            // 
            // dtpDueDate
            // 
            dtpDueDate.CalendarMonthBackground = Color.FromArgb(64, 64, 95);
            dtpDueDate.CustomFormat = "dd/MM/yyyy";
            dtpDueDate.Format = DateTimePickerFormat.Custom;
            dtpDueDate.Location = new Point(130, 207);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(110, 23);
            dtpDueDate.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmManualArticle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 76);
            ClientSize = new Size(420, 340);
            Controls.Add(dtpDueDate);
            Controls.Add(lblSerieInput);
            Controls.Add(txtSerieInputUser);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(TxtCode);
            Controls.Add(label3);
            Controls.Add(txtQuantity);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSerie);
            Controls.Add(label11);
            Controls.Add(txtCodeInputUser);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmManualArticle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingreso de Artículo";
            Load += FrmManualArticle_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label11;
        private TextBox txtCodeInputUser;
        private Label label1;
        private TextBox txtSerie;
        private Label label2;
        private Label label3;
        private TextBox txtQuantity;
        private Label label4;
        private TextBox TxtCode;
        private Panel panel1;
        private Button BtnConfirm;
        private Label label5;
        private Button BtnCancel;
        private Label lblSerieInput;
        private TextBox txtSerieInputUser;
        private DateTimePicker dtpDueDate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ErrorProvider errorProvider1;
    }
}