using System.Reflection;

namespace Control
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            LoadAppInfo();
        }

        private void LoadAppInfo()
        {
            // --- INFORMACIÓN AUTOMÁTICA ---
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;
            lblVersion.Text = $"Versión: v{version.Major}.{version.Minor}.{version.Build}";
            lblCopyright.Text = $"© {DateTime.Now.Year} - Agustín Malfatto";

            // --- NOMBRE DE LA APP ---
            lblAppName.Text = "Gestor\nInventario\nPAM";

            // --- REGISTRO DE CAMBIOS (RichTextBox) ---
            rtbChangeset.Clear();

            // Título en Negrita
            rtbChangeset.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            rtbChangeset.AppendText("Registro de Cambios:\n\n");

            // Contenido normal con viñetas
            rtbChangeset.SelectionFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            string myChangeset = "• Se agregó botón para insertar LP a los códigos de Accesorios AB.\n\n" +
                                 "• Se modificó la exportación a Excel, cambiando los encabezados de mayúsculas a minúsculas.\n\n";

            rtbChangeset.AppendText(myChangeset);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}