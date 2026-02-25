namespace Control
{
    partial class FrmSettingsOticom
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
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDueDateInventory = new TextBox();
            txtSerialInventory = new TextBox();
            txtDescriptionInventory = new TextBox();
            txtQtyInventory = new TextBox();
            txtCodeInventory = new TextBox();
            txtDueDateReceipt = new TextBox();
            txtSerialReceipt = new TextBox();
            txtDescriptionReceipt = new TextBox();
            txtQtyReceipt = new TextBox();
            txtCodeReceipt = new TextBox();
            SuspendLayout();

            // --- ENCABEZADOS DE SECCIÓN ---
            // label1: Ingreso de Stock
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(39, 39, 58);
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(181, 30);
            label1.Text = "Ingreso de Stock";

            // label2: Inventario
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(39, 39, 58);
            label2.Location = new Point(480, 20);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.Text = "Inventario";

            // --- COLUMNA IZQUIERDA: INGRESO DE STOCK ---
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

            // --- COLUMNA DERECHA: INVENTARIO ---
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

            // --- CONFIGURACIÓN DEL FORMULARIO ---
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 247, 251); // Fondo suave
            ClientSize = new Size(983, 461);

            // Adición de controles
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(txtDueDateInventory);
            Controls.Add(txtSerialInventory);
            Controls.Add(txtDescriptionInventory);
            Controls.Add(txtQtyInventory);
            Controls.Add(txtCodeInventory);
            Controls.Add(txtDueDateReceipt);
            Controls.Add(txtSerialReceipt);
            Controls.Add(txtDescriptionReceipt);
            Controls.Add(txtQtyReceipt);
            Controls.Add(txtCodeReceipt);

            Name = "FrmSettingsOticom";
            Text = "Configuración Oticom";
            Load += FrmSettingsOticom_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDueDateInventory;
        private TextBox txtSerialInventory;
        private TextBox txtDescriptionInventory;
        private TextBox txtQtyInventory;
        private TextBox txtCodeInventory;
        private TextBox txtDueDateReceipt;
        private TextBox txtSerialReceipt;
        private TextBox txtDescriptionReceipt;
        private TextBox txtQtyReceipt;
        private TextBox txtCodeReceipt;
    }
}