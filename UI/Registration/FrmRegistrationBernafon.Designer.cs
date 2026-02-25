namespace Control
{
    partial class FrmRegistrationBernafon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            tabAnexo = new TabPage();
            dataGridView1 = new DataGridView();
            QuantityItem = new DataGridViewTextBoxColumn();
            CodItem = new DataGridViewTextBoxColumn();
            DescriptionItem = new DataGridViewTextBoxColumn();
            SerialNumber = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            panel10 = new Panel();
            cbNoahLink = new CheckBox();
            LblQty = new Label();
            panel8 = new Panel();
            BtnTests = new Button();
            BtnCleanAnexo = new Button();
            BtnCreateOpenOrange = new Button();
            BtnCompare = new Button();
            BtnPasteAnexo = new Button();
            panel9 = new Panel();
            label5 = new Label();
            tabReceived = new TabPage();
            dataGridViewReceived = new DataGridView();
            UnitsReceivedInventory = new DataGridViewTextBoxColumn();
            SerialReceivedInventory = new DataGridViewTextBoxColumn();
            panel17 = new Panel();
            BtnHelp = new Button();
            label10 = new Label();
            TxtPickInputReceived = new TextBox();
            panel2 = new Panel();
            BtnCleanReceived = new Button();
            BtnHasPila = new Button();
            panel16 = new Panel();
            label9 = new Label();
            tabControl.SuspendLayout();
            tabAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            tabReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceived).BeginInit();
            panel17.SuspendLayout();
            panel2.SuspendLayout();
            panel16.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.Controls.Add(tabAnexo);
            tabControl.Controls.Add(tabReceived);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Cascadia Mono", 10F, FontStyle.Bold);
            tabControl.ItemSize = new Size(100, 40);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(50, 3);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1207, 588);
            tabControl.TabIndex = 8;
            // 
            // tabAnexo
            // 
            tabAnexo.BackColor = Color.FromArgb(51, 51, 76);
            tabAnexo.Controls.Add(dataGridView1);
            tabAnexo.Controls.Add(panel10);
            tabAnexo.Controls.Add(panel8);
            tabAnexo.Font = new Font("Segoe UI", 10F);
            tabAnexo.Location = new Point(4, 4);
            tabAnexo.Margin = new Padding(0);
            tabAnexo.Name = "tabAnexo";
            tabAnexo.Size = new Size(1199, 540);
            tabAnexo.TabIndex = 0;
            tabAnexo.Text = "Anexo";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.InactiveBorder;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { QuantityItem, CodItem, DescriptionItem, SerialNumber, DueDate });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(200, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.Size = new Size(999, 460);
            dataGridView1.TabIndex = 27;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            // 
            // QuantityItem
            // 
            QuantityItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QuantityItem.HeaderText = "Unidades";
            QuantityItem.MinimumWidth = 6;
            QuantityItem.Name = "QuantityItem";
            // 
            // CodItem
            // 
            CodItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodItem.DataPropertyName = "CodItem";
            CodItem.HeaderText = "Código";
            CodItem.MinimumWidth = 6;
            CodItem.Name = "CodItem";
            // 
            // DescriptionItem
            // 
            DescriptionItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescriptionItem.HeaderText = "Descripción";
            DescriptionItem.MinimumWidth = 6;
            DescriptionItem.Name = "DescriptionItem";
            // 
            // SerialNumber
            // 
            SerialNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialNumber.DataPropertyName = "SerialNumber";
            SerialNumber.HeaderText = "Número de Serie";
            SerialNumber.MinimumWidth = 6;
            SerialNumber.Name = "SerialNumber";
            // 
            // DueDate
            // 
            DueDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DueDate.HeaderText = "Vencimiento";
            DueDate.MinimumWidth = 6;
            DueDate.Name = "DueDate";
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(39, 39, 58);
            panel10.Controls.Add(cbNoahLink);
            panel10.Controls.Add(LblQty);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(200, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(999, 80);
            panel10.TabIndex = 1;
            // 
            // cbNoahLink
            // 
            cbNoahLink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbNoahLink.AutoSize = true;
            cbNoahLink.BackColor = Color.Transparent;
            cbNoahLink.ForeColor = Color.White;
            cbNoahLink.Location = new Point(860, 32);
            cbNoahLink.Name = "cbNoahLink";
            cbNoahLink.RightToLeft = RightToLeft.Yes;
            cbNoahLink.Size = new Size(90, 23);
            cbNoahLink.TabIndex = 47;
            cbNoahLink.Text = "Noah Link";
            cbNoahLink.UseVisualStyleBackColor = false;
            // 
            // LblQty
            // 
            LblQty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LblQty.AutoSize = true;
            LblQty.ForeColor = Color.White;
            LblQty.Location = new Point(803, 5);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(149, 19);
            LblQty.TabIndex = 46;
            LblQty.Text = "Audífonos Restantes: 0";
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(51, 51, 76);
            panel8.Controls.Add(BtnTests);
            panel8.Controls.Add(BtnCleanAnexo);
            panel8.Controls.Add(BtnCreateOpenOrange);
            panel8.Controls.Add(BtnCompare);
            panel8.Controls.Add(BtnPasteAnexo);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 540);
            panel8.TabIndex = 0;
            // 
            // BtnTests
            // 
            BtnTests.Cursor = Cursors.Hand;
            BtnTests.Dock = DockStyle.Top;
            BtnTests.FlatAppearance.BorderSize = 0;
            BtnTests.FlatStyle = FlatStyle.Flat;
            BtnTests.ForeColor = Color.Gainsboro;
            BtnTests.Image = Properties.Resources.CopyPaste1;
            BtnTests.ImageAlign = ContentAlignment.MiddleLeft;
            BtnTests.Location = new Point(0, 300);
            BtnTests.Name = "BtnTests";
            BtnTests.Padding = new Padding(12, 0, 0, 0);
            BtnTests.Size = new Size(200, 55);
            BtnTests.TabIndex = 6;
            BtnTests.Text = "   Pruebas";
            BtnTests.TextAlign = ContentAlignment.MiddleLeft;
            BtnTests.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnTests.UseVisualStyleBackColor = true;
            BtnTests.Click += BtnTests_Click;
            // 
            // BtnCleanAnexo
            // 
            BtnCleanAnexo.BackColor = Color.FromArgb(51, 51, 76);
            BtnCleanAnexo.Cursor = Cursors.Hand;
            BtnCleanAnexo.Dock = DockStyle.Top;
            BtnCleanAnexo.FlatAppearance.BorderSize = 0;
            BtnCleanAnexo.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanAnexo.FlatStyle = FlatStyle.Flat;
            BtnCleanAnexo.ForeColor = Color.Gainsboro;
            BtnCleanAnexo.Image = Properties.Resources.Clean;
            BtnCleanAnexo.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCleanAnexo.Location = new Point(0, 245);
            BtnCleanAnexo.Name = "BtnCleanAnexo";
            BtnCleanAnexo.Padding = new Padding(12, 0, 0, 0);
            BtnCleanAnexo.Size = new Size(200, 55);
            BtnCleanAnexo.TabIndex = 5;
            BtnCleanAnexo.Text = "   Limpiar";
            BtnCleanAnexo.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanAnexo.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCleanAnexo.UseVisualStyleBackColor = false;
            BtnCleanAnexo.Click += BtnCleanAnexo_Click;
            // 
            // BtnCreateOpenOrange
            // 
            BtnCreateOpenOrange.Cursor = Cursors.Hand;
            BtnCreateOpenOrange.Dock = DockStyle.Top;
            BtnCreateOpenOrange.FlatAppearance.BorderSize = 0;
            BtnCreateOpenOrange.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCreateOpenOrange.FlatStyle = FlatStyle.Flat;
            BtnCreateOpenOrange.ForeColor = Color.Gainsboro;
            BtnCreateOpenOrange.Image = Properties.Resources.OpenOrange;
            BtnCreateOpenOrange.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCreateOpenOrange.Location = new Point(0, 190);
            BtnCreateOpenOrange.Name = "BtnCreateOpenOrange";
            BtnCreateOpenOrange.Padding = new Padding(12, 0, 0, 0);
            BtnCreateOpenOrange.Size = new Size(200, 55);
            BtnCreateOpenOrange.TabIndex = 7;
            BtnCreateOpenOrange.Text = "   Open Orange";
            BtnCreateOpenOrange.TextAlign = ContentAlignment.MiddleLeft;
            BtnCreateOpenOrange.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCreateOpenOrange.UseVisualStyleBackColor = true;
            BtnCreateOpenOrange.Click += BtnCreateOpenOrange_Click;
            // 
            // BtnCompare
            // 
            BtnCompare.Cursor = Cursors.Hand;
            BtnCompare.Dock = DockStyle.Top;
            BtnCompare.FlatAppearance.BorderSize = 0;
            BtnCompare.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCompare.FlatStyle = FlatStyle.Flat;
            BtnCompare.ForeColor = Color.Gainsboro;
            BtnCompare.Image = Properties.Resources.Compare1;
            BtnCompare.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCompare.Location = new Point(0, 135);
            BtnCompare.Name = "BtnCompare";
            BtnCompare.Padding = new Padding(12, 0, 0, 0);
            BtnCompare.Size = new Size(200, 55);
            BtnCompare.TabIndex = 3;
            BtnCompare.Text = "   Comparar";
            BtnCompare.TextAlign = ContentAlignment.MiddleLeft;
            BtnCompare.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCompare.UseVisualStyleBackColor = true;
            BtnCompare.Click += BtnCompare_Click;
            // 
            // BtnPasteAnexo
            // 
            BtnPasteAnexo.Cursor = Cursors.Hand;
            BtnPasteAnexo.Dock = DockStyle.Top;
            BtnPasteAnexo.FlatAppearance.BorderSize = 0;
            BtnPasteAnexo.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnPasteAnexo.FlatStyle = FlatStyle.Flat;
            BtnPasteAnexo.ForeColor = Color.Gainsboro;
            BtnPasteAnexo.Image = Properties.Resources.CopyPaste2;
            BtnPasteAnexo.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPasteAnexo.Location = new Point(0, 80);
            BtnPasteAnexo.Name = "BtnPasteAnexo";
            BtnPasteAnexo.Padding = new Padding(12, 0, 0, 0);
            BtnPasteAnexo.Size = new Size(200, 55);
            BtnPasteAnexo.TabIndex = 2;
            BtnPasteAnexo.Text = "   Pegar Anexo";
            BtnPasteAnexo.TextAlign = ContentAlignment.MiddleLeft;
            BtnPasteAnexo.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnPasteAnexo.UseVisualStyleBackColor = true;
            BtnPasteAnexo.Click += BtnPasteAnexo_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(39, 39, 58);
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 80);
            panel9.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(31, 28);
            label5.Name = "label5";
            label5.Size = new Size(133, 20);
            label5.TabIndex = 2;
            label5.Text = "Ingreso Bernafon";
            // 
            // tabReceived
            // 
            tabReceived.BackColor = Color.Transparent;
            tabReceived.Controls.Add(dataGridViewReceived);
            tabReceived.Controls.Add(panel17);
            tabReceived.Controls.Add(panel2);
            tabReceived.Font = new Font("Segoe UI", 10F);
            tabReceived.Location = new Point(4, 4);
            tabReceived.Margin = new Padding(0);
            tabReceived.Name = "tabReceived";
            tabReceived.Size = new Size(1199, 540);
            tabReceived.TabIndex = 2;
            tabReceived.Text = "Físico";
            // 
            // dataGridViewReceived
            // 
            dataGridViewReceived.AllowUserToAddRows = false;
            dataGridViewReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceived.BackgroundColor = SystemColors.InactiveBorder;
            dataGridViewReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceived.Columns.AddRange(new DataGridViewColumn[] { UnitsReceivedInventory, SerialReceivedInventory });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewReceived.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewReceived.Dock = DockStyle.Fill;
            dataGridViewReceived.Location = new Point(200, 80);
            dataGridViewReceived.Name = "dataGridViewReceived";
            dataGridViewReceived.RowHeadersWidth = 51;
            dataGridViewReceived.Size = new Size(999, 460);
            dataGridViewReceived.TabIndex = 30;
            // 
            // UnitsReceivedInventory
            // 
            UnitsReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UnitsReceivedInventory.DataPropertyName = "UnitsReceivedInventory";
            UnitsReceivedInventory.HeaderText = "Unidades";
            UnitsReceivedInventory.MinimumWidth = 6;
            UnitsReceivedInventory.Name = "UnitsReceivedInventory";
            // 
            // SerialReceivedInventory
            // 
            SerialReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialReceivedInventory.DataPropertyName = "SerialReceivedInventory";
            SerialReceivedInventory.HeaderText = "Número de Serie";
            SerialReceivedInventory.MinimumWidth = 6;
            SerialReceivedInventory.Name = "SerialReceivedInventory";
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(39, 39, 58);
            panel17.Controls.Add(BtnHelp);
            panel17.Controls.Add(label10);
            panel17.Controls.Add(TxtPickInputReceived);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(200, 0);
            panel17.Name = "panel17";
            panel17.Size = new Size(999, 80);
            panel17.TabIndex = 17;
            // 
            // BtnHelp
            // 
            BtnHelp.BackColor = Color.Transparent;
            BtnHelp.Cursor = Cursors.Hand;
            BtnHelp.FlatAppearance.BorderSize = 0;
            BtnHelp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnHelp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnHelp.FlatStyle = FlatStyle.Flat;
            BtnHelp.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnHelp.Image = Properties.Resources.Help;
            BtnHelp.Location = new Point(6, 5);
            BtnHelp.Name = "BtnHelp";
            BtnHelp.Size = new Size(44, 40);
            BtnHelp.TabIndex = 29;
            BtnHelp.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(667, 12);
            label10.Name = "label10";
            label10.Size = new Size(111, 19);
            label10.TabIndex = 28;
            label10.Text = "Número de Serie";
            // 
            // TxtPickInputReceived
            // 
            TxtPickInputReceived.Anchor = AnchorStyles.Right;
            TxtPickInputReceived.Font = new Font("Segoe UI", 10F);
            TxtPickInputReceived.Location = new Point(808, 9);
            TxtPickInputReceived.Name = "TxtPickInputReceived";
            TxtPickInputReceived.Size = new Size(183, 25);
            TxtPickInputReceived.TabIndex = 26;
            TxtPickInputReceived.KeyDown += TxtPickInputReceived_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(BtnCleanReceived);
            panel2.Controls.Add(BtnHasPila);
            panel2.Controls.Add(panel16);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 540);
            panel2.TabIndex = 16;
            // 
            // BtnCleanReceived
            // 
            BtnCleanReceived.Cursor = Cursors.Hand;
            BtnCleanReceived.Dock = DockStyle.Top;
            BtnCleanReceived.FlatAppearance.BorderSize = 0;
            BtnCleanReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanReceived.FlatStyle = FlatStyle.Flat;
            BtnCleanReceived.ForeColor = Color.Gainsboro;
            BtnCleanReceived.Image = Properties.Resources.Clean;
            BtnCleanReceived.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCleanReceived.Location = new Point(0, 135);
            BtnCleanReceived.Name = "BtnCleanReceived";
            BtnCleanReceived.Padding = new Padding(12, 0, 0, 0);
            BtnCleanReceived.Size = new Size(200, 55);
            BtnCleanReceived.TabIndex = 5;
            BtnCleanReceived.Text = "   Limpiar";
            BtnCleanReceived.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCleanReceived.UseVisualStyleBackColor = true;
            BtnCleanReceived.Click += BtnCleanReceived_Click;
            // 
            // BtnHasPila
            // 
            BtnHasPila.Cursor = Cursors.Hand;
            BtnHasPila.Dock = DockStyle.Top;
            BtnHasPila.FlatAppearance.BorderSize = 0;
            BtnHasPila.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnHasPila.FlatStyle = FlatStyle.Flat;
            BtnHasPila.ForeColor = Color.Gainsboro;
            BtnHasPila.Image = Properties.Resources.qr;
            BtnHasPila.ImageAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.Location = new Point(0, 80);
            BtnHasPila.Name = "BtnHasPila";
            BtnHasPila.Padding = new Padding(12, 0, 0, 0);
            BtnHasPila.Size = new Size(200, 55);
            BtnHasPila.TabIndex = 2;
            BtnHasPila.Text = "   Generar QR";
            BtnHasPila.TextAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnHasPila.UseVisualStyleBackColor = true;
            BtnHasPila.Click += BtnGenerateQr;
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(39, 39, 58);
            panel16.Controls.Add(label9);
            panel16.Dock = DockStyle.Top;
            panel16.Location = new Point(0, 0);
            panel16.Name = "panel16";
            panel16.Size = new Size(200, 80);
            panel16.TabIndex = 1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Gainsboro;
            label9.Location = new Point(60, 27);
            label9.Name = "label9";
            label9.Size = new Size(81, 20);
            label9.TabIndex = 2;
            label9.Text = "Audífonos";
            // 
            // FrmRegistrationBernafon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 588);
            Controls.Add(tabControl);
            Name = "FrmRegistrationBernafon";
            Text = "Ingreso Bernafon";
            Load += FrmInventoryBernafon_Load;
            tabControl.ResumeLayout(false);
            tabAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabReceived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceived).EndInit();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel2.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabAnexo;
        private DataGridView dataGridView1;
        private Panel panel10;
        private Panel panel8;
        private Button BtnTests;
        private Button BtnCleanAnexo;
        private Button BtnCompare;
        private Button BtnPasteAnexo;
        private Panel panel9;
        private Label label5;
        private TabPage tabReceived;
        private DataGridView dataGridViewReceived;
        private Panel panel17;
        private Button BtnHelp;
        private Label label10;
        private Label label11;
        private TextBox TxtPickInputReceived;
        private TextBox TxtPickCodeReceived;
        private Panel panel2;
        private Button BtnCleanReceived;
        private Button BtnHasPila;
        private Panel panel16;
        private Label label9;
        private DataGridViewTextBoxColumn UnitsReceivedInventory;
        private DataGridViewTextBoxColumn SerialReceivedInventory;
        private Label LblQty;
        private CheckBox cbNoahLink;
        private DataGridViewTextBoxColumn QuantityItem;
        private DataGridViewTextBoxColumn CodItem;
        private DataGridViewTextBoxColumn DescriptionItem;
        private DataGridViewTextBoxColumn SerialNumber;
        private DataGridViewTextBoxColumn DueDate;
        private Button BtnCreateOpenOrange;
    }
}