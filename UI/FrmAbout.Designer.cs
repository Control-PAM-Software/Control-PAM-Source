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
            picLogo = new PictureBox();
            lblAppName = new Label();
            panelSidebarLine = new Panel();
            lblSlogan = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelDivider1 = new Panel();
            lblHeaderInfo = new Label();
            lblVersionCaption = new Label();
            lblVersionValue = new Label();
            panelDivider2 = new Panel();
            lblHeaderChanges = new Label();
            panelChangeset = new Panel();
            lblChangesetVersion = new Label();
            rtbChangeset = new NoCaretRichTextBox();
            btnOk = new Button();
            lblCopyright = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelChangeset.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(45, 45, 48);
            panelSidebar.Controls.Add(picLogo);
            panelSidebar.Controls.Add(lblAppName);
            panelSidebar.Controls.Add(panelSidebarLine);
            panelSidebar.Controls.Add(lblSlogan);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(150, 420);
            panelSidebar.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(51, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(48, 48);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(8, 120);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(134, 80);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "Gestor\nInventario\nPAM";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSidebarLine
            // 
            panelSidebarLine.BackColor = Color.FromArgb(78, 78, 85);
            panelSidebarLine.Location = new Point(30, 214);
            panelSidebarLine.Name = "panelSidebarLine";
            panelSidebarLine.Size = new Size(90, 1);
            panelSidebarLine.TabIndex = 3;
            // 
            // lblSlogan
            // 
            lblSlogan.Font = new Font("Segoe UI", 8.5F);
            lblSlogan.ForeColor = Color.FromArgb(166, 166, 173);
            lblSlogan.Location = new Point(10, 226);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(130, 56);
            lblSlogan.TabIndex = 4;
            lblSlogan.Text = "Sistema de Gestión\r\nde Inventario\r\ny Control";
            lblSlogan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(36, 36, 42);
            lblTitle.Location = new Point(170, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 36);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Acerca de Control PAM";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(124, 124, 132);
            lblSubtitle.Location = new Point(172, 56);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(349, 17);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Información de la versión instalada y cambios recientes.";
            // 
            // panelDivider1
            // 
            panelDivider1.BackColor = Color.FromArgb(224, 224, 228);
            panelDivider1.Location = new Point(170, 90);
            panelDivider1.Name = "panelDivider1";
            panelDivider1.Size = new Size(452, 1);
            panelDivider1.TabIndex = 3;
            // 
            // lblHeaderInfo
            // 
            lblHeaderInfo.AutoSize = true;
            lblHeaderInfo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblHeaderInfo.ForeColor = Color.FromArgb(134, 134, 142);
            lblHeaderInfo.Location = new Point(170, 108);
            lblHeaderInfo.Name = "lblHeaderInfo";
            lblHeaderInfo.Size = new Size(88, 15);
            lblHeaderInfo.TabIndex = 4;
            lblHeaderInfo.Text = "INFORMACIÓN";
            // 
            // lblVersionCaption
            // 
            lblVersionCaption.AutoSize = true;
            lblVersionCaption.Font = new Font("Segoe UI", 8F);
            lblVersionCaption.ForeColor = Color.FromArgb(154, 154, 162);
            lblVersionCaption.Location = new Point(170, 134);
            lblVersionCaption.Name = "lblVersionCaption";
            lblVersionCaption.Size = new Size(48, 13);
            lblVersionCaption.TabIndex = 5;
            lblVersionCaption.Text = "Versión";
            // 
            // lblVersionValue
            // 
            lblVersionValue.AutoSize = true;
            lblVersionValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVersionValue.ForeColor = Color.FromArgb(36, 36, 42);
            lblVersionValue.Location = new Point(170, 152);
            lblVersionValue.Name = "lblVersionValue";
            lblVersionValue.Size = new Size(69, 25);
            lblVersionValue.TabIndex = 6;
            lblVersionValue.Text = "v5.5.1";
            // 
            // panelDivider2
            // 
            panelDivider2.BackColor = Color.FromArgb(224, 224, 228);
            panelDivider2.Location = new Point(170, 188);
            panelDivider2.Name = "panelDivider2";
            panelDivider2.Size = new Size(452, 1);
            panelDivider2.TabIndex = 7;
            // 
            // lblHeaderChanges
            // 
            lblHeaderChanges.AutoSize = true;
            lblHeaderChanges.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblHeaderChanges.ForeColor = Color.FromArgb(134, 134, 142);
            lblHeaderChanges.Location = new Point(170, 206);
            lblHeaderChanges.Name = "lblHeaderChanges";
            lblHeaderChanges.Size = new Size(130, 15);
            lblHeaderChanges.TabIndex = 8;
            lblHeaderChanges.Text = "REGISTRO DE CAMBIOS";
            // 
            // panelChangeset
            // 
            panelChangeset.BackColor = Color.FromArgb(250, 250, 252);
            panelChangeset.BorderStyle = BorderStyle.FixedSingle;
            panelChangeset.Controls.Add(lblChangesetVersion);
            panelChangeset.Controls.Add(rtbChangeset);
            panelChangeset.Location = new Point(170, 224);
            panelChangeset.Name = "panelChangeset";
            panelChangeset.Size = new Size(452, 140);
            panelChangeset.TabIndex = 9;
            // 
            // lblChangesetVersion
            // 
            lblChangesetVersion.AutoSize = true;
            lblChangesetVersion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblChangesetVersion.ForeColor = Color.FromArgb(59, 59, 65);
            lblChangesetVersion.Location = new Point(12, 8);
            lblChangesetVersion.Name = "lblChangesetVersion";
            lblChangesetVersion.Size = new Size(54, 15);
            lblChangesetVersion.TabIndex = 0;
            lblChangesetVersion.Text = "…";
            // 
            // rtbChangeset
            // 
            rtbChangeset.BackColor = Color.FromArgb(250, 250, 252);
            rtbChangeset.BorderStyle = BorderStyle.None;
            rtbChangeset.Font = new Font("Segoe UI", 9.5F);
            rtbChangeset.Location = new Point(12, 30);
            rtbChangeset.Name = "rtbChangeset";
            rtbChangeset.ReadOnly = true;
            rtbChangeset.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChangeset.ShortcutsEnabled = false;
            rtbChangeset.Size = new Size(428, 98);
            rtbChangeset.TabIndex = 1;
            rtbChangeset.TabStop = false;
            rtbChangeset.Text = "";
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(45, 45, 48);
            btnOk.Cursor = Cursors.Hand;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI Semibold", 9.5F);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(532, 378);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(90, 30);
            btnOk.TabIndex = 10;
            btnOk.Text = "Cerrar";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 8.5F);
            lblCopyright.ForeColor = Color.FromArgb(154, 154, 162);
            lblCopyright.Location = new Point(170, 387);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(119, 15);
            lblCopyright.TabIndex = 11;
            lblCopyright.Text = "© 2026 - Empresa S.A.";
            // 
            // FrmAbout
            // 
            BackColor = Color.White;
            ClientSize = new Size(640, 420);
            Controls.Add(lblCopyright);
            Controls.Add(btnOk);
            Controls.Add(panelChangeset);
            Controls.Add(lblHeaderChanges);
            Controls.Add(panelDivider2);
            Controls.Add(lblVersionValue);
            Controls.Add(lblVersionCaption);
            Controls.Add(lblHeaderInfo);
            Controls.Add(panelDivider1);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(panelSidebar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Acerca de";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelChangeset.ResumeLayout(false);
            panelChangeset.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelSidebar;
        private PictureBox picLogo;
        private Label lblAppName;
        private Panel panelSidebarLine;
        private Label lblSlogan;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelDivider1;
        private Label lblHeaderInfo;
        private Label lblVersionCaption;
        private Label lblVersionValue;
        private Panel panelDivider2;
        private Label lblHeaderChanges;
        private Panel panelChangeset;
        private Label lblChangesetVersion;
        private NoCaretRichTextBox rtbChangeset;
        private Button btnOk;
        private Label lblCopyright;
    }
}