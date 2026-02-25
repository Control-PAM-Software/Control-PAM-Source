using System.Windows.Forms;

namespace Control
{
    partial class FrmSettingsBernafon
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label18 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label17 = new Label();
            label14 = new Label();
            label13 = new Label();
            txtCodeReceipt = new TextBox();
            txtQtyReceipt = new TextBox();
            txtDescriptionReceipt = new TextBox();
            txtSerialReceipt = new TextBox();
            txtDueDateReceipt = new TextBox();
            txtCodeInventory = new TextBox();
            txtQtyInventory = new TextBox();
            txtDescriptionInventory = new TextBox();
            txtSerialInventory = new TextBox();
            txtDueDateInventory = new TextBox();
            txtCodeMovements = new TextBox();
            txtQtyMovements = new TextBox();
            gdvCodigosDesglose = new DataGridView();
            ArtCode = new DataGridViewTextBoxColumn();
            btnExport = new Button();
            btnImport = new Button();
            ((System.ComponentModel.ISupportInitialize)gdvCodigosDesglose).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(39, 39, 58);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(178, 30);
            label1.TabIndex = 0;
            label1.Text = "Ingreso de Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(39, 39, 58);
            label2.Location = new Point(480, 20);
            label2.Name = "label2";
            label2.Size = new Size(114, 30);
            label2.TabIndex = 1;
            label2.Text = "Inventario";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label18.ForeColor = Color.FromArgb(39, 39, 58);
            label18.Location = new Point(25, 255);
            label18.Name = "label18";
            label18.Size = new Size(225, 30);
            label18.TabIndex = 2;
            label18.Text = "Movimiento de Stock";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9.5F);
            label3.Location = new Point(35, 70);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 7;
            label3.Text = "Código:";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.Location = new Point(35, 105);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 8;
            label4.Text = "Unidades:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9.5F);
            label5.Location = new Point(35, 140);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 9;
            label5.Text = "Descripción:";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.Location = new Point(35, 175);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 10;
            label6.Text = "Núm. Serie:";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9.5F);
            label7.Location = new Point(35, 210);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 11;
            label7.Text = "Vencimiento:";
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 9.5F);
            label12.Location = new Point(490, 70);
            label12.Name = "label12";
            label12.Size = new Size(100, 23);
            label12.TabIndex = 16;
            label12.Text = "Código:";
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9.5F);
            label11.Location = new Point(490, 105);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 15;
            label11.Text = "Unidades:";
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 9.5F);
            label10.Location = new Point(490, 140);
            label10.Name = "label10";
            label10.Size = new Size(100, 23);
            label10.TabIndex = 14;
            label10.Text = "Descripción:";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9.5F);
            label9.Location = new Point(490, 175);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 13;
            label9.Text = "Núm. Serie:";
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9.5F);
            label8.Location = new Point(490, 210);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 12;
            label8.Text = "Vencimiento:";
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 9.5F);
            label17.Location = new Point(35, 300);
            label17.Name = "label17";
            label17.Size = new Size(100, 23);
            label17.TabIndex = 18;
            label17.Text = "Código:";
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 9.5F);
            label14.Location = new Point(35, 335);
            label14.Name = "label14";
            label14.Size = new Size(100, 23);
            label14.TabIndex = 17;
            label14.Text = "Unidades:";
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 9.5F);
            label13.Location = new Point(490, 260);
            label13.Name = "label13";
            label13.Size = new Size(100, 23);
            label13.TabIndex = 3;
            label13.Text = "Códigos Desglose:";
            // 
            // txtCodeReceipt
            // 
            txtCodeReceipt.Location = new Point(160, 68);
            txtCodeReceipt.Name = "txtCodeReceipt";
            txtCodeReceipt.Size = new Size(200, 23);
            txtCodeReceipt.TabIndex = 19;
            // 
            // txtQtyReceipt
            // 
            txtQtyReceipt.Location = new Point(160, 103);
            txtQtyReceipt.Name = "txtQtyReceipt";
            txtQtyReceipt.Size = new Size(200, 23);
            txtQtyReceipt.TabIndex = 20;
            // 
            // txtDescriptionReceipt
            // 
            txtDescriptionReceipt.Location = new Point(160, 138);
            txtDescriptionReceipt.Name = "txtDescriptionReceipt";
            txtDescriptionReceipt.Size = new Size(200, 23);
            txtDescriptionReceipt.TabIndex = 21;
            // 
            // txtSerialReceipt
            // 
            txtSerialReceipt.Location = new Point(160, 173);
            txtSerialReceipt.Name = "txtSerialReceipt";
            txtSerialReceipt.Size = new Size(200, 23);
            txtSerialReceipt.TabIndex = 22;
            // 
            // txtDueDateReceipt
            // 
            txtDueDateReceipt.Location = new Point(160, 208);
            txtDueDateReceipt.Name = "txtDueDateReceipt";
            txtDueDateReceipt.Size = new Size(200, 23);
            txtDueDateReceipt.TabIndex = 23;
            // 
            // txtCodeInventory
            // 
            txtCodeInventory.Location = new Point(640, 68);
            txtCodeInventory.Name = "txtCodeInventory";
            txtCodeInventory.Size = new Size(200, 23);
            txtCodeInventory.TabIndex = 24;
            // 
            // txtQtyInventory
            // 
            txtQtyInventory.Location = new Point(640, 103);
            txtQtyInventory.Name = "txtQtyInventory";
            txtQtyInventory.Size = new Size(200, 23);
            txtQtyInventory.TabIndex = 25;
            // 
            // txtDescriptionInventory
            // 
            txtDescriptionInventory.Location = new Point(640, 138);
            txtDescriptionInventory.Name = "txtDescriptionInventory";
            txtDescriptionInventory.Size = new Size(200, 23);
            txtDescriptionInventory.TabIndex = 26;
            // 
            // txtSerialInventory
            // 
            txtSerialInventory.Location = new Point(640, 173);
            txtSerialInventory.Name = "txtSerialInventory";
            txtSerialInventory.Size = new Size(200, 23);
            txtSerialInventory.TabIndex = 27;
            // 
            // txtDueDateInventory
            // 
            txtDueDateInventory.Location = new Point(640, 208);
            txtDueDateInventory.Name = "txtDueDateInventory";
            txtDueDateInventory.Size = new Size(200, 23);
            txtDueDateInventory.TabIndex = 28;
            // 
            // txtCodeMovements
            // 
            txtCodeMovements.Location = new Point(160, 298);
            txtCodeMovements.Name = "txtCodeMovements";
            txtCodeMovements.Size = new Size(200, 23);
            txtCodeMovements.TabIndex = 29;
            // 
            // txtQtyMovements
            // 
            txtQtyMovements.Location = new Point(160, 333);
            txtQtyMovements.Name = "txtQtyMovements";
            txtQtyMovements.Size = new Size(200, 23);
            txtQtyMovements.TabIndex = 30;
            // 
            // gdvCodigosDesglose
            // 
            gdvCodigosDesglose.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            gdvCodigosDesglose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            gdvCodigosDesglose.ColumnHeadersHeight = 30;
            gdvCodigosDesglose.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gdvCodigosDesglose.Columns.AddRange(new DataGridViewColumn[] { ArtCode });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            gdvCodigosDesglose.DefaultCellStyle = dataGridViewCellStyle5;
            gdvCodigosDesglose.EnableHeadersVisualStyles = false;
            gdvCodigosDesglose.Location = new Point(490, 285);
            gdvCodigosDesglose.Name = "gdvCodigosDesglose";
            dataGridViewCellStyle6.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(64, 64, 64);
            gdvCodigosDesglose.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gdvCodigosDesglose.RowHeadersWidth = 30;
            gdvCodigosDesglose.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            gdvCodigosDesglose.Size = new Size(350, 160);
            gdvCodigosDesglose.TabIndex = 4;
            gdvCodigosDesglose.RowPostPaint += dataGridView1_RowPostPaint;
            // 
            // ArtCode
            // 
            ArtCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ArtCode.HeaderText = "Código de Artículo";
            ArtCode.Name = "ArtCode";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.White;
            btnExport.FlatAppearance.BorderColor = Color.LightGray;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Location = new Point(35, 385);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(150, 35);
            btnExport.TabIndex = 5;
            btnExport.Text = "Exportar Datos";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.White;
            btnImport.FlatAppearance.BorderColor = Color.LightGray;
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Location = new Point(210, 385);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(150, 35);
            btnImport.TabIndex = 6;
            btnImport.Text = "Importar Datos";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // FrmSettingsBernafon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 251, 252);
            ClientSize = new Size(950, 480);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label18);
            Controls.Add(label13);
            Controls.Add(gdvCodigosDesglose);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
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
            Controls.Add(label14);
            Controls.Add(label17);
            Controls.Add(txtCodeReceipt);
            Controls.Add(txtQtyReceipt);
            Controls.Add(txtDescriptionReceipt);
            Controls.Add(txtSerialReceipt);
            Controls.Add(txtDueDateReceipt);
            Controls.Add(txtCodeInventory);
            Controls.Add(txtQtyInventory);
            Controls.Add(txtDescriptionInventory);
            Controls.Add(txtSerialInventory);
            Controls.Add(txtDueDateInventory);
            Controls.Add(txtCodeMovements);
            Controls.Add(txtQtyMovements);
            Name = "FrmSettingsBernafon";
            Text = "Configuración Bernafon";
            Load += FrmSettingsBernafon_Load;
            ((System.ComponentModel.ISupportInitialize)gdvCodigosDesglose).EndInit();
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
        private Label label14;
        private Label label17;
        private Label label18;
        private TextBox txtQtyMovements;
        private TextBox txtCodeMovements;
        private Label label13;
        private DataGridView gdvCodigosDesglose;
        private DataGridViewTextBoxColumn ArtCode;
        private Button btnExport;
        private Button btnImport;
    }
}