using System.Drawing.Printing;

namespace Control
{
    partial class FrmRegistrationBase
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrationBase));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            toolTip1 = new ToolTip(components);
            BtnHasPila = new Button();
            BtnCleanReceived = new Button();
            BtnCopyResult = new Button();
            BtnCleanResult = new Button();
            BtnPasteAnexo = new Button();
            BtnCompare = new Button();
            BtnCreateOpenOrange = new Button();
            BtnCleanAnexo = new Button();
            btnActionsReceived = new Button();
            btnPrintReceived = new Button();
            btnExcelReceived = new Button();
            btnQrReceived = new Button();
            BtnManualArticle = new Button();
            btnExcelResult = new Button();
            btnPrintResult = new Button();
            btnActionsResult = new Button();
            panel1 = new Panel();
            tabControl = new TabControl();
            tabAnexo = new TabPage();
            dataGridView1 = new DataGridView();
            IsAquaKit = new DataGridViewCheckBoxColumn();
            QuantityItem = new DataGridViewTextBoxColumn();
            CodItem = new DataGridViewTextBoxColumn();
            DescriptionItem = new DataGridViewTextBoxColumn();
            SerialNumber = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            pnlDropOverlay = new Panel();
            lblDropInfo = new Label();
            panel10 = new Panel();
            label6 = new Label();
            label7 = new Label();
            panelMissItemAnexo = new Panel();
            panelDiffAnexo = new Panel();
            lblSerieInputAnexo = new Label();
            TxtSerialNumProcessor = new TextBox();
            panel8 = new Panel();
            BtnTests = new Button();
            panel9 = new Panel();
            lblTitleAnexo = new Label();
            tabResult = new TabPage();
            dataGridViewResult = new DataGridView();
            ColumnCodeResult = new DataGridViewTextBoxColumn();
            ColumnQtyResult = new DataGridViewTextBoxColumn();
            ColumnSerieReSult = new DataGridViewTextBoxColumn();
            ColumnExpireResult = new DataGridViewTextBoxColumn();
            ColumnPriceResult = new DataGridViewTextBoxColumn();
            ColumnBatchResult = new DataGridViewTextBoxColumn();
            columnKitResult = new DataGridViewTextBoxColumn();
            panel15 = new Panel();
            panel13 = new Panel();
            panelActionsResult = new Panel();
            panel14 = new Panel();
            label8 = new Label();
            tabReceived = new TabPage();
            dataGridViewReceived = new DataGridView();
            QtyReceived = new DataGridViewTextBoxColumn();
            ArtCodeReceived = new DataGridViewTextBoxColumn();
            SerialNrReceived = new DataGridViewTextBoxColumn();
            DueDateReceived = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            panelActionsReceived = new Panel();
            panel17 = new Panel();
            lblTitleReceived = new Label();
            lblSerieInputReceived = new Label();
            lblCodeInputReceived = new Label();
            TxtPickSerialNumReceived = new TextBox();
            TxtPickCodeReceived = new TextBox();
            timerMenu = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            dataGridView1.SuspendLayout();
            pnlDropOverlay.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            panel13.SuspendLayout();
            panelActionsResult.SuspendLayout();
            panel14.SuspendLayout();
            tabReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceived).BeginInit();
            panel2.SuspendLayout();
            panelActionsReceived.SuspendLayout();
            panel17.SuspendLayout();
            SuspendLayout();
            // 
            // BtnHasPila
            // 
            BtnHasPila.Cursor = Cursors.Hand;
            BtnHasPila.Dock = DockStyle.Top;
            BtnHasPila.FlatAppearance.BorderSize = 0;
            BtnHasPila.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnHasPila.FlatStyle = FlatStyle.Flat;
            BtnHasPila.Font = new Font("Segoe UI Semibold", 10F);
            BtnHasPila.ForeColor = Color.Gainsboro;
            BtnHasPila.Image = Properties.Resources.Battery;
            BtnHasPila.ImageAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.Location = new Point(0, 55);
            BtnHasPila.Name = "BtnHasPila";
            BtnHasPila.Padding = new Padding(12, 0, 0, 0);
            BtnHasPila.Size = new Size(200, 55);
            BtnHasPila.TabIndex = 2;
            BtnHasPila.Text = "   Tiene Pila";
            BtnHasPila.TextAlign = ContentAlignment.MiddleLeft;
            BtnHasPila.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnHasPila, "Agregar una fila en la tabla con una pila");
            BtnHasPila.UseVisualStyleBackColor = true;
            BtnHasPila.Click += BtnHasPila_Click;
            // 
            // BtnCleanReceived
            // 
            BtnCleanReceived.Cursor = Cursors.Hand;
            BtnCleanReceived.Dock = DockStyle.Top;
            BtnCleanReceived.FlatAppearance.BorderSize = 0;
            BtnCleanReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanReceived.FlatStyle = FlatStyle.Flat;
            BtnCleanReceived.Font = new Font("Segoe UI Semibold", 10F);
            BtnCleanReceived.ForeColor = Color.Gainsboro;
            BtnCleanReceived.Image = Properties.Resources.Clean;
            BtnCleanReceived.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCleanReceived.Location = new Point(0, 165);
            BtnCleanReceived.Name = "BtnCleanReceived";
            BtnCleanReceived.Padding = new Padding(12, 0, 0, 0);
            BtnCleanReceived.Size = new Size(200, 55);
            BtnCleanReceived.TabIndex = 5;
            BtnCleanReceived.Text = "   Limpiar";
            BtnCleanReceived.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnCleanReceived, "Limpiar ventana");
            BtnCleanReceived.UseVisualStyleBackColor = true;
            BtnCleanReceived.Click += BtnCleanReceived_Click;
            // 
            // BtnCopyResult
            // 
            BtnCopyResult.Cursor = Cursors.Hand;
            BtnCopyResult.Dock = DockStyle.Top;
            BtnCopyResult.FlatAppearance.BorderSize = 0;
            BtnCopyResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCopyResult.FlatStyle = FlatStyle.Flat;
            BtnCopyResult.Font = new Font("Segoe UI Semibold", 10F);
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
            toolTip1.SetToolTip(BtnCopyResult, "Copiar los datos de la tabla en el portapapeles");
            BtnCopyResult.UseVisualStyleBackColor = true;
            BtnCopyResult.Click += BtnCopyResult_Click;
            // 
            // BtnCleanResult
            // 
            BtnCleanResult.Cursor = Cursors.Hand;
            BtnCleanResult.Dock = DockStyle.Top;
            BtnCleanResult.FlatAppearance.BorderSize = 0;
            BtnCleanResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanResult.FlatStyle = FlatStyle.Flat;
            BtnCleanResult.Font = new Font("Segoe UI Semibold", 10F);
            BtnCleanResult.ForeColor = Color.Gainsboro;
            BtnCleanResult.Image = Properties.Resources.Clean;
            BtnCleanResult.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCleanResult.Location = new Point(0, 190);
            BtnCleanResult.Name = "BtnCleanResult";
            BtnCleanResult.Padding = new Padding(12, 0, 0, 0);
            BtnCleanResult.Size = new Size(200, 55);
            BtnCleanResult.TabIndex = 5;
            BtnCleanResult.Text = "   Limpiar";
            BtnCleanResult.TextAlign = ContentAlignment.MiddleLeft;
            BtnCleanResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnCleanResult, "Limpiar ventana");
            BtnCleanResult.UseVisualStyleBackColor = true;
            BtnCleanResult.Click += BtnCleanResult_Click;
            // 
            // BtnPasteAnexo
            // 
            BtnPasteAnexo.Cursor = Cursors.Hand;
            BtnPasteAnexo.Dock = DockStyle.Top;
            BtnPasteAnexo.FlatAppearance.BorderSize = 0;
            BtnPasteAnexo.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnPasteAnexo.FlatStyle = FlatStyle.Flat;
            BtnPasteAnexo.Font = new Font("Segoe UI Semibold", 10F);
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
            toolTip1.SetToolTip(BtnPasteAnexo, "Pegar el contenido del Anexo en la tabla.");
            BtnPasteAnexo.UseVisualStyleBackColor = true;
            BtnPasteAnexo.Click += BtnPasteAnexo_Click;
            // 
            // BtnCompare
            // 
            BtnCompare.Cursor = Cursors.Hand;
            BtnCompare.Dock = DockStyle.Top;
            BtnCompare.FlatAppearance.BorderSize = 0;
            BtnCompare.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCompare.FlatStyle = FlatStyle.Flat;
            BtnCompare.Font = new Font("Segoe UI Semibold", 10F);
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
            toolTip1.SetToolTip(BtnCompare, "Comparar los ítems del Anexo con los ítems de la Valija.");
            BtnCompare.UseVisualStyleBackColor = true;
            BtnCompare.Click += BtnCompare_Click;
            // 
            // BtnCreateOpenOrange
            // 
            BtnCreateOpenOrange.Cursor = Cursors.Hand;
            BtnCreateOpenOrange.Dock = DockStyle.Top;
            BtnCreateOpenOrange.FlatAppearance.BorderSize = 0;
            BtnCreateOpenOrange.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCreateOpenOrange.FlatStyle = FlatStyle.Flat;
            BtnCreateOpenOrange.Font = new Font("Segoe UI Semibold", 10F);
            BtnCreateOpenOrange.ForeColor = Color.Gainsboro;
            BtnCreateOpenOrange.Image = Properties.Resources.OpenOrange;
            BtnCreateOpenOrange.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCreateOpenOrange.Location = new Point(0, 190);
            BtnCreateOpenOrange.Name = "BtnCreateOpenOrange";
            BtnCreateOpenOrange.Padding = new Padding(12, 0, 0, 0);
            BtnCreateOpenOrange.Size = new Size(200, 55);
            BtnCreateOpenOrange.TabIndex = 4;
            BtnCreateOpenOrange.Text = "   Open Orange";
            BtnCreateOpenOrange.TextAlign = ContentAlignment.MiddleLeft;
            BtnCreateOpenOrange.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnCreateOpenOrange, "Armar la tabla para ingreso a OpenOrange (Ver tab \"Resultado\")");
            BtnCreateOpenOrange.UseVisualStyleBackColor = true;
            BtnCreateOpenOrange.Click += BtnCreateOpenOrange_Click;
            // 
            // BtnCleanAnexo
            // 
            BtnCleanAnexo.BackColor = Color.FromArgb(51, 51, 76);
            BtnCleanAnexo.Cursor = Cursors.Hand;
            BtnCleanAnexo.Dock = DockStyle.Top;
            BtnCleanAnexo.FlatAppearance.BorderSize = 0;
            BtnCleanAnexo.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCleanAnexo.FlatStyle = FlatStyle.Flat;
            BtnCleanAnexo.Font = new Font("Segoe UI Semibold", 10F);
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
            toolTip1.SetToolTip(BtnCleanAnexo, "Limpiar ventana");
            BtnCleanAnexo.UseVisualStyleBackColor = false;
            BtnCleanAnexo.Click += BtnCleanAnexo_Click;
            // 
            // btnActionsReceived
            // 
            btnActionsReceived.Cursor = Cursors.Hand;
            btnActionsReceived.Dock = DockStyle.Top;
            btnActionsReceived.FlatAppearance.BorderSize = 0;
            btnActionsReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnActionsReceived.FlatStyle = FlatStyle.Flat;
            btnActionsReceived.Font = new Font("Segoe UI Semibold", 10F);
            btnActionsReceived.ForeColor = Color.Gainsboro;
            btnActionsReceived.Image = (Image)resources.GetObject("btnActionsReceived.Image");
            btnActionsReceived.ImageAlign = ContentAlignment.MiddleLeft;
            btnActionsReceived.Location = new Point(0, 110);
            btnActionsReceived.Name = "btnActionsReceived";
            btnActionsReceived.Padding = new Padding(12, 0, 0, 0);
            btnActionsReceived.Size = new Size(200, 55);
            btnActionsReceived.TabIndex = 8;
            btnActionsReceived.Text = "   Acciones  ▼";
            btnActionsReceived.TextAlign = ContentAlignment.MiddleLeft;
            btnActionsReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnActionsReceived, "Ver más opciones");
            btnActionsReceived.UseVisualStyleBackColor = true;
            btnActionsReceived.Click += btnActionsReceived_Click;
            // 
            // btnPrintReceived
            // 
            btnPrintReceived.Cursor = Cursors.Hand;
            btnPrintReceived.Dock = DockStyle.Top;
            btnPrintReceived.FlatAppearance.BorderSize = 0;
            btnPrintReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnPrintReceived.FlatStyle = FlatStyle.Flat;
            btnPrintReceived.Font = new Font("Segoe UI Semibold", 9F);
            btnPrintReceived.ForeColor = Color.Gainsboro;
            btnPrintReceived.Image = (Image)resources.GetObject("btnPrintReceived.Image");
            btnPrintReceived.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintReceived.Location = new Point(40, 0);
            btnPrintReceived.Name = "btnPrintReceived";
            btnPrintReceived.Padding = new Padding(12, 0, 0, 0);
            btnPrintReceived.Size = new Size(160, 55);
            btnPrintReceived.TabIndex = 9;
            btnPrintReceived.Text = "   Imprimir";
            btnPrintReceived.TextAlign = ContentAlignment.MiddleLeft;
            btnPrintReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnPrintReceived, "Imprimir tabla");
            btnPrintReceived.UseVisualStyleBackColor = true;
            btnPrintReceived.Click += btnPrintReceived_Click;
            // 
            // btnExcelReceived
            // 
            btnExcelReceived.Cursor = Cursors.Hand;
            btnExcelReceived.Dock = DockStyle.Top;
            btnExcelReceived.FlatAppearance.BorderSize = 0;
            btnExcelReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnExcelReceived.FlatStyle = FlatStyle.Flat;
            btnExcelReceived.Font = new Font("Segoe UI Semibold", 9F);
            btnExcelReceived.ForeColor = Color.Gainsboro;
            btnExcelReceived.Image = (Image)resources.GetObject("btnExcelReceived.Image");
            btnExcelReceived.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcelReceived.Location = new Point(40, 55);
            btnExcelReceived.Name = "btnExcelReceived";
            btnExcelReceived.Padding = new Padding(12, 0, 0, 0);
            btnExcelReceived.Size = new Size(160, 55);
            btnExcelReceived.TabIndex = 10;
            btnExcelReceived.Text = "   Excel";
            btnExcelReceived.TextAlign = ContentAlignment.MiddleLeft;
            btnExcelReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnExcelReceived, "Exportar tabla a Excel");
            btnExcelReceived.UseVisualStyleBackColor = true;
            btnExcelReceived.Click += btnExcelReceived_Click;
            // 
            // btnQrReceived
            // 
            btnQrReceived.Cursor = Cursors.Hand;
            btnQrReceived.Dock = DockStyle.Top;
            btnQrReceived.FlatAppearance.BorderSize = 0;
            btnQrReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnQrReceived.FlatStyle = FlatStyle.Flat;
            btnQrReceived.Font = new Font("Segoe UI Semibold", 9F);
            btnQrReceived.ForeColor = Color.Gainsboro;
            btnQrReceived.Image = (Image)resources.GetObject("btnQrReceived.Image");
            btnQrReceived.ImageAlign = ContentAlignment.MiddleLeft;
            btnQrReceived.Location = new Point(40, 110);
            btnQrReceived.Name = "btnQrReceived";
            btnQrReceived.Padding = new Padding(12, 0, 0, 0);
            btnQrReceived.Size = new Size(160, 55);
            btnQrReceived.TabIndex = 11;
            btnQrReceived.Text = "   Generar Qr";
            btnQrReceived.TextAlign = ContentAlignment.MiddleLeft;
            btnQrReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnQrReceived, "Generar código Qr de la tabla");
            btnQrReceived.UseVisualStyleBackColor = true;
            btnQrReceived.Click += btnQrReceived_Click;
            // 
            // BtnManualArticle
            // 
            BtnManualArticle.Cursor = Cursors.Hand;
            BtnManualArticle.Dock = DockStyle.Top;
            BtnManualArticle.FlatAppearance.BorderSize = 0;
            BtnManualArticle.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnManualArticle.FlatStyle = FlatStyle.Flat;
            BtnManualArticle.Font = new Font("Segoe UI Semibold", 10F);
            BtnManualArticle.ForeColor = Color.Gainsboro;
            BtnManualArticle.Image = Properties.Resources.ManualArticle;
            BtnManualArticle.ImageAlign = ContentAlignment.MiddleLeft;
            BtnManualArticle.Location = new Point(0, 0);
            BtnManualArticle.Name = "BtnManualArticle";
            BtnManualArticle.Padding = new Padding(12, 0, 0, 0);
            BtnManualArticle.Size = new Size(200, 55);
            BtnManualArticle.TabIndex = 7;
            BtnManualArticle.Text = "   Artículo Manual";
            BtnManualArticle.TextAlign = ContentAlignment.MiddleLeft;
            BtnManualArticle.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnManualArticle, "Agregar nuevo artículo manual");
            BtnManualArticle.UseVisualStyleBackColor = true;
            BtnManualArticle.Click += BtnManualArticle_Click;
            // 
            // btnExcelResult
            // 
            btnExcelResult.Cursor = Cursors.Hand;
            btnExcelResult.Dock = DockStyle.Top;
            btnExcelResult.FlatAppearance.BorderSize = 0;
            btnExcelResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnExcelResult.FlatStyle = FlatStyle.Flat;
            btnExcelResult.Font = new Font("Segoe UI Semibold", 9F);
            btnExcelResult.ForeColor = Color.Gainsboro;
            btnExcelResult.Image = (Image)resources.GetObject("btnExcelResult.Image");
            btnExcelResult.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcelResult.Location = new Point(40, 55);
            btnExcelResult.Name = "btnExcelResult";
            btnExcelResult.Padding = new Padding(12, 0, 0, 0);
            btnExcelResult.Size = new Size(160, 55);
            btnExcelResult.TabIndex = 10;
            btnExcelResult.Text = "   Excel";
            btnExcelResult.TextAlign = ContentAlignment.MiddleLeft;
            btnExcelResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnExcelResult, "Exportar tabla a Excel");
            btnExcelResult.UseVisualStyleBackColor = true;
            btnExcelResult.Click += btnExcelResult_Click;
            // 
            // btnPrintResult
            // 
            btnPrintResult.Cursor = Cursors.Hand;
            btnPrintResult.Dock = DockStyle.Top;
            btnPrintResult.FlatAppearance.BorderSize = 0;
            btnPrintResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnPrintResult.FlatStyle = FlatStyle.Flat;
            btnPrintResult.Font = new Font("Segoe UI Semibold", 9F);
            btnPrintResult.ForeColor = Color.Gainsboro;
            btnPrintResult.Image = (Image)resources.GetObject("btnPrintResult.Image");
            btnPrintResult.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintResult.Location = new Point(40, 0);
            btnPrintResult.Name = "btnPrintResult";
            btnPrintResult.Padding = new Padding(12, 0, 0, 0);
            btnPrintResult.Size = new Size(160, 55);
            btnPrintResult.TabIndex = 9;
            btnPrintResult.Text = "   Imprimir";
            btnPrintResult.TextAlign = ContentAlignment.MiddleLeft;
            btnPrintResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnPrintResult, "Imprimir tabla");
            btnPrintResult.UseVisualStyleBackColor = true;
            btnPrintResult.Click += btnPrintResult_Click;
            // 
            // btnActionsResult
            // 
            btnActionsResult.Cursor = Cursors.Hand;
            btnActionsResult.Dock = DockStyle.Top;
            btnActionsResult.FlatAppearance.BorderSize = 0;
            btnActionsResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnActionsResult.FlatStyle = FlatStyle.Flat;
            btnActionsResult.Font = new Font("Segoe UI Semibold", 10F);
            btnActionsResult.ForeColor = Color.Gainsboro;
            btnActionsResult.Image = (Image)resources.GetObject("btnActionsResult.Image");
            btnActionsResult.ImageAlign = ContentAlignment.MiddleLeft;
            btnActionsResult.Location = new Point(0, 135);
            btnActionsResult.Name = "btnActionsResult";
            btnActionsResult.Padding = new Padding(12, 0, 0, 0);
            btnActionsResult.Size = new Size(200, 55);
            btnActionsResult.TabIndex = 11;
            btnActionsResult.Text = "   Acciones  ▼";
            btnActionsResult.TextAlign = ContentAlignment.MiddleLeft;
            btnActionsResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(btnActionsResult, "Ver más opciones");
            btnActionsResult.UseVisualStyleBackColor = true;
            btnActionsResult.Click += btnActionsResult_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(tabControl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1207, 588);
            panel1.TabIndex = 8;
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.Controls.Add(tabAnexo);
            tabControl.Controls.Add(tabResult);
            tabControl.Controls.Add(tabReceived);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI Semibold", 10F);
            tabControl.ItemSize = new Size(150, 45);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(20, 5);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1207, 588);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 6;
            // 
            // tabAnexo
            // 
            tabAnexo.BackColor = Color.FromArgb(245, 247, 251);
            tabAnexo.Controls.Add(dataGridView1);
            tabAnexo.Controls.Add(panel10);
            tabAnexo.Controls.Add(panel8);
            tabAnexo.Font = new Font("Segoe UI", 10F);
            tabAnexo.Location = new Point(4, 4);
            tabAnexo.Margin = new Padding(0);
            tabAnexo.Name = "tabAnexo";
            tabAnexo.Size = new Size(1199, 535);
            tabAnexo.TabIndex = 0;
            tabAnexo.Text = "📋  Anexo";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IsAquaKit, QuantityItem, CodItem, DescriptionItem, SerialNumber, DueDate });
            dataGridView1.Controls.Add(pnlDropOverlay);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(239, 241, 243);
            dataGridView1.Location = new Point(200, 80);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(999, 455);
            dataGridView1.TabIndex = 27;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            dataGridView1.DragLeave += dataGridView1_DragLeave;
            // 
            // IsAquaKit
            // 
            IsAquaKit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            IsAquaKit.HeaderText = "Es AquaKit";
            IsAquaKit.Name = "IsAquaKit";
            IsAquaKit.Resizable = DataGridViewTriState.True;
            IsAquaKit.SortMode = DataGridViewColumnSortMode.Automatic;
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
            // pnlDropOverlay
            // 
            pnlDropOverlay.BackColor = Color.FromArgb(180, 45, 45, 48);
            pnlDropOverlay.Controls.Add(lblDropInfo);
            pnlDropOverlay.Dock = DockStyle.Fill;
            pnlDropOverlay.Location = new Point(0, 0);
            pnlDropOverlay.Name = "pnlDropOverlay";
            pnlDropOverlay.Size = new Size(999, 455);
            pnlDropOverlay.TabIndex = 2;
            pnlDropOverlay.Visible = false;
            // 
            // lblDropInfo
            // 
            lblDropInfo.Dock = DockStyle.Fill;
            lblDropInfo.Font = new Font("Segoe UI Semibold", 16F);
            lblDropInfo.ForeColor = Color.White;
            lblDropInfo.Location = new Point(0, 0);
            lblDropInfo.Name = "lblDropInfo";
            lblDropInfo.Size = new Size(999, 455);
            lblDropInfo.TabIndex = 0;
            lblDropInfo.Text = "📥\n\nSuelte el archivo aquí para procesar";
            lblDropInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(39, 39, 58);
            panel10.Controls.Add(label6);
            panel10.Controls.Add(label7);
            panel10.Controls.Add(panelMissItemAnexo);
            panel10.Controls.Add(panelDiffAnexo);
            panel10.Controls.Add(lblSerieInputAnexo);
            panel10.Controls.Add(TxtSerialNumProcessor);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(200, 0);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(20);
            panel10.Size = new Size(999, 80);
            panel10.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.5F);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(48, 44);
            label6.Name = "label6";
            label6.Size = new Size(130, 17);
            label6.TabIndex = 45;
            label6.Text = "Ítem no Encontrado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.5F);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(48, 19);
            label7.Name = "label7";
            label7.Size = new Size(73, 17);
            label7.TabIndex = 44;
            label7.Text = "Diferencias";
            // 
            // panelMissItemAnexo
            // 
            panelMissItemAnexo.BackColor = Color.FromArgb(255, 255, 128);
            panelMissItemAnexo.Location = new Point(28, 47);
            panelMissItemAnexo.Name = "panelMissItemAnexo";
            panelMissItemAnexo.Size = new Size(12, 12);
            panelMissItemAnexo.TabIndex = 43;
            // 
            // panelDiffAnexo
            // 
            panelDiffAnexo.BackColor = Color.FromArgb(255, 128, 128);
            panelDiffAnexo.Location = new Point(28, 22);
            panelDiffAnexo.Name = "panelDiffAnexo";
            panelDiffAnexo.Size = new Size(12, 12);
            panelDiffAnexo.TabIndex = 42;
            // 
            // lblSerieInputAnexo
            // 
            lblSerieInputAnexo.Anchor = AnchorStyles.Right;
            lblSerieInputAnexo.AutoSize = true;
            lblSerieInputAnexo.Font = new Font("Segoe UI Semibold", 10F);
            lblSerieInputAnexo.ForeColor = Color.White;
            lblSerieInputAnexo.Location = new Point(660, 30);
            lblSerieInputAnexo.Name = "lblSerieInputAnexo";
            lblSerieInputAnexo.Size = new Size(113, 19);
            lblSerieInputAnexo.TabIndex = 41;
            lblSerieInputAnexo.Text = "Serie Procesador";
            // 
            // TxtSerialNumProcessor
            // 
            TxtSerialNumProcessor.Anchor = AnchorStyles.Right;
            TxtSerialNumProcessor.BackColor = Color.FromArgb(50, 50, 75);
            TxtSerialNumProcessor.BorderStyle = BorderStyle.FixedSingle;
            TxtSerialNumProcessor.Font = new Font("Segoe UI", 11F);
            TxtSerialNumProcessor.ForeColor = Color.White;
            TxtSerialNumProcessor.Location = new Point(785, 27);
            TxtSerialNumProcessor.Name = "TxtSerialNumProcessor";
            TxtSerialNumProcessor.Size = new Size(190, 27);
            TxtSerialNumProcessor.TabIndex = 39;
            TxtSerialNumProcessor.TextAlign = HorizontalAlignment.Center;
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
            panel8.Size = new Size(200, 535);
            panel8.TabIndex = 0;
            // 
            // BtnTests
            // 
            BtnTests.Cursor = Cursors.Hand;
            BtnTests.Dock = DockStyle.Top;
            BtnTests.FlatAppearance.BorderSize = 0;
            BtnTests.FlatStyle = FlatStyle.Flat;
            BtnTests.Font = new Font("Segoe UI Semibold", 10F);
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
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(39, 39, 58);
            panel9.Controls.Add(lblTitleAnexo);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 80);
            panel9.TabIndex = 1;
            // 
            // lblTitleAnexo
            // 
            lblTitleAnexo.Anchor = AnchorStyles.None;
            lblTitleAnexo.AutoSize = true;
            lblTitleAnexo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleAnexo.ForeColor = Color.Gainsboro;
            lblTitleAnexo.Location = new Point(41, 30);
            lblTitleAnexo.Name = "lblTitleAnexo";
            lblTitleAnexo.Size = new Size(114, 21);
            lblTitleAnexo.TabIndex = 2;
            lblTitleAnexo.Text = "Ingreso Valijas";
            // 
            // tabResult
            // 
            tabResult.BackColor = Color.FromArgb(245, 247, 251);
            tabResult.Controls.Add(dataGridViewResult);
            tabResult.Controls.Add(panel15);
            tabResult.Controls.Add(panel13);
            tabResult.Font = new Font("Segoe UI", 10F);
            tabResult.Location = new Point(4, 4);
            tabResult.Margin = new Padding(0);
            tabResult.Name = "tabResult";
            tabResult.Size = new Size(1199, 535);
            tabResult.TabIndex = 1;
            tabResult.Text = "📊  Resultado";
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.AllowUserToAddRows = false;
            dataGridViewResult.AllowUserToResizeRows = false;
            dataGridViewResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResult.BackgroundColor = Color.White;
            dataGridViewResult.BorderStyle = BorderStyle.None;
            dataGridViewResult.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewResult.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewResult.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewResult.ColumnHeadersHeight = 40;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { ColumnCodeResult, ColumnQtyResult, ColumnSerieReSult, ColumnExpireResult, ColumnPriceResult, ColumnBatchResult, columnKitResult });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewResult.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewResult.Dock = DockStyle.Fill;
            dataGridViewResult.EnableHeadersVisualStyles = false;
            dataGridViewResult.GridColor = Color.FromArgb(239, 241, 243);
            dataGridViewResult.Location = new Point(200, 80);
            dataGridViewResult.MultiSelect = false;
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewResult.RowHeadersWidth = 45;
            dataGridViewResult.RowTemplate.Height = 35;
            dataGridViewResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResult.Size = new Size(999, 455);
            dataGridViewResult.TabIndex = 28;
            dataGridViewResult.RowPostPaint += dataGridView1_RowPostPaint;
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
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            ColumnQtyResult.DefaultCellStyle = dataGridViewCellStyle5;
            ColumnQtyResult.HeaderText = "Qty";
            ColumnQtyResult.Name = "ColumnQtyResult";
            ColumnQtyResult.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSerieReSult
            // 
            ColumnSerieReSult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnSerieReSult.HeaderText = "SerialNr";
            ColumnSerieReSult.Name = "ColumnSerieReSult";
            ColumnSerieReSult.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            panel15.TabIndex = 16;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(51, 51, 76);
            panel13.Controls.Add(BtnCleanResult);
            panel13.Controls.Add(panelActionsResult);
            panel13.Controls.Add(btnActionsResult);
            panel13.Controls.Add(BtnCopyResult);
            panel13.Controls.Add(panel14);
            panel13.Dock = DockStyle.Left;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(200, 535);
            panel13.TabIndex = 15;
            // 
            // panelActionsResult
            // 
            panelActionsResult.BackColor = Color.FromArgb(64, 64, 95);
            panelActionsResult.Controls.Add(btnExcelResult);
            panelActionsResult.Controls.Add(btnPrintResult);
            panelActionsResult.Dock = DockStyle.Top;
            panelActionsResult.Location = new Point(0, 190);
            panelActionsResult.Name = "panelActionsResult";
            panelActionsResult.Padding = new Padding(40, 0, 0, 0);
            panelActionsResult.Size = new Size(200, 0);
            panelActionsResult.TabIndex = 10;
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
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Gainsboro;
            label8.Location = new Point(59, 30);
            label8.Name = "label8";
            label8.Size = new Size(83, 21);
            label8.TabIndex = 2;
            label8.Text = "Resultado";
            // 
            // tabReceived
            // 
            tabReceived.BackColor = Color.FromArgb(245, 247, 251);
            tabReceived.Controls.Add(dataGridViewReceived);
            tabReceived.Controls.Add(panel2);
            tabReceived.Controls.Add(panel17);
            tabReceived.Font = new Font("Segoe UI", 10F);
            tabReceived.Location = new Point(4, 4);
            tabReceived.Margin = new Padding(0);
            tabReceived.Name = "tabReceived";
            tabReceived.Size = new Size(1199, 535);
            tabReceived.TabIndex = 2;
            tabReceived.Text = "💼  Valija";
            // 
            // dataGridViewReceived
            // 
            dataGridViewReceived.AllowUserToAddRows = false;
            dataGridViewReceived.AllowUserToResizeRows = false;
            dataGridViewReceived.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReceived.BackgroundColor = Color.White;
            dataGridViewReceived.BorderStyle = BorderStyle.None;
            dataGridViewReceived.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewReceived.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridViewReceived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewReceived.ColumnHeadersHeight = 40;
            dataGridViewReceived.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewReceived.Columns.AddRange(new DataGridViewColumn[] { QtyReceived, ArtCodeReceived, SerialNrReceived, DueDateReceived });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dataGridViewReceived.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewReceived.Dock = DockStyle.Fill;
            dataGridViewReceived.EnableHeadersVisualStyles = false;
            dataGridViewReceived.GridColor = Color.FromArgb(239, 241, 243);
            dataGridViewReceived.Location = new Point(200, 80);
            dataGridViewReceived.MultiSelect = false;
            dataGridViewReceived.Name = "dataGridViewReceived";
            dataGridViewReceived.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle11.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewReceived.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewReceived.RowHeadersWidth = 45;
            dataGridViewReceived.RowTemplate.Height = 35;
            dataGridViewReceived.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReceived.Size = new Size(999, 455);
            dataGridViewReceived.TabIndex = 30;
            dataGridViewReceived.RowPostPaint += dataGridView1_RowPostPaint;
            dataGridViewReceived.UserDeletingRow += dataGridViewReceived_UserDeletingRow;
            // 
            // QtyReceived
            // 
            QtyReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            QtyReceived.DefaultCellStyle = dataGridViewCellStyle9;
            QtyReceived.HeaderText = "Unidades";
            QtyReceived.Name = "QtyReceived";
            // 
            // ArtCodeReceived
            // 
            ArtCodeReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ArtCodeReceived.HeaderText = "Código";
            ArtCodeReceived.Name = "ArtCodeReceived";
            // 
            // SerialNrReceived
            // 
            SerialNrReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialNrReceived.HeaderText = "Número de Serie";
            SerialNrReceived.Name = "SerialNrReceived";
            // 
            // DueDateReceived
            // 
            DueDateReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DueDateReceived.HeaderText = "Vencimiento";
            DueDateReceived.Name = "DueDateReceived";
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            panel2.Controls.Add(BtnCleanReceived);
            panel2.Controls.Add(panelActionsReceived);
            panel2.Controls.Add(btnActionsReceived);
            panel2.Controls.Add(BtnHasPila);
            panel2.Controls.Add(BtnManualArticle);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 455);
            panel2.TabIndex = 16;
            // 
            // panelActionsReceived
            // 
            panelActionsReceived.BackColor = Color.FromArgb(64, 64, 95);
            panelActionsReceived.Controls.Add(btnQrReceived);
            panelActionsReceived.Controls.Add(btnExcelReceived);
            panelActionsReceived.Controls.Add(btnPrintReceived);
            panelActionsReceived.Dock = DockStyle.Top;
            panelActionsReceived.Location = new Point(0, 165);
            panelActionsReceived.Name = "panelActionsReceived";
            panelActionsReceived.Padding = new Padding(40, 0, 0, 0);
            panelActionsReceived.Size = new Size(200, 0);
            panelActionsReceived.TabIndex = 9;
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(39, 39, 58);
            panel17.Controls.Add(lblTitleReceived);
            panel17.Controls.Add(lblSerieInputReceived);
            panel17.Controls.Add(lblCodeInputReceived);
            panel17.Controls.Add(TxtPickSerialNumReceived);
            panel17.Controls.Add(TxtPickCodeReceived);
            panel17.Dock = DockStyle.Top;
            panel17.Location = new Point(0, 0);
            panel17.Name = "panel17";
            panel17.Padding = new Padding(0, 20, 20, 20);
            panel17.Size = new Size(1199, 80);
            panel17.TabIndex = 17;
            // 
            // lblTitleReceived
            // 
            lblTitleReceived.AutoSize = true;
            lblTitleReceived.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitleReceived.ForeColor = Color.Gainsboro;
            lblTitleReceived.Location = new Point(74, 29);
            lblTitleReceived.Name = "lblTitleReceived";
            lblTitleReceived.Size = new Size(47, 21);
            lblTitleReceived.TabIndex = 29;
            lblTitleReceived.Text = "Valija";
            // 
            // lblSerieInputReceived
            // 
            lblSerieInputReceived.Anchor = AnchorStyles.Right;
            lblSerieInputReceived.AutoSize = true;
            lblSerieInputReceived.Font = new Font("Segoe UI Semibold", 10F);
            lblSerieInputReceived.ForeColor = Color.Gainsboro;
            lblSerieInputReceived.Location = new Point(881, 48);
            lblSerieInputReceived.Name = "lblSerieInputReceived";
            lblSerieInputReceived.Size = new Size(114, 19);
            lblSerieInputReceived.TabIndex = 28;
            lblSerieInputReceived.Text = "Número de Serie";
            // 
            // lblCodeInputReceived
            // 
            lblCodeInputReceived.Anchor = AnchorStyles.Right;
            lblCodeInputReceived.AutoSize = true;
            lblCodeInputReceived.Font = new Font("Segoe UI Semibold", 10F);
            lblCodeInputReceived.ForeColor = Color.Gainsboro;
            lblCodeInputReceived.Location = new Point(910, 15);
            lblCodeInputReceived.Name = "lblCodeInputReceived";
            lblCodeInputReceived.Size = new Size(54, 19);
            lblCodeInputReceived.TabIndex = 27;
            lblCodeInputReceived.Text = "Código";
            // 
            // TxtPickSerialNumReceived
            // 
            TxtPickSerialNumReceived.Anchor = AnchorStyles.Right;
            TxtPickSerialNumReceived.BackColor = Color.FromArgb(50, 50, 75);
            TxtPickSerialNumReceived.BorderStyle = BorderStyle.FixedSingle;
            TxtPickSerialNumReceived.Font = new Font("Segoe UI", 10F);
            TxtPickSerialNumReceived.ForeColor = Color.White;
            TxtPickSerialNumReceived.Location = new Point(1005, 45);
            TxtPickSerialNumReceived.Name = "TxtPickSerialNumReceived";
            TxtPickSerialNumReceived.Size = new Size(183, 25);
            TxtPickSerialNumReceived.TabIndex = 26;
            TxtPickSerialNumReceived.TextAlign = HorizontalAlignment.Center;
            TxtPickSerialNumReceived.KeyDown += TxtPickSerialNumReceived_KeyDown;
            // 
            // TxtPickCodeReceived
            // 
            TxtPickCodeReceived.Anchor = AnchorStyles.Right;
            TxtPickCodeReceived.BackColor = Color.FromArgb(50, 50, 75);
            TxtPickCodeReceived.BorderStyle = BorderStyle.FixedSingle;
            TxtPickCodeReceived.Font = new Font("Segoe UI", 10F);
            TxtPickCodeReceived.ForeColor = Color.White;
            TxtPickCodeReceived.Location = new Point(1005, 12);
            TxtPickCodeReceived.Name = "TxtPickCodeReceived";
            TxtPickCodeReceived.Size = new Size(183, 25);
            TxtPickCodeReceived.TabIndex = 25;
            TxtPickCodeReceived.TextAlign = HorizontalAlignment.Center;
            TxtPickCodeReceived.KeyDown += TxtPickCodeReceived_KeyDown;
            // 
            // timerMenu
            // 
            timerMenu.Enabled = true;
            timerMenu.Interval = 15;
            timerMenu.Tick += timerMenu_Tick;
            // 
            // FrmRegistrationBase
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1207, 588);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRegistrationBase";
            Text = "Form Base";
            Load += FrmRegistrationBase_Load;
            panel1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            dataGridView1.ResumeLayout(false);
            pnlDropOverlay.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            panel13.ResumeLayout(false);
            panelActionsResult.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            tabReceived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceived).EndInit();
            panel2.ResumeLayout(false);
            panelActionsReceived.ResumeLayout(false);
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            ResumeLayout(false);
        }


        #endregion
        private ToolTip toolTip1;
        private Panel panel1;
        private TabPage tabReceived;
        private Panel panel17;
        private Panel panel2;
        private TabPage tabResult;
        private Panel panel15;
        private Panel panel13;
        private Panel panel14;
        private Label label8;
        private TabPage tabAnexo;
        private DataGridViewCheckBoxColumn IsAquaKit;
        private DataGridViewTextBoxColumn QuantityItem;
        private DataGridViewTextBoxColumn CodItem;
        private DataGridViewTextBoxColumn DescriptionItem;
        private DataGridViewTextBoxColumn SerialNumber;
        private DataGridViewTextBoxColumn DueDate;
        private Panel panel10;
        private Panel panel8;
        private Panel panel9;
        private Panel pnlDropOverlay;
        private Label lblDropInfo;
        protected DataGridView dataGridViewResult;
        protected Button BtnCleanResult;
        protected Button BtnCopyResult;
        protected Label label6;
        protected Label label7;
        protected Panel panelMissItemAnexo;
        protected Panel panelDiffAnexo;
        protected Label lblSerieInputAnexo;
        protected Button BtnTests;
        protected Button BtnCleanAnexo;
        protected Button BtnCreateOpenOrange;
        protected Button BtnCompare;
        protected Button BtnPasteAnexo;
        protected Label lblTitleAnexo;
        protected TextBox TxtSerialNumProcessor;
        protected Panel panelActionsResult;
        protected Button btnExcelResult;
        protected Button btnPrintResult;
        protected Button btnActionsResult;
        protected Label lblSerieInputReceived;
        protected Label lblCodeInputReceived;
        protected TextBox TxtPickSerialNumReceived;
        protected TextBox TxtPickCodeReceived;
        protected Button BtnCleanReceived;
        protected Button BtnHasPila;
        protected Button BtnManualArticle;
        protected Button btnActionsReceived;
        protected Button btnPrintReceived;
        protected Button btnQrReceived;
        protected Button btnExcelReceived;
        protected Label lblTitleReceived;
        protected DataGridView dataGridView1;
        protected TabControl tabControl;
        protected DataGridView dataGridViewReceived;
        protected Panel panelActionsReceived;
        protected System.Windows.Forms.Timer timerMenu;
        private DataGridViewTextBoxColumn QtyReceived;
        private DataGridViewTextBoxColumn ArtCodeReceived;
        private DataGridViewTextBoxColumn SerialNrReceived;
        private DataGridViewTextBoxColumn DueDateReceived;
        private DataGridViewTextBoxColumn ColumnCodeResult;
        private DataGridViewTextBoxColumn ColumnQtyResult;
        private DataGridViewTextBoxColumn ColumnSerieReSult;
        private DataGridViewTextBoxColumn ColumnExpireResult;
        private DataGridViewTextBoxColumn ColumnPriceResult;
        private DataGridViewTextBoxColumn ColumnBatchResult;
        private DataGridViewTextBoxColumn columnKitResult;
    }
}
