using System.Drawing;
using System.Windows.Forms;

namespace Control
{
    partial class FrmReporteBernafon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteBernafon));
            toolTip1 = new ToolTip();
            dataGridView1 = new DataGridView();
            colSerial = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            colDepot = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colDias = new DataGridViewTextBoxColumn();
            colEntregado = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            pnlLoad = new Panel();
            lblImport = new Label();
            labelStock = new Label();
            txtStockPath = new TextBox();
            btnExaminarStock = new Button();
            labelMov = new Label();
            txtMovPath = new TextBox();
            btnExaminarMov = new Button();
            BtnGenerar = new Button();
            BtnExcel = new Button();
            BtnPdf = new Button();
            BtnLimpiar = new Button();
            panel10 = new Panel();
            lblMeta = new Label();
            labelTitle = new Label();
            panel8 = new Panel();
            panel9 = new Panel();
            label5 = new Label();
            dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlCards = new Panel();
            tlpCards = new TableLayoutPanel();
            pnlCardEnStock = new Panel();
            barAccentEnStock = new Panel();
            lblTituloEnStock = new Label();
            lblDetalleEnStock = new Label();
            lblValorEnStock = new Label();
            pnlCardVencidos = new Panel();
            barAccentVencidos = new Panel();
            lblTituloVencidos = new Label();
            lblDetalleVencidos = new Label();
            lblValorVencidos = new Label();
            pnlCardEntregados = new Panel();
            barAccentEntregados = new Panel();
            lblTituloEntregados = new Label();
            lblDetalleEntregados = new Label();
            lblValorEntregados = new Label();
            pnlFilters = new Panel();
            labelFiltroDeposito = new Label();
            cmbDeposito = new ComboBox();
            labelFiltroEstado = new Label();
            cmbEstado = new ComboBox();
            labelFiltroBuscar = new Label();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlLoad.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            pnlCards.SuspendLayout();
            tlpCards.SuspendLayout();
            pnlCardEnStock.SuspendLayout();
            pnlCardVencidos.SuspendLayout();
            pnlCardEntregados.SuspendLayout();
            pnlFilters.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colSerial, colCode, colDepot, colFecha, colDias, colEntregado, colEstado });
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(239, 241, 243);
            dataGridView1.Location = new Point(220, 240);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1060, 520);
            dataGridView1.TabIndex = 27;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            // 
            // colSerial
            // 
            colSerial.HeaderText = "Serie";
            colSerial.MinimumWidth = 90;
            colSerial.Name = "colSerial";
            colSerial.ReadOnly = true;
            // 
            // colCode
            // 
            colCode.HeaderText = "Código";
            colCode.MinimumWidth = 70;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            // 
            // colDepot
            // 
            colDepot.HeaderText = "Depósito Actual";
            colDepot.MinimumWidth = 80;
            colDepot.Name = "colDepot";
            colDepot.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha Salida";
            colFecha.MinimumWidth = 80;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colDias
            // 
            colDias.HeaderText = "Días Transcurridos";
            colDias.MinimumWidth = 70;
            colDias.Name = "colDias";
            colDias.ReadOnly = true;
            // 
            // colEntregado
            // 
            colEntregado.HeaderText = "Entregado";
            colEntregado.MinimumWidth = 60;
            colEntregado.Name = "colEntregado";
            colEntregado.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 100;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // dataGridViewCellStyle1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(4, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            // 
            // dataGridViewCellStyle2
            // 
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(4, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(31, 31, 38);
            // 
            // dataGridViewCellStyle3
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(80, 80, 80);
            // 
            // pnlLoad
            // 
            pnlLoad.BackColor = Color.White;
            pnlLoad.Controls.Add(BtnGenerar);
            pnlLoad.Controls.Add(lblImport);
            pnlLoad.Controls.Add(labelStock);
            pnlLoad.Controls.Add(txtStockPath);
            pnlLoad.Controls.Add(btnExaminarStock);
            pnlLoad.Controls.Add(labelMov);
            pnlLoad.Controls.Add(txtMovPath);
            pnlLoad.Controls.Add(btnExaminarMov);
            pnlLoad.Dock = DockStyle.Top;
            pnlLoad.Location = new Point(220, 80);
            pnlLoad.Name = "pnlLoad";
            pnlLoad.Size = new Size(1060, 142);
            pnlLoad.TabIndex = 1;
            // 
            // lblImport
            // 
            lblImport.AutoSize = true;
            lblImport.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblImport.ForeColor = Color.FromArgb(107, 107, 118);
            lblImport.Location = new Point(24, 15);
            lblImport.Name = "lblImport";
            lblImport.Size = new Size(246, 19);
            lblImport.TabIndex = 2;
            lblImport.Text = "IMPORTACIÓN DE ARCHIVOS EXCEL";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Font = new Font("Segoe UI Semibold", 9F);
            labelStock.Location = new Point(24, 73);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(200, 22);
            labelStock.TabIndex = 3;
            labelStock.Text = "Listado de Stock";
            labelStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtStockPath
            // 
            txtStockPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStockPath.BackColor = Color.FromArgb(250, 251, 253);
            txtStockPath.BorderStyle = BorderStyle.FixedSingle;
            txtStockPath.Font = new Font("Segoe UI", 9.5F);
            txtStockPath.ForeColor = Color.FromArgb(107, 107, 118);
            txtStockPath.Location = new Point(230, 71);
            txtStockPath.Name = "txtStockPath";
            txtStockPath.ReadOnly = true;
            txtStockPath.Size = new Size(708, 24);
            txtStockPath.TabIndex = 4;
            // 
            // btnExaminarStock
            // 
            btnExaminarStock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExaminarStock.BackColor = Color.FromArgb(240, 243, 248);
            btnExaminarStock.FlatAppearance.BorderColor = Color.FromArgb(207, 214, 224);
            btnExaminarStock.FlatStyle = FlatStyle.Flat;
            btnExaminarStock.Font = new Font("Segoe UI Semibold", 9F);
            btnExaminarStock.ForeColor = Color.FromArgb(45, 45, 48);
            btnExaminarStock.Location = new Point(948, 71);
            btnExaminarStock.Name = "btnExaminarStock";
            btnExaminarStock.Size = new Size(90, 24);
            btnExaminarStock.TabIndex = 5;
            btnExaminarStock.Text = "Examinar…";
            btnExaminarStock.UseVisualStyleBackColor = true;
            btnExaminarStock.Click += btnExaminarStock_Click;
            // 
            // labelMov
            // 
            labelMov.AutoSize = true;
            labelMov.Font = new Font("Segoe UI Semibold", 9F);
            labelMov.Location = new Point(24, 43);
            labelMov.Name = "labelMov";
            labelMov.Size = new Size(200, 22);
            labelMov.TabIndex = 6;
            labelMov.Text = "Listado de Movimientos de Stock";
            labelMov.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMovPath
            // 
            txtMovPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMovPath.BackColor = Color.FromArgb(250, 251, 253);
            txtMovPath.BorderStyle = BorderStyle.FixedSingle;
            txtMovPath.Font = new Font("Segoe UI", 9.5F);
            txtMovPath.ForeColor = Color.FromArgb(107, 107, 118);
            txtMovPath.Location = new Point(230, 43);
            txtMovPath.Name = "txtMovPath";
            txtMovPath.ReadOnly = true;
            txtMovPath.Size = new Size(708, 24);
            txtMovPath.TabIndex = 7;
            // 
            // btnExaminarMov
            // 
            btnExaminarMov.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExaminarMov.BackColor = Color.FromArgb(240, 243, 248);
            btnExaminarMov.FlatAppearance.BorderColor = Color.FromArgb(207, 214, 224);
            btnExaminarMov.FlatStyle = FlatStyle.Flat;
            btnExaminarMov.Font = new Font("Segoe UI Semibold", 9F);
            btnExaminarMov.ForeColor = Color.FromArgb(45, 45, 48);
            btnExaminarMov.Location = new Point(948, 43);
            btnExaminarMov.Name = "btnExaminarMov";
            btnExaminarMov.Size = new Size(90, 24);
            btnExaminarMov.TabIndex = 8;
            btnExaminarMov.Text = "Examinar…";
            btnExaminarMov.UseVisualStyleBackColor = true;
            btnExaminarMov.Click += btnExaminarMov_Click;
            // 
            // BtnGenerar
            // 
            BtnGenerar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            BtnGenerar.BackColor = Color.FromArgb(74, 125, 255);
            BtnGenerar.FlatAppearance.BorderColor = Color.FromArgb(74, 125, 255);
            BtnGenerar.FlatAppearance.BorderSize = 0;
            BtnGenerar.FlatAppearance.MouseDownBackColor = Color.FromArgb(58, 108, 235);
            BtnGenerar.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 108, 235);
            BtnGenerar.FlatStyle = FlatStyle.Flat;
            BtnGenerar.Font = new Font("Segoe UI Semibold", 10F);
            BtnGenerar.ForeColor = Color.White;
            BtnGenerar.Location = new Point(24, 101);
            BtnGenerar.Name = "BtnGenerar";
            BtnGenerar.Size = new Size(170, 34);
            BtnGenerar.TabIndex = 9;
            BtnGenerar.Text = "Generar Reporte";
            BtnGenerar.UseVisualStyleBackColor = false;
            BtnGenerar.Click += BtnGenerar_Click;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(39, 39, 58);
            panel10.Controls.Add(lblMeta);
            panel10.Controls.Add(labelTitle);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(220, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(1060, 80);
            panel10.TabIndex = 1;
            // 
            // lblMeta
            // 
            lblMeta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMeta.Font = new Font("Segoe UI", 9F);
            lblMeta.ForeColor = Color.FromArgb(168, 168, 184);
            lblMeta.Location = new Point(760, 12);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(280, 54);
            lblMeta.TabIndex = 1;
            lblMeta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Light", 20F);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(30, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(385, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Control de Consignaciones — Bernafon";
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(51, 51, 76);
            panel8.Controls.Add(BtnLimpiar);
            panel8.Controls.Add(BtnPdf);
            panel8.Controls.Add(BtnExcel);
            panel8.Controls.Add(panel9);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(220, 760);
            panel8.TabIndex = 0;
            // 
            // BtnLimpiar
            // 
            BtnLimpiar.BackColor = Color.FromArgb(51, 51, 76);
            BtnLimpiar.Cursor = Cursors.Hand;
            BtnLimpiar.Dock = DockStyle.Top;
            BtnLimpiar.FlatAppearance.BorderSize = 0;
            BtnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnLimpiar.FlatStyle = FlatStyle.Flat;
            BtnLimpiar.Font = new Font("Segoe UI Semibold", 10F);
            BtnLimpiar.ForeColor = Color.Gainsboro;
            BtnLimpiar.Image = Properties.Resources.Clean;
            BtnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnLimpiar.Location = new Point(0, 190);
            BtnLimpiar.Name = "BtnLimpiar";
            BtnLimpiar.Padding = new Padding(12, 0, 0, 0);
            BtnLimpiar.Size = new Size(220, 55);
            BtnLimpiar.TabIndex = 3;
            BtnLimpiar.Text = "   Limpiar";
            BtnLimpiar.TextAlign = ContentAlignment.MiddleLeft;
            BtnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnLimpiar, "Limpiar ventana");
            BtnLimpiar.UseVisualStyleBackColor = false;
            BtnLimpiar.Click += BtnLimpiar_Click;
            // 
            // BtnPdf
            // 
            BtnPdf.BackColor = Color.FromArgb(51, 51, 76);
            BtnPdf.Cursor = Cursors.Hand;
            BtnPdf.Dock = DockStyle.Top;
            BtnPdf.FlatAppearance.BorderSize = 0;
            BtnPdf.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnPdf.FlatStyle = FlatStyle.Flat;
            BtnPdf.Font = new Font("Segoe UI Semibold", 10F);
            BtnPdf.ForeColor = Color.Gainsboro;
            BtnPdf.Image = (Image)resources.GetObject("BtnPdf.Image");
            BtnPdf.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPdf.Location = new Point(0, 135);
            BtnPdf.Name = "BtnPdf";
            BtnPdf.Padding = new Padding(12, 0, 0, 0);
            BtnPdf.Size = new Size(220, 55);
            BtnPdf.TabIndex = 4;
            BtnPdf.Text = "   Exportar PDF";
            BtnPdf.TextAlign = ContentAlignment.MiddleLeft;
            BtnPdf.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnPdf, "Exportar el reporte a PDF");
            BtnPdf.UseVisualStyleBackColor = false;
            BtnPdf.Click += BtnPdf_Click;
            // 
            // BtnExcel
            // 
            BtnExcel.BackColor = Color.FromArgb(51, 51, 76);
            BtnExcel.Cursor = Cursors.Hand;
            BtnExcel.Dock = DockStyle.Top;
            BtnExcel.FlatAppearance.BorderSize = 0;
            BtnExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnExcel.FlatStyle = FlatStyle.Flat;
            BtnExcel.Font = new Font("Segoe UI Semibold", 10F);
            BtnExcel.ForeColor = Color.Gainsboro;
            BtnExcel.Image = (Image)resources.GetObject("BtnExcel.Image");
            BtnExcel.ImageAlign = ContentAlignment.MiddleLeft;
            BtnExcel.Location = new Point(0, 80);
            BtnExcel.Name = "BtnExcel";
            BtnExcel.Padding = new Padding(12, 0, 0, 0);
            BtnExcel.Size = new Size(220, 55);
            BtnExcel.TabIndex = 5;
            BtnExcel.Text = "   Exportar Excel";
            BtnExcel.TextAlign = ContentAlignment.MiddleLeft;
            BtnExcel.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(BtnExcel, "Exportar el reporte a Excel");
            BtnExcel.UseVisualStyleBackColor = false;
            BtnExcel.Click += BtnExcel_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(39, 39, 58);
            panel9.Controls.Add(label5);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(220, 80);
            panel9.TabIndex = 1;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 13F);
            label5.ForeColor = Color.FromArgb(220, 220, 224);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(220, 80);
            label5.TabIndex = 0;
            label5.Text = "Reporte Bernafon\r\nConsignaciones";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(txtBuscar);
            pnlFilters.Controls.Add(labelFiltroBuscar);
            pnlFilters.Controls.Add(cmbEstado);
            pnlFilters.Controls.Add(labelFiltroEstado);
            pnlFilters.Controls.Add(cmbDeposito);
            pnlFilters.Controls.Add(labelFiltroDeposito);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(220, 342);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(0);
            pnlFilters.Size = new Size(1060, 50);
            pnlFilters.TabIndex = 3;
            // 
            // labelFiltroDeposito
            // 
            labelFiltroDeposito.AutoSize = true;
            labelFiltroDeposito.Font = new Font("Segoe UI", 9F);
            labelFiltroDeposito.ForeColor = Color.FromArgb(90, 90, 108);
            labelFiltroDeposito.Location = new Point(30, 17);
            labelFiltroDeposito.Name = "labelFiltroDeposito";
            labelFiltroDeposito.Size = new Size(47, 15);
            labelFiltroDeposito.TabIndex = 0;
            labelFiltroDeposito.Text = "Depósito:";
            // 
            // cmbDeposito
            // 
            cmbDeposito.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDeposito.Font = new Font("Segoe UI", 9F);
            cmbDeposito.FormattingEnabled = true;
            cmbDeposito.Location = new Point(102, 13);
            cmbDeposito.Name = "cmbDeposito";
            cmbDeposito.Size = new Size(160, 23);
            cmbDeposito.TabIndex = 1;
            // 
            // labelFiltroEstado
            // 
            labelFiltroEstado.AutoSize = true;
            labelFiltroEstado.Font = new Font("Segoe UI", 9F);
            labelFiltroEstado.ForeColor = Color.FromArgb(90, 90, 108);
            labelFiltroEstado.Location = new Point(290, 17);
            labelFiltroEstado.Name = "labelFiltroEstado";
            labelFiltroEstado.Size = new Size(41, 15);
            labelFiltroEstado.TabIndex = 2;
            labelFiltroEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 9F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(356, 13);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(190, 23);
            cmbEstado.TabIndex = 3;
            // 
            // labelFiltroBuscar
            // 
            labelFiltroBuscar.AutoSize = true;
            labelFiltroBuscar.Font = new Font("Segoe UI", 9F);
            labelFiltroBuscar.ForeColor = Color.FromArgb(90, 90, 108);
            labelFiltroBuscar.Location = new Point(574, 17);
            labelFiltroBuscar.Name = "labelFiltroBuscar";
            labelFiltroBuscar.Size = new Size(43, 15);
            labelFiltroBuscar.TabIndex = 4;
            labelFiltroBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.Location = new Point(642, 13);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Serie o código...";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 5;
            // 
            // pnlCards
            // 
            pnlCards.BackColor = Color.White;
            pnlCards.Controls.Add(tlpCards);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(220, 222);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new Size(1060, 118);
            pnlCards.TabIndex = 2;
            // 
            // tlpCards
            // 
            tlpCards.ColumnCount = 3;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpCards.Controls.Add(pnlCardEnStock, 0, 0);
            tlpCards.Controls.Add(pnlCardVencidos, 1, 0);
            tlpCards.Controls.Add(pnlCardEntregados, 2, 0);
            tlpCards.Dock = DockStyle.Fill;
            tlpCards.Location = new Point(0, 0);
            tlpCards.Margin = new Padding(0);
            tlpCards.Name = "tlpCards";
            tlpCards.Padding = new Padding(0, 12, 0, 12);
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(1060, 118);
            tlpCards.TabIndex = 0;
            // 
            // pnlCardEnStock
            // 
            pnlCardEnStock.BackColor = Color.FromArgb(240, 244, 255);
            pnlCardEnStock.Controls.Add(lblValorEnStock);
            pnlCardEnStock.Controls.Add(lblDetalleEnStock);
            pnlCardEnStock.Controls.Add(lblTituloEnStock);
            pnlCardEnStock.Controls.Add(barAccentEnStock);
            pnlCardEnStock.Cursor = Cursors.Hand;
            pnlCardEnStock.Dock = DockStyle.Fill;
            pnlCardEnStock.Location = new Point(20, 14);
            pnlCardEnStock.Margin = new Padding(20, 0, 20, 0);
            pnlCardEnStock.Name = "pnlCardEnStock";
            pnlCardEnStock.Padding = new Padding(20, 0, 12, 0);
            pnlCardEnStock.Size = new Size(313, 94);
            pnlCardEnStock.TabIndex = 0;
            // 
            // barAccentEnStock
            // 
            barAccentEnStock.BackColor = Color.FromArgb(74, 125, 255);
            barAccentEnStock.Dock = DockStyle.Left;
            barAccentEnStock.Location = new Point(0, 0);
            barAccentEnStock.Margin = new Padding(0);
            barAccentEnStock.Name = "barAccentEnStock";
            barAccentEnStock.Size = new Size(5, 94);
            barAccentEnStock.TabIndex = 4;
            // 
            // lblTituloEnStock
            // 
            lblTituloEnStock.Dock = DockStyle.Top;
            lblTituloEnStock.Font = new Font("Segoe UI Semibold", 8.5F);
            lblTituloEnStock.ForeColor = Color.FromArgb(90, 90, 108);
            lblTituloEnStock.Location = new Point(25, 0);
            lblTituloEnStock.Name = "lblTituloEnStock";
            lblTituloEnStock.Padding = new Padding(0);
            lblTituloEnStock.Size = new Size(276, 24);
            lblTituloEnStock.TabIndex = 3;
            lblTituloEnStock.Text = "EN STOCK";
            lblTituloEnStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalleEnStock
            // 
            lblDetalleEnStock.Dock = DockStyle.Bottom;
            lblDetalleEnStock.Font = new Font("Segoe UI", 8F);
            lblDetalleEnStock.ForeColor = Color.FromArgb(130, 130, 150);
            lblDetalleEnStock.Location = new Point(25, 52);
            lblDetalleEnStock.Name = "lblDetalleEnStock";
            lblDetalleEnStock.Padding = new Padding(0);
            lblDetalleEnStock.Size = new Size(276, 20);
            lblDetalleEnStock.TabIndex = 2;
            lblDetalleEnStock.Text = "-";
            lblDetalleEnStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorEnStock
            // 
            lblValorEnStock.Dock = DockStyle.Fill;
            lblValorEnStock.Font = new Font("Segoe UI Semibold", 22F);
            lblValorEnStock.ForeColor = Color.FromArgb(31, 31, 58);
            lblValorEnStock.Location = new Point(25, 24);
            lblValorEnStock.Name = "lblValorEnStock";
            lblValorEnStock.Size = new Size(276, 50);
            lblValorEnStock.TabIndex = 1;
            lblValorEnStock.Text = "0";
            lblValorEnStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardVencidos
            // 
            pnlCardVencidos.BackColor = Color.FromArgb(253, 240, 241);
            pnlCardVencidos.Controls.Add(lblValorVencidos);
            pnlCardVencidos.Controls.Add(lblDetalleVencidos);
            pnlCardVencidos.Controls.Add(lblTituloVencidos);
            pnlCardVencidos.Controls.Add(barAccentVencidos);
            pnlCardVencidos.Cursor = Cursors.Hand;
            pnlCardVencidos.Dock = DockStyle.Fill;
            pnlCardVencidos.Location = new Point(373, 14);
            pnlCardVencidos.Margin = new Padding(20, 0, 20, 0);
            pnlCardVencidos.Name = "pnlCardVencidos";
            pnlCardVencidos.Padding = new Padding(20, 0, 12, 0);
            pnlCardVencidos.Size = new Size(313, 94);
            pnlCardVencidos.TabIndex = 1;
            // 
            // barAccentVencidos
            // 
            barAccentVencidos.BackColor = Color.FromArgb(214, 69, 88);
            barAccentVencidos.Dock = DockStyle.Left;
            barAccentVencidos.Location = new Point(0, 0);
            barAccentVencidos.Margin = new Padding(0);
            barAccentVencidos.Name = "barAccentVencidos";
            barAccentVencidos.Size = new Size(5, 94);
            barAccentVencidos.TabIndex = 4;
            // 
            // lblTituloVencidos
            // 
            lblTituloVencidos.Dock = DockStyle.Top;
            lblTituloVencidos.Font = new Font("Segoe UI Semibold", 8.5F);
            lblTituloVencidos.ForeColor = Color.FromArgb(90, 90, 108);
            lblTituloVencidos.Location = new Point(25, 0);
            lblTituloVencidos.Name = "lblTituloVencidos";
            lblTituloVencidos.Padding = new Padding(0);
            lblTituloVencidos.Size = new Size(276, 24);
            lblTituloVencidos.TabIndex = 3;
            lblTituloVencidos.Text = "VENCIDOS";
            lblTituloVencidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalleVencidos
            // 
            lblDetalleVencidos.Dock = DockStyle.Bottom;
            lblDetalleVencidos.Font = new Font("Segoe UI", 8F);
            lblDetalleVencidos.ForeColor = Color.FromArgb(130, 130, 150);
            lblDetalleVencidos.Location = new Point(25, 52);
            lblDetalleVencidos.Name = "lblDetalleVencidos";
            lblDetalleVencidos.Padding = new Padding(0);
            lblDetalleVencidos.Size = new Size(276, 20);
            lblDetalleVencidos.TabIndex = 2;
            lblDetalleVencidos.Text = "-";
            lblDetalleVencidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorVencidos
            // 
            lblValorVencidos.Dock = DockStyle.Fill;
            lblValorVencidos.Font = new Font("Segoe UI Semibold", 22F);
            lblValorVencidos.ForeColor = Color.FromArgb(31, 31, 58);
            lblValorVencidos.Location = new Point(25, 24);
            lblValorVencidos.Name = "lblValorVencidos";
            lblValorVencidos.Size = new Size(276, 50);
            lblValorVencidos.TabIndex = 1;
            lblValorVencidos.Text = "0";
            lblValorVencidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCardEntregados
            // 
            pnlCardEntregados.BackColor = Color.FromArgb(238, 249, 242);
            pnlCardEntregados.Controls.Add(lblValorEntregados);
            pnlCardEntregados.Controls.Add(lblDetalleEntregados);
            pnlCardEntregados.Controls.Add(lblTituloEntregados);
            pnlCardEntregados.Controls.Add(barAccentEntregados);
            pnlCardEntregados.Cursor = Cursors.Hand;
            pnlCardEntregados.Dock = DockStyle.Fill;
            pnlCardEntregados.Location = new Point(727, 14);
            pnlCardEntregados.Margin = new Padding(20, 0, 20, 0);
            pnlCardEntregados.Name = "pnlCardEntregados";
            pnlCardEntregados.Padding = new Padding(20, 0, 12, 0);
            pnlCardEntregados.Size = new Size(313, 94);
            pnlCardEntregados.TabIndex = 2;
            // 
            // barAccentEntregados
            // 
            barAccentEntregados.BackColor = Color.FromArgb(46, 158, 91);
            barAccentEntregados.Dock = DockStyle.Left;
            barAccentEntregados.Location = new Point(0, 0);
            barAccentEntregados.Margin = new Padding(0);
            barAccentEntregados.Name = "barAccentEntregados";
            barAccentEntregados.Size = new Size(5, 94);
            barAccentEntregados.TabIndex = 4;
            // 
            // lblTituloEntregados
            // 
            lblTituloEntregados.Dock = DockStyle.Top;
            lblTituloEntregados.Font = new Font("Segoe UI Semibold", 8.5F);
            lblTituloEntregados.ForeColor = Color.FromArgb(90, 90, 108);
            lblTituloEntregados.Location = new Point(25, 0);
            lblTituloEntregados.Name = "lblTituloEntregados";
            lblTituloEntregados.Padding = new Padding(0);
            lblTituloEntregados.Size = new Size(276, 24);
            lblTituloEntregados.TabIndex = 3;
            lblTituloEntregados.Text = "ENTREGADOS";
            lblTituloEntregados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDetalleEntregados
            // 
            lblDetalleEntregados.Dock = DockStyle.Bottom;
            lblDetalleEntregados.Font = new Font("Segoe UI", 8F);
            lblDetalleEntregados.ForeColor = Color.FromArgb(130, 130, 150);
            lblDetalleEntregados.Location = new Point(25, 52);
            lblDetalleEntregados.Name = "lblDetalleEntregados";
            lblDetalleEntregados.Padding = new Padding(0);
            lblDetalleEntregados.Size = new Size(276, 20);
            lblDetalleEntregados.TabIndex = 2;
            lblDetalleEntregados.Text = "-";
            lblDetalleEntregados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValorEntregados
            // 
            lblValorEntregados.Dock = DockStyle.Fill;
            lblValorEntregados.Font = new Font("Segoe UI Semibold", 22F);
            lblValorEntregados.ForeColor = Color.FromArgb(31, 31, 58);
            lblValorEntregados.Location = new Point(25, 24);
            lblValorEntregados.Name = "lblValorEntregados";
            lblValorEntregados.Size = new Size(276, 50);
            lblValorEntregados.TabIndex = 1;
            lblValorEntregados.Text = "0";
            lblValorEntregados.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmReporteBernafon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1280, 760);
            Controls.Add(dataGridView1);
            Controls.Add(pnlFilters);
            Controls.Add(pnlCards);
            Controls.Add(pnlLoad);
            Controls.Add(panel10);
            Controls.Add(panel8);
            MinimumSize = new Size(986, 585);
            Name = "FrmReporteBernafon";
            Text = "Reporte de Consignaciones Bernafon";
            Load += FrmReporteBernafon_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlLoad.ResumeLayout(false);
            pnlLoad.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            pnlCards.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            pnlCardEnStock.ResumeLayout(false);
            pnlCardEnStock.PerformLayout();
            pnlCardVencidos.ResumeLayout(false);
            pnlCardVencidos.PerformLayout();
            pnlCardEntregados.ResumeLayout(false);
            pnlCardEntregados.PerformLayout();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dataGridView1;
        private Panel pnlLoad;
        private Label lblImport;
        private Label labelStock;
        private TextBox txtStockPath;
        private Button btnExaminarStock;
        private Label labelMov;
        private TextBox txtMovPath;
        private Button btnExaminarMov;
        private Panel panel10;
        private Label lblMeta;
        private Label labelTitle;
        private Panel panel8;
        private Panel panel9;
        private Label label5;
        private Button BtnLimpiar;
        private Button BtnGenerar;
        private Button BtnExcel;
        private Button BtnPdf;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn colSerial;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colDepot;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colDias;
        private DataGridViewTextBoxColumn colEntregado;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewCellStyle dataGridViewCellStyle1;
        private DataGridViewCellStyle dataGridViewCellStyle2;
        private DataGridViewCellStyle dataGridViewCellStyle3;
        private Panel pnlCards;
        private TableLayoutPanel tlpCards;
        private Panel pnlCardEnStock;
        private Panel barAccentEnStock;
        private Label lblTituloEnStock;
        private Label lblDetalleEnStock;
        private Label lblValorEnStock;
        private Panel pnlCardVencidos;
        private Panel barAccentVencidos;
        private Label lblTituloVencidos;
        private Label lblDetalleVencidos;
        private Label lblValorVencidos;
        private Panel pnlCardEntregados;
        private Panel barAccentEntregados;
        private Label lblTituloEntregados;
        private Label lblDetalleEntregados;
        private Label lblValorEntregados;
        private Panel pnlFilters;
        private Label labelFiltroDeposito;
        private ComboBox cmbDeposito;
        private Label labelFiltroEstado;
        private ComboBox cmbEstado;
        private Label labelFiltroBuscar;
        private TextBox txtBuscar;
    }
}