namespace Control
{
    partial class FrmRegistrationInomed
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            tabAnexo = new TabPage();
            dataGridView1 = new DataGridView();
            QuantityItem = new DataGridViewTextBoxColumn();
            CodItem = new DataGridViewTextBoxColumn();
            DescriptionItem = new DataGridViewTextBoxColumn();
            SerialNumber = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            panel10 = new Panel();
            LblQty = new Label();
            LblMissItem = new Label();
            LblDiffItem = new Label();
            panelMissItemAnexo = new Panel();
            panelDiffAnexo = new Panel();
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
            CodItemReceivedInventory = new DataGridViewTextBoxColumn();
            SerialReceivedInventory = new DataGridViewTextBoxColumn();
            DueDateReceivedInventory = new DataGridViewTextBoxColumn();
            panel17 = new Panel();
            BtnHelp = new Button();
            label11 = new Label();
            TxtPickCodeReceived = new TextBox();
            panel2 = new Panel();
            BtnCleanReceived = new Button();
            BtnManualArticle = new Button();
            panel16 = new Panel();
            label9 = new Label();
            tabResult = new TabPage();
            dataGridViewResult = new DataGridView();
            ColumnCodeResult = new DataGridViewTextBoxColumn();
            ColumnQtyResult = new DataGridViewTextBoxColumn();
            ColumnSerieResult = new DataGridViewTextBoxColumn();
            ColumnExpireResult = new DataGridViewTextBoxColumn();
            ColumnPriceResult = new DataGridViewTextBoxColumn();
            ColumnBatchResult = new DataGridViewTextBoxColumn();
            columnKitResult = new DataGridViewTextBoxColumn();
            panel15 = new Panel();
            panel13 = new Panel();
            BtnCleanResult = new Button();
            BtnCopyResult = new Button();
            panel14 = new Panel();
            label8 = new Label();
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
            tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.Controls.Add(tabAnexo);
            tabControl.Controls.Add(tabResult);
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
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { QuantityItem, CodItem, DescriptionItem, SerialNumber, DueDate });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
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
            panel10.Controls.Add(LblQty);
            panel10.Controls.Add(LblMissItem);
            panel10.Controls.Add(LblDiffItem);
            panel10.Controls.Add(panelMissItemAnexo);
            panel10.Controls.Add(panelDiffAnexo);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(200, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(999, 80);
            panel10.TabIndex = 1;
            // 
            // LblQty
            // 
            LblQty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LblQty.AutoSize = true;
            LblQty.ForeColor = Color.White;
            LblQty.Location = new Point(803, 5);
            LblQty.Name = "LblQty";
            LblQty.Size = new Size(140, 19);
            LblQty.TabIndex = 47;
            LblQty.Text = "Artículos Restantes: 0";
            // 
            // LblMissItem
            // 
            LblMissItem.AutoSize = true;
            LblMissItem.Font = new Font("Segoe UI", 10F);
            LblMissItem.ForeColor = Color.White;
            LblMissItem.Location = new Point(42, 42);
            LblMissItem.Name = "LblMissItem";
            LblMissItem.Size = new Size(131, 19);
            LblMissItem.TabIndex = 45;
            LblMissItem.Text = "Ítem no Encontrado";
            // 
            // LblDiffItem
            // 
            LblDiffItem.AutoSize = true;
            LblDiffItem.Font = new Font("Segoe UI", 10F);
            LblDiffItem.ForeColor = Color.White;
            LblDiffItem.Location = new Point(42, 19);
            LblDiffItem.Name = "LblDiffItem";
            LblDiffItem.Size = new Size(75, 19);
            LblDiffItem.TabIndex = 44;
            LblDiffItem.Text = "Diferencias";
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
            panel8.Controls.Add(BtnCreateOpenOrange);
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
            BtnTests.Location = new Point(0, 300);
            BtnTests.Name = "BtnTests";
            BtnTests.Padding = new Padding(12, 0, 0, 0);
            BtnTests.Size = new Size(200, 55);
            BtnTests.TabIndex = 10;
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
            BtnCleanAnexo.TabIndex = 9;
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
            BtnCreateOpenOrange.TabIndex = 11;
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
            label5.Location = new Point(32, 30);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 2;
            label5.Text = "Ingreso Inomed";
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
            tabReceived.Text = "Físico";
            // 
            // dataGridViewReceived
            // 
            dataGridViewReceived.AllowUserToAddRows = false;
            dataGridViewReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceived.BackgroundColor = SystemColors.InactiveBorder;
            dataGridViewReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReceived.Columns.AddRange(new DataGridViewColumn[] { UnitsReceivedInventory, CodItemReceivedInventory, SerialReceivedInventory, DueDateReceivedInventory });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dataGridViewReceived.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewReceived.Dock = DockStyle.Fill;
            dataGridViewReceived.Location = new Point(200, 80);
            dataGridViewReceived.Name = "dataGridViewReceived";
            dataGridViewReceived.Size = new Size(999, 487);
            dataGridViewReceived.TabIndex = 30;
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
            panel17.Controls.Add(label11);
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
            // TxtPickCodeReceived
            // 
            TxtPickCodeReceived.Anchor = AnchorStyles.Right;
            TxtPickCodeReceived.Font = new Font("Segoe UI", 10F);
            TxtPickCodeReceived.Location = new Point(808, 9);
            TxtPickCodeReceived.Name = "TxtPickCodeReceived";
            TxtPickCodeReceived.Size = new Size(183, 25);
            TxtPickCodeReceived.TabIndex = 25;
            TxtPickCodeReceived.KeyDown += TxtPickCodeReceived_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(BtnCleanReceived);
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
            BtnCleanReceived.Location = new Point(0, 135);
            BtnCleanReceived.Name = "BtnCleanReceived";
            BtnCleanReceived.Padding = new Padding(12, 0, 0, 0);
            BtnCleanReceived.Size = new Size(200, 55);
            BtnCleanReceived.TabIndex = 7;
            BtnCleanReceived.Text = "   Limpiar";
            BtnCleanReceived.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCleanReceived.UseVisualStyleBackColor = true;
            BtnCleanReceived.Click += BtnCleanReceived_Click;
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
            BtnManualArticle.TabIndex = 6;
            BtnManualArticle.Text = "   Artículo Manual";
            BtnManualArticle.TextAlign = ContentAlignment.MiddleLeft;
            BtnManualArticle.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnManualArticle.UseVisualStyleBackColor = true;
            BtnManualArticle.Click += BtnManualArticle_Click;
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
            label9.Location = new Point(76, 28);
            label9.Name = "label9";
            label9.Size = new Size(58, 20);
            label9.TabIndex = 2;
            label9.Text = "Físicos";
            // 
            // tabResult
            // 
            tabResult.Controls.Add(dataGridViewResult);
            tabResult.Controls.Add(panel15);
            tabResult.Controls.Add(panel13);
            tabResult.Location = new Point(4, 4);
            tabResult.Name = "tabResult";
            tabResult.Size = new Size(1199, 567);
            tabResult.TabIndex = 3;
            tabResult.Text = "Resultado";
            tabResult.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.AllowUserToAddRows = false;
            dataGridViewResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResult.BackgroundColor = SystemColors.InactiveBorder;
            dataGridViewResult.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { ColumnCodeResult, ColumnQtyResult, ColumnSerieResult, ColumnExpireResult, ColumnPriceResult, ColumnBatchResult, columnKitResult });
            dataGridViewResult.Dock = DockStyle.Fill;
            dataGridViewResult.Location = new Point(200, 80);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.Size = new Size(999, 487);
            dataGridViewResult.TabIndex = 34;
            // 
            // ColumnCodeResult
            // 
            ColumnCodeResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCodeResult.HeaderText = "ArtCode";
            ColumnCodeResult.Name = "ColumnCodeResult";
            ColumnCodeResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnQtyResult
            // 
            ColumnQtyResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnQtyResult.HeaderText = "Qty";
            ColumnQtyResult.Name = "ColumnQtyResult";
            ColumnQtyResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSerieResult
            // 
            ColumnSerieResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnSerieResult.HeaderText = "SerialNr";
            ColumnSerieResult.Name = "ColumnSerieResult";
            ColumnSerieResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnExpireResult
            // 
            ColumnExpireResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnExpireResult.HeaderText = "ExpireDate";
            ColumnExpireResult.Name = "ColumnExpireResult";
            ColumnExpireResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPriceResult
            // 
            ColumnPriceResult.HeaderText = "Price";
            ColumnPriceResult.Name = "ColumnPriceResult";
            ColumnPriceResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnBatchResult
            // 
            ColumnBatchResult.HeaderText = "BatchStatus";
            ColumnBatchResult.Name = "ColumnBatchResult";
            ColumnBatchResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // columnKitResult
            // 
            columnKitResult.HeaderText = "Kit";
            columnKitResult.Name = "columnKitResult";
            columnKitResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(39, 39, 58);
            panel15.Dock = DockStyle.Top;
            panel15.Location = new Point(200, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(999, 80);
            panel15.TabIndex = 33;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(51, 51, 76);
            panel13.Controls.Add(BtnCleanResult);
            panel13.Controls.Add(BtnCopyResult);
            panel13.Controls.Add(panel14);
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(200, 567);
            panel13.TabIndex = 32;
            // 
            // BtnCleanResult
            // 
            BtnCleanResult.Cursor = Cursors.Hand;
            BtnCleanResult.Dock = DockStyle.Top;
            BtnCleanResult.FlatAppearance.BorderSize = 0;
            BtnCleanResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanResult.FlatStyle = FlatStyle.Flat;
            BtnCleanResult.ForeColor = Color.Gainsboro;
            BtnCleanResult.Image = Properties.Resources.Clean;
            BtnCleanResult.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCleanResult.Location = new Point(0, 135);
            BtnCleanResult.Name = "BtnCleanResult";
            BtnCleanResult.Padding = new Padding(12, 0, 0, 0);
            BtnCleanResult.Size = new Size(200, 55);
            BtnCleanResult.TabIndex = 5;
            BtnCleanResult.Text = "   Limpiar";
            BtnCleanResult.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCleanResult.UseVisualStyleBackColor = true;
            BtnCleanResult.Click += BtnCleanResult_Click;
            // 
            // BtnCopyResult
            // 
            BtnCopyResult.Cursor = Cursors.Hand;
            BtnCopyResult.Dock = DockStyle.Top;
            BtnCopyResult.FlatAppearance.BorderSize = 0;
            BtnCopyResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCopyResult.FlatStyle = FlatStyle.Flat;
            BtnCopyResult.ForeColor = Color.Gainsboro;
            BtnCopyResult.Image = Properties.Resources.CopyPaste2;
            BtnCopyResult.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCopyResult.Location = new Point(0, 80);
            BtnCopyResult.Name = "BtnCopyResult";
            BtnCopyResult.Padding = new Padding(12, 0, 0, 0);
            BtnCopyResult.Size = new Size(200, 55);
            BtnCopyResult.TabIndex = 2;
            BtnCopyResult.Text = "   Copiar Tabla";
            BtnCopyResult.TextAlign = ContentAlignment.MiddleLeft;
            BtnCopyResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCopyResult.UseVisualStyleBackColor = true;
            BtnCopyResult.Click += BtnCopyResult_Click;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(39, 39, 58);
            panel14.Controls.Add(label8);
            panel14.Dock = DockStyle.Top;
            panel14.Location = new Point(0, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(200, 80);
            panel14.TabIndex = 1;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Gainsboro;
            label8.Location = new Point(59, 20);
            label8.Name = "label8";
            label8.Size = new Size(82, 20);
            label8.TabIndex = 2;
            label8.Text = "Resultado";
            // 
            // FrmRegistrationInomed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 615);
            Controls.Add(tabControl);
            Name = "FrmRegistrationInomed";
            Text = "Ingreso Inomed";
            Load += FrmInventoryInomed_Load;
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
            tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabAnexo;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn QuantityItem;
        private DataGridViewTextBoxColumn CodItem;
        private DataGridViewTextBoxColumn DescriptionItem;
        private DataGridViewTextBoxColumn SerialNumber;
        private DataGridViewTextBoxColumn DueDate;
        private Panel panel10;
        private Label LblMissItem;
        private Label LblDiffItem;
        private Panel panelMissItemAnexo;
        private Panel panelDiffAnexo;
        private Panel panel8;
        private Button BtnCompare;
        private Button BtnPasteAnexo;
        private Panel panel9;
        private Label label5;
        private TabPage tabReceived;
        private DataGridView dataGridViewReceived;
        private DataGridViewTextBoxColumn UnitsReceivedInventory;
        private DataGridViewTextBoxColumn CodItemReceivedInventory;
        private DataGridViewTextBoxColumn SerialReceivedInventory;
        private DataGridViewTextBoxColumn DueDateReceivedInventory;
        private Panel panel17;
        private Button BtnHelp;
        private Label label11;
        private TextBox TxtPickCodeReceived;
        private Panel panel2;
        private Panel panel16;
        private Label label9;
        private Label LblQty;
        private Button BtnTests;
        private Button BtnCleanAnexo;
        private Button BtnCleanReceived;
        private Button BtnManualArticle;
        private Button BtnCreateOpenOrange;
        private TabPage tabResult;
        private DataGridView dataGridViewResult;
        private DataGridViewTextBoxColumn ColumnCodeResult;
        private DataGridViewTextBoxColumn ColumnQtyResult;
        private DataGridViewTextBoxColumn ColumnSerieResult;
        private DataGridViewTextBoxColumn ColumnExpireResult;
        private DataGridViewTextBoxColumn ColumnPriceResult;
        private DataGridViewTextBoxColumn ColumnBatchResult;
        private DataGridViewTextBoxColumn columnKitResult;
        private Panel panel15;
        private Panel panel13;
        private Button BtnCleanResult;
        private Button BtnCopyResult;
        private Panel panel14;
        private Label label8;
    }
}