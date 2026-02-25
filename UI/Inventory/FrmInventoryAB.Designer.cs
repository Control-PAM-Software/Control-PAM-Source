namespace Control
{
    partial class FrmInventoryAB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryAB));
            tabControl = new TabControl();
            tabAnexo = new TabPage();
            dataGridView1 = new DataGridView();
            QuantityItem = new DataGridViewTextBoxColumn();
            CodItem = new DataGridViewTextBoxColumn();
            DescriptionItem = new DataGridViewTextBoxColumn();
            SerialNumber = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            panel10 = new Panel();
            label6 = new Label();
            label7 = new Label();
            panelMissItemAnexo = new Panel();
            panelDiffAnexo = new Panel();
            panel8 = new Panel();
            BtnTests = new Button();
            BtnCleanAnexo = new Button();
            BtnCompare = new Button();
            BtnPasteAnexo = new Button();
            panel9 = new Panel();
            label5 = new Label();
            tabReceived = new TabPage();
            dataGridViewReceived = new DataGridView();
            UnitsReceivedInventory = new DataGridViewTextBoxColumn();
            CodItemReceivedInventory = new DataGridViewTextBoxColumn();
            SerialReceivedInventory = new DataGridViewTextBoxColumn();
            DueDateReceivedInventory = new DataGridViewTextBoxColumn();
            panel17 = new Panel();
            BtnHelp = new Button();
            label10 = new Label();
            label11 = new Label();
            TxtPickSerialNumReceived = new TextBox();
            TxtPickCodeReceived = new TextBox();
            panel2 = new Panel();
            BtnCleanReceived = new Button();
            BtnHasPila = new Button();
            panel16 = new Panel();
            label9 = new Label();
            BtnManualArticle = new Button();
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
            tabControl.Size = new Size(1207, 615);
            tabControl.TabIndex = 7;
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
            tabAnexo.Size = new Size(1199, 567);
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
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.Size = new Size(999, 487);
            dataGridView1.TabIndex = 27;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            // 
            // QuantityItem
            // 
            QuantityItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            QuantityItem.HeaderText = "Unidades";
            QuantityItem.Name = "QuantityItem";
            // 
            // CodItem
            // 
            CodItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodItem.HeaderText = "Código";
            CodItem.Name = "CodItem";
            // 
            // DescriptionItem
            // 
            DescriptionItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescriptionItem.HeaderText = "Descripción";
            DescriptionItem.Name = "DescriptionItem";
            // 
            // SerialNumber
            // 
            SerialNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialNumber.HeaderText = "Número de Serie";
            SerialNumber.Name = "SerialNumber";
            // 
            // DueDate
            // 
            DueDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DueDate.HeaderText = "Vencimiento";
            DueDate.Name = "DueDate";
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(39, 39, 58);
            panel10.Controls.Add(label6);
            panel10.Controls.Add(label7);
            panel10.Controls.Add(panelMissItemAnexo);
            panel10.Controls.Add(panelDiffAnexo);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(200, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(999, 80);
            panel10.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(42, 42);
            label6.Name = "label6";
            label6.Size = new Size(131, 19);
            label6.TabIndex = 45;
            label6.Text = "Ítem no Encontrado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(42, 19);
            label7.Name = "label7";
            label7.Size = new Size(75, 19);
            label7.TabIndex = 44;
            label7.Text = "Diferencias";
            // 
            // panelMissItemAnexo
            // 
            panelMissItemAnexo.BackColor = Color.White;
            panelMissItemAnexo.Location = new Point(22, 44);
            panelMissItemAnexo.Name = "panelMissItemAnexo";
            panelMissItemAnexo.Size = new Size(14, 15);
            panelMissItemAnexo.TabIndex = 43;
            // 
            // panelDiffAnexo
            // 
            panelDiffAnexo.BackColor = Color.White;
            panelDiffAnexo.Location = new Point(22, 21);
            panelDiffAnexo.Name = "panelDiffAnexo";
            panelDiffAnexo.Size = new Size(14, 15);
            panelDiffAnexo.TabIndex = 42;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(51, 51, 76);
            panel8.Controls.Add(BtnTests);
            panel8.Controls.Add(BtnCleanAnexo);
            panel8.Controls.Add(BtnCompare);
            panel8.Controls.Add(BtnPasteAnexo);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 567);
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
            BtnTests.Location = new Point(0, 245);
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
            BtnCleanAnexo.Location = new Point(0, 190);
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
            label5.Location = new Point(47, 30);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 2;
            label5.Text = "Inventario AB";
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
            tabReceived.Size = new Size(1199, 567);
            tabReceived.TabIndex = 2;
            tabReceived.Text = "Valija";
            // 
            // dataGridViewReceived
            // 
            dataGridViewReceived.AllowUserToAddRows = false;
            dataGridViewReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceived.BackgroundColor = SystemColors.InactiveBorder;
            dataGridViewReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceived.Columns.AddRange(new DataGridViewColumn[] { UnitsReceivedInventory, CodItemReceivedInventory, SerialReceivedInventory, DueDateReceivedInventory });
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
            dataGridViewReceived.Size = new Size(999, 487);
            dataGridViewReceived.TabIndex = 30;
            dataGridViewReceived.UserDeletingRow += dataGridViewReceived_UserDeletingRow;
            // 
            // UnitsReceivedInventory
            // 
            UnitsReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UnitsReceivedInventory.HeaderText = "Unidades";
            UnitsReceivedInventory.Name = "UnitsReceivedInventory";
            // 
            // CodItemReceivedInventory
            // 
            CodItemReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodItemReceivedInventory.HeaderText = "Código";
            CodItemReceivedInventory.Name = "CodItemReceivedInventory";
            // 
            // SerialReceivedInventory
            // 
            SerialReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialReceivedInventory.HeaderText = "Número de Serie";
            SerialReceivedInventory.Name = "SerialReceivedInventory";
            // 
            // DueDateReceivedInventory
            // 
            DueDateReceivedInventory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DueDateReceivedInventory.HeaderText = "Vencimiento";
            DueDateReceivedInventory.Name = "DueDateReceivedInventory";
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(39, 39, 58);
            panel17.Controls.Add(BtnHelp);
            panel17.Controls.Add(label10);
            panel17.Controls.Add(label11);
            panel17.Controls.Add(TxtPickSerialNumReceived);
            panel17.Controls.Add(TxtPickCodeReceived);
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
            BtnHelp.Click += BtnHelp_Click;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(681, 47);
            label10.Name = "label10";
            label10.Size = new Size(111, 19);
            label10.TabIndex = 28;
            label10.Text = "Número de Serie";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(710, 12);
            label11.Name = "label11";
            label11.Size = new Size(53, 19);
            label11.TabIndex = 27;
            label11.Text = "Código";
            // 
            // TxtPickSerialNumReceived
            // 
            TxtPickSerialNumReceived.Anchor = AnchorStyles.Right;
            TxtPickSerialNumReceived.Font = new Font("Segoe UI", 10F);
            TxtPickSerialNumReceived.Location = new Point(805, 45);
            TxtPickSerialNumReceived.Name = "TxtPickSerialNumReceived";
            TxtPickSerialNumReceived.Size = new Size(183, 25);
            TxtPickSerialNumReceived.TabIndex = 26;
            TxtPickSerialNumReceived.KeyDown += TxtPickSerialNumReceived_KeyDown;
            // 
            // TxtPickCodeReceived
            // 
            TxtPickCodeReceived.Anchor = AnchorStyles.Right;
            TxtPickCodeReceived.Font = new Font("Segoe UI", 10F);
            TxtPickCodeReceived.Location = new Point(805, 10);
            TxtPickCodeReceived.Name = "TxtPickCodeReceived";
            TxtPickCodeReceived.Size = new Size(183, 25);
            TxtPickCodeReceived.TabIndex = 25;
            TxtPickCodeReceived.KeyDown += TxtPickCodeReceived_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(BtnCleanReceived);
            panel2.Controls.Add(BtnHasPila);
            panel2.Controls.Add(BtnManualArticle);
            panel2.Controls.Add(panel16);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 567);
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
            BtnCleanReceived.Location = new Point(0, 190);
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
            BtnHasPila.Image = Properties.Resources.Battery;
            BtnHasPila.ImageAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.Location = new Point(0, 135);
            BtnHasPila.Name = "BtnHasPila";
            BtnHasPila.Padding = new Padding(12, 0, 0, 0);
            BtnHasPila.Size = new Size(200, 55);
            BtnHasPila.TabIndex = 2;
            BtnHasPila.Text = "   Tiene Pila";
            BtnHasPila.TextAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnHasPila.UseVisualStyleBackColor = true;
            BtnHasPila.Click += BtnHasPila_Click;
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
            label9.Location = new Point(76, 20);
            label9.Name = "label9";
            label9.Size = new Size(47, 20);
            label9.TabIndex = 2;
            label9.Text = "Valija";
            // 
            // BtnManualArticle
            // 
            BtnManualArticle.Cursor = Cursors.Hand;
            BtnManualArticle.Dock = DockStyle.Top;
            BtnManualArticle.FlatAppearance.BorderSize = 0;
            BtnManualArticle.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnManualArticle.FlatStyle = FlatStyle.Flat;
            BtnManualArticle.ForeColor = Color.Gainsboro;
            BtnManualArticle.Image = Properties.Resources.ManualArticle;
            BtnManualArticle.ImageAlign = ContentAlignment.MiddleLeft;
            BtnManualArticle.Location = new Point(0, 80);
            BtnManualArticle.Name = "BtnManualArticle";
            BtnManualArticle.Padding = new Padding(12, 0, 0, 0);
            BtnManualArticle.Size = new Size(200, 55);
            BtnManualArticle.TabIndex = 8;
            BtnManualArticle.Text = "   Artículo Manual";
            BtnManualArticle.TextAlign = ContentAlignment.MiddleLeft;
            BtnManualArticle.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnManualArticle.UseVisualStyleBackColor = true;
            BtnManualArticle.Click += BtnManualArticle_Click;
            // 
            // FrmInventoryAB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 615);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmInventoryAB";
            Text = "Inventario AB";
            Load += FrmInventoryAB_Load;
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
        private Label label6;
        private Label label7;
        private Panel panelMissItemAnexo;
        private Panel panelDiffAnexo;
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
        private TextBox TxtPickSerialNumReceived;
        private TextBox TxtPickCodeReceived;
        private Panel panel2;
        private Button BtnCleanReceived;
        private Button BtnHasPila;
        private Panel panel16;
        private Label label9;
        private DataGridViewTextBoxColumn UnitsReceivedInventory;
        private DataGridViewTextBoxColumn CodItemReceivedInventory;
        private DataGridViewTextBoxColumn SerialReceivedInventory;
        private DataGridViewTextBoxColumn DueDateReceivedInventory;
        private DataGridViewTextBoxColumn QuantityItem;
        private DataGridViewTextBoxColumn CodItem;
        private DataGridViewTextBoxColumn DescriptionItem;
        private DataGridViewTextBoxColumn SerialNumber;
        private DataGridViewTextBoxColumn DueDate;
        private Button BtnManualArticle;
    }
}