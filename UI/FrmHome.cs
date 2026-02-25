using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;

namespace Control
{
    public partial class FrmHome : Form
    {
        private readonly Dictionary<Type, Form> _openForms = new();
        private Form? activeForm;

        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;

            this.Text = $"Control PAM - v{version.Major}.{version.Minor}.{version.Build}";

            //Form newForm = (Form)Activator.CreateInstance(typeof(FrmRegistrationAB))!;
            //_openForms[typeof(FrmRegistrationAB)] = newForm;
            //ShowForm(newForm);

            //if (activeForm == null)
            //    showPanel(new FrmRegistrationAB());


            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            // Buscamos el control MdiClient entre los controles del formulario
            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    // 1. Cambiar el color a blanco (o el que prefieras)
                    mdiClient.BackColor = Color.White;

                    // Aplicar el DoubleBuffer al contenedor MDI
                    SetDoubleBuffered(mdiClient);

                    // 2. O poner la imagen que generamos antes
                    // mdiClient.BackgroundImage = Properties.Resources.TuImagenGenerada;
                    // mdiClient.BackgroundImageLayout = ImageLayout.Center;
                    mdiClient.Resize += (s, ev) => { mdiClient.Refresh(); };
                    break;
                }
            }

            // Aplicamos el render personalizado al menuStrip
            menuStrip1.Renderer = new MyCustomRenderer();

            // Opcional: Aseguramos que los subítems tengan texto blanco y fondo oscuro
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                AplicarEstiloMenu(item);
            }

        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession) return;

            System.Reflection.PropertyInfo? prop = typeof(System.Windows.Forms.Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            prop?.SetValue(c, true, null);
        }

        private void ShowForm(Type formType)
        {
            if (!typeof(Form).IsAssignableFrom(formType))
                throw new ArgumentException("El tipo debe heredar de Form");

            // Buscar formularios MDI hijos ya abiertos
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild.GetType() == formType)
                {
                    // Si está minimizado, lo devolvemos a normal antes de activarlo
                    if (frmChild.WindowState == FormWindowState.Minimized)
                        frmChild.WindowState = FormWindowState.Normal;

                    frmChild.BringToFront();
                    frmChild.Activate();
                    return;
                }
            }

            Form frm = (Form)Activator.CreateInstance(formType)!;
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        // Esta es la función mágica que recorre todos los niveles
        private void AplicarEstiloMenu(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            item.BackColor = Color.FromArgb(45, 45, 48);

            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem menuCombo)
                {
                    // Si el subItem es a su vez un menú, llamamos de nuevo a la función
                    AplicarEstiloMenu(menuCombo);
                }
            }
        }


        private void OpenIndependentForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void ShowPanelIfNotActive(Type formType)
        {
            ShowForm(formType);
            return;
            if (activeForm == null || activeForm.GetType() != formType)
            {
                try
                {
                    Form frm = (Form)Activator.CreateInstance(formType);
                    showPanel(frm);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void showPanel(Form childForm)
        {
            //if (activeForm != null)
            //    activeForm.Close();

            //activeForm = childForm;
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //panelContainer.Controls.Add(childForm);
            //panelContainer.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();
        }


        //private void ShowPanelIfNotActive(Type formType)
        //{
        //    if (_openForms.TryGetValue(formType, out Form existingForm))
        //    {
        //        ShowForm(existingForm);
        //        return;
        //    }

        //    Form newForm = (Form)Activator.CreateInstance(formType)!;
        //    _openForms[formType] = newForm;
        //    ShowForm(newForm);
        //}


        //private void ShowForm(Form childForm)
        //{
        //    if (activeForm != null)
        //        activeForm.Hide();   // 👈 NO Close()

        //    activeForm = childForm;

        //    if (!panelContainer.Controls.Contains(childForm))
        //    {
        //        childForm.TopLevel = false;
        //        childForm.FormBorderStyle = FormBorderStyle.None;
        //        childForm.Dock = DockStyle.Fill;
        //        panelContainer.Controls.Add(childForm);
        //    }

        //    childForm.BringToFront();
        //    childForm.Show();
        //}

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmSettings));
        }


        private void aBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmInventoryAB));
        }

        private void bernafonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmInventoryBernafon));
        }

        private void atosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmInventoryAtos));
        }

        private void inomedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmInventoryInomed));
        }

        private void valijasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmRegistrationAB));
        }

        private void accesoriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmRegistrationABAccesories));
        }

        private void atosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmRegistrationAtos));
        }

        private void bernafonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad en Desarrollo.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            ShowPanelIfNotActive(typeof(FrmRegistrationBernafon));
        }

        private void inomedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmRegistrationInomed));
        }

        private void oticomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmRegistrationOticom));
        }

        private void oticomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmInventoryOticom));
        }

        private void bernafonToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmMovementsBernafon));
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelIfNotActive(typeof(FrmAbout));
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }

    public class MyCustomRenderer : ToolStripProfessionalRenderer
    {
        public MyCustomRenderer() : base(new MyColorTable()) { }
    }

    public class MyColorTable : ProfessionalColorTable
    {
        // Color de fondo cuando el mouse está encima
        public override Color MenuItemSelected => Color.FromArgb(63, 63, 65);

        // Color del borde cuando el mouse está encima (lo hacemos igual al fondo para que no se vea borde)
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(63, 63, 65);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(63, 63, 65);

        // Color cuando el menú está desplegado (Pressed)
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(45, 45, 48);

        // Color del borde alrededor del menú desplegado
        public override Color MenuBorder => Color.FromArgb(60, 60, 60);

        // Color de la franja lateral de los submenús
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);

        // Color de fondo de la columna desplegable(donde están los subítems)
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);

    }

}
