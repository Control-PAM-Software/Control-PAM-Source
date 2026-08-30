using Control.Models.Update;
using System.Reflection;

namespace Control
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            LoadAppInfo();
            _ = LoadChangesetAsync();
        }

        private void LoadAppInfo()
        {
            // --- INFORMACIÓN AUTOMÁTICA ---
            Version version = Assembly.GetExecutingAssembly().GetName().Version!;
            lblVersionValue.Text = $"v{version.Major}.{version.Minor}.{version.Build}";
            lblCopyright.Text = $"© {DateTime.Now.Year} — Agustín Malfatto";

            // --- NOMBRE DE LA APP E ÍCONO ---
            lblAppName.Text = "Gestor\nInventario\nPAM";
            picLogo.Image = Properties.Resources.Information;

            // El foco queda en el botón para que no aparezca el cursor en el listado
            ActiveControl = btnOk;

            // --- REGISTRO DE CAMBIOS: estado inicial ---
            rtbChangeset.Clear();
            rtbChangeset.AppendText("Cargando cambios…\n");
            lblChangesetVersion.Text = "…";
        }

        private async Task LoadChangesetAsync()
        {
            UpdateManager updater = new UpdateManager();
            var info = await updater.GetChangesetAsync();

            rtbChangeset.Clear();

            if (info == null)
            {
                lblChangesetVersion.Text = "Sin conexión";
                rtbChangeset.AppendText("Sin conexión y sin historial local disponible.\n");
                return;
            }

            lblChangesetVersion.Text = $"v{info.version}";
            if (!string.IsNullOrWhiteSpace(info.release_date))
            {
                lblChangesetVersion.Text += $"   •   {info.release_date}";
            }

            if (info.changelog != null && info.changelog.Count > 0)
            {
                rtbChangeset.SelectionBullet = false;
                rtbChangeset.SelectionIndent = 0;
                rtbChangeset.SelectionHangingIndent = 16;

                for (int i = 0; i < info.changelog.Count; i++)
                {
                    rtbChangeset.AppendText("•  " + info.changelog[i]);
                    rtbChangeset.AppendText(i < info.changelog.Count - 1 ? "\r\n\r\n" : "\r\n");
                }

                rtbChangeset.SelectionHangingIndent = 0;
            }
            else
            {
                rtbChangeset.SelectionBullet = false;
                rtbChangeset.AppendText("No hay ChangeLog cargado para esta versión.\n");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}