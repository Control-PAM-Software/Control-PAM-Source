namespace Control
{
    partial class FrmSettingsAB
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
            txtSerialInventory = new TextBox();
            txtDescriptionInventory = new TextBox();
            txtQtyInventory = new TextBox();
            txtCodeInventory = new TextBox();
            txtDueDateReceipt = new TextBox();
            txtSerialReceipt = new TextBox();
            txtDescriptionReceipt = new TextBox();
            txtQtyReceipt = new TextBox();
            txtCodeReceipt = new TextBox();
            txtDueDateInventory = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            txtDueDateAccessories = new TextBox();
            txtserialAccessories = new TextBox();
            txtDescriptionAccessories = new TextBox();
            txtQtyAccessories = new TextBox();
            txtCodeAccessories = new TextBox();
            SuspendLayout();

            // --- ENCABEZADOS DE SECCIÓN ---
            // label1: Ingreso Valijas
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(39, 39, 58);
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(155, 30);
            label1.Text = "Ingreso Valijas";

            // label2: Inventario
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(39, 39, 58);
            label2.Location = new Point(480, 20);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.Text = "Inventario";

            // label18: Ingreso Accesorios
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label18.ForeColor = Color.FromArgb(39, 39, 58);
            label18.Location = new Point(30, 260);
            label18.Name = "label18";
            label18.Size = new Size(198, 30);
            label18.Text = "Ingreso Accesorios";

            // --- BLOQUE 1: INGRESO VALIJAS (Columna Izquierda) ---
            // Código
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(40, 70);
            label3.Text = "Código";
            txtCodeReceipt.Location = new Point(190, 68);
            txtCodeReceipt.Name = "txtCodeReceipt";
            txtCodeReceipt.Size = new Size(200, 25);

            // Unidades
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(40, 105);
            label4.Text = "Unidades";
            txtQtyReceipt.Location = new Point(190, 103);
            txtQtyReceipt.Name = "txtQtyReceipt";
            txtQtyReceipt.Size = new Size(200, 25);

            // Descripción
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(40, 140);
            label5.Text = "Descripción";
            txtDescriptionReceipt.Location = new Point(190, 138);
            txtDescriptionReceipt.Name = "txtDescriptionReceipt";
            txtDescriptionReceipt.Size = new Size(200, 25);

            // Serie
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(40, 175);
            label6.Text = "Núm. de Serie";
            txtSerialReceipt.Location = new Point(190, 173);
            txtSerialReceipt.Name = "txtSerialReceipt";
            txtSerialReceipt.Size = new Size(200, 25);

            // Vencimiento
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(40, 210);
            label7.Text = "Vencimiento";
            txtDueDateReceipt.Location = new Point(190, 208);
            txtDueDateReceipt.Name = "txtDueDateReceipt";
            txtDueDateReceipt.Size = new Size(200, 25);


            // --- BLOQUE 2: INVENTARIO (Columna Derecha) ---
            // Código
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.Location = new Point(490, 70);
            label12.Text = "Código";
            txtCodeInventory.Location = new Point(640, 68);
            txtCodeInventory.Name = "txtCodeInventory";
            txtCodeInventory.Size = new Size(200, 25);

            // Unidades
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(490, 105);
            label11.Text = "Unidades";
            txtQtyInventory.Location = new Point(640, 103);
            txtQtyInventory.Name = "txtQtyInventory";
            txtQtyInventory.Size = new Size(200, 25);

            // Descripción
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.Location = new Point(490, 140);
            label10.Text = "Descripción";
            txtDescriptionInventory.Location = new Point(640, 138);
            txtDescriptionInventory.Name = "txtDescriptionInventory";
            txtDescriptionInventory.Size = new Size(200, 25);

            // Serie
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(490, 175);
            label9.Text = "Núm. de Serie";
            txtSerialInventory.Location = new Point(640, 173);
            txtSerialInventory.Name = "txtSerialInventory";
            txtSerialInventory.Size = new Size(200, 25);

            // Vencimiento
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(490, 210);
            label8.Text = "Vencimiento";
            txtDueDateInventory.Location = new Point(640, 208);
            txtDueDateInventory.Name = "txtDueDateInventory";
            txtDueDateInventory.Size = new Size(200, 25);


            // --- BLOQUE 3: INGRESO ACCESORIOS (Abajo) ---
            // Código
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10F);
            label17.Location = new Point(40, 310);
            label17.Text = "Código";
            txtCodeAccessories.Location = new Point(190, 308);
            txtCodeAccessories.Name = "txtCodeAccessories";
            txtCodeAccessories.Size = new Size(200, 25);

            // Unidades
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10F);
            label16.Location = new Point(40, 345);
            label16.Text = "Unidades";
            txtQtyAccessories.Location = new Point(190, 343);
            txtQtyAccessories.Name = "txtQtyAccessories";
            txtQtyAccessories.Size = new Size(200, 25);

            // Descripción
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F);
            label15.Location = new Point(40, 380);
            label15.Text = "Descripción";
            txtDescriptionAccessories.Location = new Point(190, 378);
            txtDescriptionAccessories.Name = "txtDescriptionAccessories";
            txtDescriptionAccessories.Size = new Size(200, 25);

            // Serie
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.Location = new Point(40, 415);
            label14.Text = "Núm. de Serie";
            txtserialAccessories.Location = new Point(190, 413);
            txtserialAccessories.Name = "txtserialAccessories";
            txtserialAccessories.Size = new Size(200, 25);

            // Vencimiento
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F);
            label13.Location = new Point(40, 450);
            label13.Text = "Vencimiento";
            txtDueDateAccessories.Location = new Point(190, 448);
            txtDueDateAccessories.Name = "txtDueDateAccessories";
            txtDueDateAccessories.Size = new Size(200, 25);

            // 
            // FrmSettingsAB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(983, 520);
            Padding = new Padding(0, 0, 0, 20);
            Text = "Configuración AB";

            // Agregar controles al formulario
            Controls.Add(label1); Controls.Add(label2); Controls.Add(label18);
            Controls.Add(label3); Controls.Add(txtCodeReceipt);
            Controls.Add(label4); Controls.Add(txtQtyReceipt);
            Controls.Add(label5); Controls.Add(txtDescriptionReceipt);
            Controls.Add(label6); Controls.Add(txtSerialReceipt);
            Controls.Add(label7); Controls.Add(txtDueDateReceipt);
            Controls.Add(label12); Controls.Add(txtCodeInventory);
            Controls.Add(label11); Controls.Add(txtQtyInventory);
            Controls.Add(label10); Controls.Add(txtDescriptionInventory);
            Controls.Add(label9); Controls.Add(txtSerialInventory);
            Controls.Add(label8); Controls.Add(txtDueDateInventory);
            Controls.Add(label17); Controls.Add(txtCodeAccessories);
            Controls.Add(label16); Controls.Add(txtQtyAccessories);
            Controls.Add(label15); Controls.Add(txtDescriptionAccessories);
            Controls.Add(label14); Controls.Add(txtserialAccessories);
            Controls.Add(label13); Controls.Add(txtDueDateAccessories);

            Load += FrmSettingsAB_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private TextBox txtSerialInventory;
        private TextBox txtDescriptionInventory;
        private TextBox txtQtyInventory;
        private TextBox txtCodeInventory;
        private TextBox txtDueDateReceipt;
        private TextBox txtSerialReceipt;
        private TextBox txtDescriptionReceipt;
        private TextBox txtQtyReceipt;
        private TextBox txtCodeReceipt;
        private TextBox txtDueDateInventory;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox txtDueDateAccessories;
        private TextBox txtserialAccessories;
        private TextBox txtDescriptionAccessories;
        private TextBox txtQtyAccessories;
        private TextBox txtCodeAccessories;
    }
}