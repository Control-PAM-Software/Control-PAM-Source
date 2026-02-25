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
            lblVersion.Text = $"Versión: {Application.ProductVersion}";
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
            string myChangeset = "• Corrección de vencimiento al pegar anexo en ingreso Valija.\n\n" +
                                 "• Corrección de nombre de columna al generar tabla Open Orange.\n\n" +
                                 "• Se agrega numeración a las filas de las tablas.";

            rtbChangeset.AppendText(myChangeset);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}