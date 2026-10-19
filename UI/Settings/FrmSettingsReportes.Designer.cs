using System.Windows.Forms;

namespace Control
{
    partial class FrmSettingsReportes
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
            label1 = new Label();
            label2 = new Label();
            label18 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label13 = new Label();
            txtMovCode = new TextBox();
            txtMovSerial = new TextBox();
            txtMovDate = new TextBox();
            txtMovFrom = new TextBox();
            txtMovTo = new TextBox();
            txtStockCode = new TextBox();
            txtStockSerial = new TextBox();
            txtStockDepot = new TextBox();
            txtStockQty = new TextBox();
            numPlazoLimite = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPlazoLimite).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(39, 39, 58);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(334, 30);
            label1.TabIndex = 0;
            label1.Text = "Listado de Movimientos de Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(39, 39, 58);
            label2.Location = new Point(480, 20);
            label2.Name = "label2";
            label2.Size = new Size(220, 30);
            label2.TabIndex = 1;
            label2.Text = "Listado de Stock Actual";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label18.ForeColor = Color.FromArgb(39, 39, 58);
            label18.Location = new Point(25, 255);
            label18.Name = "label18";
            label18.Size = new Size(96, 30);
            label18.TabIndex = 2;
            label18.Text = "General";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9.5F);
            label3.Location = new Point(35, 70);
            label3.Name = "label3";
            label3.Size = new Size(130, 23);
            label3.TabIndex = 7;
            label3.Text = "Artículo:";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.Location = new Point(35, 105);
            label4.Name = "label4";
            label4.Size = new Size(130, 23);
            label4.TabIndex = 8;
            label4.Text = "Núm. Serie:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9.5F);
            label5.Location = new Point(35, 140);
            label5.Name = "label5";
            label5.Size = new Size(130, 23);
            label5.TabIndex = 9;
            label5.Text = "Fecha:";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.Location = new Point(35, 175);
            label6.Name = "label6";
            label6.Size = new Size(130, 23);
            label6.TabIndex = 10;
            label6.Text = "Desde Depósito:";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9.5F);
            label7.Location = new Point(35, 210);
            label7.Name = "label7";
            label7.Size = new Size(130, 23);
            label7.TabIndex = 11;
            label7.Text = "Hasta Depósito:";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9.5F);
            label8.Location = new Point(490, 70);
            label8.Name = "label8";
            label8.Size = new Size(140, 23);
            label8.TabIndex = 16;
            label8.Text = "Artículo:";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9.5F);
            label9.Location = new Point(490, 105);
            label9.Name = "label9";
            label9.Size = new Size(140, 23);
            label9.TabIndex = 15;
            label9.Text = "Núm. Serie:";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 9.5F);
            label10.Location = new Point(490, 140);
            label10.Name = "label10";
            label10.Size = new Size(140, 23);
            label10.TabIndex = 14;
            label10.Text = "Depósito de Stock:";
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9.5F);
            label11.Location = new Point(490, 175);
            label11.Name = "label11";
            label11.Size = new Size(140, 23);
            label11.TabIndex = 13;
            label11.Text = "Cantidad / Stock:";
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 9.5F);
            label13.Location = new Point(35, 300);
            label13.Name = "label13";
            label13.Size = new Size(130, 23);
            label13.TabIndex = 3;
            label13.Text = "Plazo Límite (días):";
            // 
            // txtMovCode
            // 
            txtMovCode.Location = new Point(180, 68);
            txtMovCode.Name = "txtMovCode";
            txtMovCode.Size = new Size(220, 23);
            txtMovCode.TabIndex = 19;
            // 
            // txtMovSerial
            // 
            txtMovSerial.Location = new Point(180, 103);
            txtMovSerial.Name = "txtMovSerial";
            txtMovSerial.Size = new Size(220, 23);
            txtMovSerial.TabIndex = 20;
            // 
            // txtMovDate
            // 
            txtMovDate.Location = new Point(180, 138);
            txtMovDate.Name = "txtMovDate";
            txtMovDate.Size = new Size(220, 23);
            txtMovDate.TabIndex = 21;
            // 
            // txtMovFrom
            // 
            txtMovFrom.Location = new Point(180, 173);
            txtMovFrom.Name = "txtMovFrom";
            txtMovFrom.Size = new Size(220, 23);
            txtMovFrom.TabIndex = 22;
            // 
            // txtMovTo
            // 
            txtMovTo.Location = new Point(180, 208);
            txtMovTo.Name = "txtMovTo";
            txtMovTo.Size = new Size(220, 23);
            txtMovTo.TabIndex = 23;
            // 
            // txtStockCode
            // 
            txtStockCode.Location = new Point(640, 68);
            txtStockCode.Name = "txtStockCode";
            txtStockCode.Size = new Size(220, 23);
            txtStockCode.TabIndex = 24;
            // 
            // txtStockSerial
            // 
            txtStockSerial.Location = new Point(640, 103);
            txtStockSerial.Name = "txtStockSerial";
            txtStockSerial.Size = new Size(220, 23);
            txtStockSerial.TabIndex = 25;
            // 
            // txtStockDepot
            // 
            txtStockDepot.Location = new Point(640, 138);
            txtStockDepot.Name = "txtStockDepot";
            txtStockDepot.Size = new Size(220, 23);
            txtStockDepot.TabIndex = 26;
            // 
            // txtStockQty
            // 
            txtStockQty.Location = new Point(640, 173);
            txtStockQty.Name = "txtStockQty";
            txtStockQty.Size = new Size(220, 23);
            txtStockQty.TabIndex = 27;
            // 
            // numPlazoLimite
            // 
            numPlazoLimite.Location = new Point(180, 298);
            numPlazoLimite.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numPlazoLimite.Name = "numPlazoLimite";
            numPlazoLimite.Size = new Size(120, 23);
            numPlazoLimite.TabIndex = 28;
            // 
            // FrmSettingsReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 252);
            ClientSize = new Size(950, 480);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label18);
            Controls.Add(label13);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(txtMovCode);
            Controls.Add(txtMovSerial);
            Controls.Add(txtMovDate);
            Controls.Add(txtMovFrom);
            Controls.Add(txtMovTo);
            Controls.Add(txtStockCode);
            Controls.Add(txtStockSerial);
            Controls.Add(txtStockDepot);
            Controls.Add(txtStockQty);
            Controls.Add(numPlazoLimite);
            Name = "FrmSettingsReportes";
            Text = "Configuración Reportes";
            Load += FrmSettingsReportes_Load;
            ((System.ComponentModel.ISupportInitialize)numPlazoLimite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtStockQty;
        private TextBox txtStockDepot;
        private TextBox txtStockSerial;
        private TextBox txtStockCode;
        private TextBox txtMovTo;
        private TextBox txtMovFrom;
        private TextBox txtMovDate;
        private TextBox txtMovSerial;
        private TextBox txtMovCode;
        private Label label18;
        private Label label13;
        private NumericUpDown numPlazoLimite;
    }
}