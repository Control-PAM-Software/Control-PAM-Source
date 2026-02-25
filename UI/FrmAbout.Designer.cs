namespace Control
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            panelSidebar = new Panel();
            lblAppName = new Label();
            label1 = new Label();
            lblVersion = new Label();
            rtbChangeset = new RichTextBox();
            lblCopyright = new Label();
            btnOk = new Button();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(45, 45, 48);
            panelSidebar.Controls.Add(lblAppName);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(140, 320);
            panelSidebar.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(12, 24);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(115, 80);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Gestor Inventario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(45, 45, 48);
            label1.Location = new Point(158, 24);
            label1.Name = "label1";
            label1.Size = new Size(187, 21);
            label1.TabIndex = 1;
            label1.Text = "Información del Sistema";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 10F);
            lblVersion.Location = new Point(160, 65);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(102, 19);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Versión: 1.0.0.0";
            // 
            // rtbChangeset
            // 
            rtbChangeset.BackColor = Color.White;
            rtbChangeset.BorderStyle = BorderStyle.None;
            rtbChangeset.Font = new Font("Segoe UI", 9F);
            rtbChangeset.Location = new Point(160, 95);
            rtbChangeset.Name = "rtbChangeset";
            rtbChangeset.ReadOnly = true;
            rtbChangeset.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChangeset.Size = new Size(280, 160);
            rtbChangeset.TabIndex = 3;
            rtbChangeset.Text = "";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 8F);
            lblCopyright.ForeColor = Color.Gray;
            lblCopyright.Location = new Point(160, 285);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(119, 13);
            lblCopyright.TabIndex = 5;
            lblCopyright.Text = "© 2026 - Empresa S.A.";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(45, 45, 48);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(360, 275);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(80, 30);
            btnOk.TabIndex = 6;
            btnOk.Text = "Cerrar";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // FrmAbout
            // 
            BackColor = Color.White;
            ClientSize = new Size(460, 320);
            Controls.Add(btnOk);
            Controls.Add(lblCopyright);
            Controls.Add(rtbChangeset);
            Controls.Add(lblVersion);
            Controls.Add(label1);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Acerca de...";
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelSidebar;
        private Label lblAppName;
        private Label label1;
        private Label lblVersion;
        private RichTextBox rtbChangeset;
        private Label lblCopyright;
        private Button btnOk;
    }
}