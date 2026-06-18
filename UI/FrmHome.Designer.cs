using System.Windows.Forms;

namespace Control
{
    partial class FrmHome
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            menuStrip1 = new MenuStrip();
            stockToolStripMenuItem = new ToolStripMenuItem();
            ingresoValijasToolStripMenuItem = new ToolStripMenuItem();
            accesoriosToolStripMenuItem1 = new ToolStripMenuItem();
            valijasToolStripMenuItem = new ToolStripMenuItem();
            atosToolStripMenuItem1 = new ToolStripMenuItem();
            oticomToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem1 = new ToolStripMenuItem();
            aBToolStripMenuItem1 = new ToolStripMenuItem();
            atosToolStripMenuItem = new ToolStripMenuItem();
            bernafonToolStripMenuItem = new ToolStripMenuItem();
            inomedToolStripMenuItem = new ToolStripMenuItem();
            oticomToolStripMenuItem1 = new ToolStripMenuItem();
            movimientoToolStripMenuItem = new ToolStripMenuItem();
            bernafonToolStripMenuItem1 = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(45, 45, 48);
            menuStrip1.Font = new Font("Segoe UI Semibold", 10F);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { stockToolStripMenuItem, inventarioToolStripMenuItem1, movimientoToolStripMenuItem, configuraciónToolStripMenuItem, acercaDeToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 6, 0, 6);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1207, 35);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // stockToolStripMenuItem
            // 
            stockToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresoValijasToolStripMenuItem, atosToolStripMenuItem1, oticomToolStripMenuItem });
            stockToolStripMenuItem.ForeColor = Color.White;
            stockToolStripMenuItem.Margin = new Padding(5, 0, 5, 0);
            stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            stockToolStripMenuItem.Size = new Size(67, 23);
            stockToolStripMenuItem.Text = "Ingreso";
            // 
            // ingresoValijasToolStripMenuItem
            // 
            ingresoValijasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { accesoriosToolStripMenuItem1, valijasToolStripMenuItem });
            ingresoValijasToolStripMenuItem.Name = "ingresoValijasToolStripMenuItem";
            ingresoValijasToolStripMenuItem.Size = new Size(125, 24);
            ingresoValijasToolStripMenuItem.Text = "AB";
            // 
            // accesoriosToolStripMenuItem1
            // 
            accesoriosToolStripMenuItem1.Name = "accesoriosToolStripMenuItem1";
            accesoriosToolStripMenuItem1.Size = new Size(145, 24);
            accesoriosToolStripMenuItem1.Text = "Accesorios";
            accesoriosToolStripMenuItem1.Click += accesoriosToolStripMenuItem1_Click;
            // 
            // valijasToolStripMenuItem
            // 
            valijasToolStripMenuItem.Name = "valijasToolStripMenuItem";
            valijasToolStripMenuItem.Size = new Size(145, 24);
            valijasToolStripMenuItem.Text = "Valijas";
            valijasToolStripMenuItem.Click += valijasToolStripMenuItem_Click;
            // 
            // atosToolStripMenuItem1
            // 
            atosToolStripMenuItem1.Name = "atosToolStripMenuItem1";
            atosToolStripMenuItem1.Size = new Size(125, 24);
            atosToolStripMenuItem1.Text = "Atos";
            atosToolStripMenuItem1.Click += atosToolStripMenuItem1_Click;
            // 
            // oticomToolStripMenuItem
            // 
            oticomToolStripMenuItem.Name = "oticomToolStripMenuItem";
            oticomToolStripMenuItem.Size = new Size(125, 24);
            oticomToolStripMenuItem.Text = "Oticom";
            oticomToolStripMenuItem.Click += oticomToolStripMenuItem_Click;
            // 
            // inventarioToolStripMenuItem1
            // 
            inventarioToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { aBToolStripMenuItem1, atosToolStripMenuItem, bernafonToolStripMenuItem, inomedToolStripMenuItem, oticomToolStripMenuItem1 });
            inventarioToolStripMenuItem1.ForeColor = Color.White;
            inventarioToolStripMenuItem1.Margin = new Padding(5, 0, 5, 0);
            inventarioToolStripMenuItem1.Name = "inventarioToolStripMenuItem1";
            inventarioToolStripMenuItem1.Size = new Size(84, 23);
            inventarioToolStripMenuItem1.Text = "Inventario";
            // 
            // aBToolStripMenuItem1
            // 
            aBToolStripMenuItem1.Name = "aBToolStripMenuItem1";
            aBToolStripMenuItem1.Size = new Size(134, 24);
            aBToolStripMenuItem1.Text = "AB";
            aBToolStripMenuItem1.Click += aBToolStripMenuItem1_Click;
            // 
            // atosToolStripMenuItem
            // 
            atosToolStripMenuItem.Name = "atosToolStripMenuItem";
            atosToolStripMenuItem.Size = new Size(134, 24);
            atosToolStripMenuItem.Text = "Atos";
            atosToolStripMenuItem.Click += atosToolStripMenuItem_Click;
            // 
            // bernafonToolStripMenuItem
            // 
            bernafonToolStripMenuItem.Name = "bernafonToolStripMenuItem";
            bernafonToolStripMenuItem.Size = new Size(134, 24);
            bernafonToolStripMenuItem.Text = "Bernafon";
            bernafonToolStripMenuItem.Click += bernafonToolStripMenuItem_Click;
            // 
            // inomedToolStripMenuItem
            // 
            inomedToolStripMenuItem.Name = "inomedToolStripMenuItem";
            inomedToolStripMenuItem.Size = new Size(134, 24);
            inomedToolStripMenuItem.Text = "Inomed";
            inomedToolStripMenuItem.Click += inomedToolStripMenuItem_Click;
            // 
            // oticomToolStripMenuItem1
            // 
            oticomToolStripMenuItem1.Name = "oticomToolStripMenuItem1";
            oticomToolStripMenuItem1.Size = new Size(134, 24);
            oticomToolStripMenuItem1.Text = "Oticom";
            oticomToolStripMenuItem1.Click += oticomToolStripMenuItem1_Click;
            // 
            // movimientoToolStripMenuItem
            // 
            movimientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bernafonToolStripMenuItem1 });
            movimientoToolStripMenuItem.ForeColor = Color.White;
            movimientoToolStripMenuItem.Margin = new Padding(5, 0, 5, 0);
            movimientoToolStripMenuItem.Name = "movimientoToolStripMenuItem";
            movimientoToolStripMenuItem.Size = new Size(97, 23);
            movimientoToolStripMenuItem.Text = "Movimiento";
            // 
            // bernafonToolStripMenuItem1
            // 
            bernafonToolStripMenuItem1.Name = "bernafonToolStripMenuItem1";
            bernafonToolStripMenuItem1.Size = new Size(134, 24);
            bernafonToolStripMenuItem1.Text = "Bernafon";
            bernafonToolStripMenuItem1.Click += bernafonToolStripMenuItem1_Click_1;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.ForeColor = Color.White;
            configuraciónToolStripMenuItem.Margin = new Padding(5, 0, 5, 0);
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(110, 23);
            configuraciónToolStripMenuItem.Text = "Configuración";
            configuraciónToolStripMenuItem.Click += configuraciónToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Margin = new Padding(5, 0, 5, 0);
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(84, 23);
            acercaDeToolStripMenuItem.Text = "Acerca De";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Margin = new Padding(5, 0, 5, 0);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(49, 23);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // FrmHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1207, 615);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FrmHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor Inventario";
            Load += FrmHome_Load;
            Shown += FrmHome_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem ingresoValijasToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem1;
        private ToolStripMenuItem aBToolStripMenuItem1;
        private ToolStripMenuItem bernafonToolStripMenuItem;
        private ToolStripMenuItem atosToolStripMenuItem;
        private ToolStripMenuItem inomedToolStripMenuItem;
        private ToolStripMenuItem atosToolStripMenuItem1;
        private ToolStripMenuItem accesoriosToolStripMenuItem1;
        private ToolStripMenuItem valijasToolStripMenuItem;
        private ToolStripMenuItem oticomToolStripMenuItem;
        private ToolStripMenuItem oticomToolStripMenuItem1;
        private ToolStripMenuItem movimientoToolStripMenuItem;
        private ToolStripMenuItem bernafonToolStripMenuItem1;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}