using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Control
{
    partial class FrmMovementsBernafon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovementsBernafon));
            tabControl = new TabControl();
            tabAnexo = new TabPage();
            dataGridView1 = new DataGridView();
            ArtCode = new DataGridViewTextBoxColumn();
            Qty = new DataGridViewTextBoxColumn();
            SerialNr = new DataGridViewTextBoxColumn();
            pnlDropOverlay = new Panel();
            lblDropInfo = new Label();
            panel10 = new Panel();
            panel8 = new Panel();
            BtnTests = new Button();
            BtnCleanAnexo = new Button();
            BtnCopyResult = new Button();
            BtnPasteAnexo = new Button();
            panel9 = new Panel();
            label5 = new Label();
            btnPrintReceived = new Button();
            tabControl.SuspendLayout();
            tabAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            dataGridView1.SuspendLayout();
            pnlDropOverlay.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.Controls.Add(tabAnexo);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ArtCode, Qty, SerialNr });
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
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.RowHeaderMouseDoubleClick += dataGridView1_RowHeaderMouseDoubleClick;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            dataGridView1.DragLeave += dataGridView1_DragLeave;
            // 
            // ArtCode
            // 
            ArtCode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ArtCode.DataPropertyName = "ArtCode";
            ArtCode.HeaderText = "ArtCode";
            ArtCode.MinimumWidth = 6;
            ArtCode.Name = "ArtCode";
            ArtCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Qty
            // 
            Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Qty.DataPropertyName = "Qty";
            Qty.HeaderText = "Qty";
            Qty.MinimumWidth = 6;
            Qty.Name = "Qty";
            Qty.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // SerialNr
            // 
            SerialNr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SerialNr.DataPropertyName = "SerialNr";
            SerialNr.HeaderText = "SerialNr";
            SerialNr.MinimumWidth = 6;
            SerialNr.Name = "SerialNr";
            SerialNr.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(200, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(999, 80);
            panel10.TabIndex = 1;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(51, 51, 76);
            panel8.Controls.Add(BtnTests);
            panel8.Controls.Add(BtnCleanAnexo);
            panel8.Controls.Add(btnPrintReceived);
            panel8.Controls.Add(BtnCopyResult);
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
            BtnCleanAnexo.UseVisualStyleBackColor = false;
            BtnCleanAnexo.Click += BtnCleanAnexo_Click;
            // 
            // BtnCopyResult
            // 
            BtnCopyResult.Cursor = Cursors.Hand;
            BtnCopyResult.Dock = DockStyle.Top;
            BtnCopyResult.FlatAppearance.BorderSize = 0;
            BtnCopyResult.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnCopyResult.FlatStyle = FlatStyle.Flat;
            BtnCopyResult.Font = new Font("Microsoft Sans Serif", 10F);
            BtnCopyResult.ForeColor = Color.Gainsboro;
            BtnCopyResult.Image = Properties.Resources.CopyPaste2;
            BtnCopyResult.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCopyResult.Location = new Point(0, 135);
            BtnCopyResult.Name = "BtnCopyResult";
            BtnCopyResult.Padding = new Padding(12, 0, 0, 0);
            BtnCopyResult.Size = new Size(200, 55);
            BtnCopyResult.TabIndex = 7;
            BtnCopyResult.Text = "   Copiar Tabla";
            BtnCopyResult.TextAlign = ContentAlignment.MiddleLeft;
            BtnCopyResult.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnCopyResult.UseVisualStyleBackColor = true;
            BtnCopyResult.Click += BtnCopyResult_Click;
            // 
            // BtnPasteAnexo
            // 
            BtnPasteAnexo.Cursor = Cursors.Hand;
            BtnPasteAnexo.Dock = DockStyle.Top;
            BtnPasteAnexo.FlatAppearance.BorderSize = 0;
            BtnPasteAnexo.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            BtnPasteAnexo.FlatStyle = FlatStyle.Flat;
            BtnPasteAnexo.Font = new Font("Microsoft Sans Serif", 10F);
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
            label5.Location = new Point(17, 28);
            label5.Name = "label5";
            label5.Size = new Size(167, 20);
            label5.TabIndex = 2;
            label5.Text = "Movimientos Bernafon";
            // 
            // btnPrintReceived
            // 
            btnPrintReceived.Cursor = Cursors.Hand;
            btnPrintReceived.Dock = DockStyle.Top;
            btnPrintReceived.FlatAppearance.BorderSize = 0;
            btnPrintReceived.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 29, 58);
            btnPrintReceived.FlatStyle = FlatStyle.Flat;
            btnPrintReceived.Font = new Font("Segoe UI Semibold", 10F);
            btnPrintReceived.ForeColor = Color.Gainsboro;
            btnPrintReceived.Image = (Image)resources.GetObject("btnPrintReceived.Image");
            btnPrintReceived.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintReceived.Location = new Point(0, 190);
            btnPrintReceived.Name = "btnPrintReceived";
            btnPrintReceived.Padding = new Padding(12, 0, 0, 0);
            btnPrintReceived.Size = new Size(200, 55);
            btnPrintReceived.TabIndex = 9;
            btnPrintReceived.Text = "   Imprimir";
            btnPrintReceived.TextAlign = ContentAlignment.MiddleLeft;
            btnPrintReceived.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrintReceived.UseVisualStyleBackColor = true;
            btnPrintReceived.Click += btnPrintReceived_Click;
            // 
            // FrmMovementsBernafon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 588);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMovementsBernafon";
            Text = "Movimientos Bernafon";
            Load += FrmMovementsBernafon_Load;
            tabControl.ResumeLayout(false);
            tabAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            dataGridView1.ResumeLayout(false);
            pnlDropOverlay.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
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
        private Button BtnPasteAnexo;
        private Panel panel9;
        private Label label5;
        private Label label11;
        private TextBox TxtPickCodeReceived;
        private Button BtnCopyResult;
        private DataGridViewTextBoxColumn CodItem;
        private DataGridViewTextBoxColumn ArtCode;
        private DataGridViewTextBoxColumn Qty;
        private DataGridViewTextBoxColumn SerialNr;
        private Panel pnlDropOverlay;
        private Label lblDropInfo;
        private Button btnPrintReceived;
    }
}