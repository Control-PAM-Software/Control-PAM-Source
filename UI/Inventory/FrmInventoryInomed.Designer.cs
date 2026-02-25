namespace Control
{
    partial class FrmInventoryInomed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryInomed));
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            btnGenerateReport = new Button();
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { QuantityItem, CodItem, DescriptionItem, SerialNumber, DueDate });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(140, 140, 202);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
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
            panel8.Controls.Add(btnGenerateReport);
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
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(51, 51, 76);
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.Dock = DockStyle.Top;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.ForeColor = Color.Gainsboro;
            btnGenerateReport.Image = (Image)resources.GetObject("btnGenerateReport.Image");
            btnGenerateReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnGenerateReport.Location = new Point(0, 190);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Padding = new Padding(12, 0, 0, 0);
            btnGenerateReport.Size = new Size(200, 55);
            btnGenerateReport.TabIndex = 7;
            btnGenerateReport.Text = "   Generar Reporte";
            btnGenerateReport.TextAlign = ContentAlignment.MiddleLeft;
            btnGenerateReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
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
            label5.Size = new Size(137, 20);
            label5.TabIndex = 2;
            label5.Text = "Inventario Inomed";
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
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Cascadia Mono", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewReceived.DefaultCellStyle = dataGridViewCellStyle6;
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
            // FrmInventoryInomed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 615);
            Controls.Add(tabControl);
            Name = "FrmInventoryInomed";
            Text = "Inventario Inomed";
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
        private Button btnGenerateReport;
        private Button BtnTests;
        private Button BtnCleanAnexo;
        private Button BtnCleanReceived;
        private Button BtnManualArticle;
    }
}