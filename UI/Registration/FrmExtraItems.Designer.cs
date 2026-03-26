namespace Control.UI.Registration
{
    partial class FrmExtraItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtraItems));
            dgvExtras = new DataGridView();
            lblTitle = new Label();
            btnCancel = new Button();
            btnInclude = new Button();
            panelBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvExtras).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExtras
            // 
            dgvExtras.AllowUserToAddRows = false;
            dgvExtras.AllowUserToResizeRows = false;
            dgvExtras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExtras.BackgroundColor = Color.White;
            dgvExtras.BorderStyle = BorderStyle.None;
            dgvExtras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExtras.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvExtras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvExtras.ColumnHeadersHeight = 40;
            dgvExtras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvExtras.DefaultCellStyle = dataGridViewCellStyle2;
            dgvExtras.Dock = DockStyle.Fill;
            dgvExtras.EnableHeadersVisualStyles = false;
            dgvExtras.GridColor = Color.FromArgb(239, 241, 243);
            dgvExtras.Location = new Point(5, 71);
            dgvExtras.MultiSelect = false;
            dgvExtras.Name = "dgvExtras";
            dgvExtras.ReadOnly = true;
            dgvExtras.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 247, 251);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(229, 235, 244);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgvExtras.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvExtras.RowHeadersVisible = false;
            dgvExtras.RowTemplate.Height = 35;
            dgvExtras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExtras.Size = new Size(670, 239);
            dgvExtras.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(670, 71);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Ítems sobrantes detectados en la Valija";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(428, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cerrar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnInclude
            // 
            btnInclude.Anchor = AnchorStyles.Right;
            btnInclude.BackColor = Color.FromArgb(0, 120, 215);
            btnInclude.Cursor = Cursors.Hand;
            btnInclude.FlatAppearance.BorderSize = 0;
            btnInclude.FlatStyle = FlatStyle.Flat;
            btnInclude.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInclude.ForeColor = Color.White;
            btnInclude.Location = new Point(538, 12);
            btnInclude.Name = "btnInclude";
            btnInclude.Size = new Size(120, 35);
            btnInclude.TabIndex = 0;
            btnInclude.Text = "Incluir en Anexo";
            btnInclude.UseVisualStyleBackColor = false;
            btnInclude.Click += btnInclude_Click;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnInclude);
            panelBottom.Controls.Add(btnCancel);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(5, 310);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(670, 60);
            panelBottom.TabIndex = 1;
            // 
            // FrmExtraItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 76);
            ClientSize = new Size(680, 370);
            Controls.Add(dgvExtras);
            Controls.Add(panelBottom);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmExtraItems";
            Padding = new Padding(5, 0, 5, 0);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sobrantes detectados";
            ((System.ComponentModel.ISupportInitialize)dgvExtras).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvExtras;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.Panel panelBottom;

        #endregion
    }
}