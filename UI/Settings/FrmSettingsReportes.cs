using Control.Logic;
using Control.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmSettingsReportes : Form
    {
        public string movCode => txtMovCode.Text;
        public string movSerial => txtMovSerial.Text;
        public string movDate => txtMovDate.Text;
        public string movFrom => txtMovFrom.Text;
        public string movTo => txtMovTo.Text;

        public string stockCode => txtStockCode.Text;
        public string stockSerial => txtStockSerial.Text;
        public string stockDepot => txtStockDepot.Text;
        public string stockQty => txtStockQty.Text;

        public int plazoLimite => (int)numPlazoLimite.Value;

        public FrmSettingsReportes()
        {
            InitializeComponent();
        }

        private void FrmSettingsReportes_Load(object sender, EventArgs e)
        {
            try
            {
                ConsignacionSettings s = AppSettings.settings.ConsignacionReporte;

                txtMovCode.Text = s.MovColCode;
                txtMovSerial.Text = s.MovColSerial;
                txtMovDate.Text = s.MovColDate;
                txtMovFrom.Text = s.MovColFrom;
                txtMovTo.Text = s.MovColTo;

                txtStockCode.Text = s.StockColCode;
                txtStockSerial.Text = s.StockColSerial;
                txtStockDepot.Text = s.StockColDepot;
                txtStockQty.Text = s.StockColQty;

                numPlazoLimite.Value = s.PlazoLimite;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las configuraciones de reportes: {ex}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            try
            {
                CargarDescripciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las descripciones de artículos: {ex.Message}", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDescripcionesPath()
        {
            string localAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Control");
            string userPath = Path.Combine(localAppData, "articulos_descripcion.json");
            if (File.Exists(userPath))
            {
                return userPath;
            }

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string controlDbPath = Path.Combine(baseDir, "ControlDb", "articulos_descripcion.json");
            if (File.Exists(controlDbPath))
            {
                return controlDbPath;
            }

            string devPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "ControlDb", "articulos_descripcion.json"));
            if (File.Exists(devPath))
            {
                return devPath;
            }

            return userPath;
        }

        private void CargarDescripciones()
        {
            gdvDescripciones.Rows.Clear();
            string path = GetDescripcionesPath();
            if (!File.Exists(path))
            {
                return;
            }

            string json = File.ReadAllText(path);
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            if (dict == null)
            {
                return;
            }

            foreach (var kv in dict.OrderBy(x => x.Key))
            {
                gdvDescripciones.Rows.Add(kv.Key, kv.Value);
            }
        }

        private void GuardarDescripciones()
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataGridViewRow row in gdvDescripciones.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                string codigo = row.Cells["colCodigoDesc"].Value?.ToString()?.Trim() ?? string.Empty;
                string descripcion = row.Cells["colDescripcion"].Value?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    continue;
                }
                dict[codigo] = descripcion.Trim();
            }

            string path = GetDescripcionesPath();
            string dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            File.WriteAllText(path, json);
            ArticuloDescripcionCatalogo.InvalidarCache();
        }

        public void GuardarCambios()
        {
            GuardarDescripciones();
        }

        private void gdvDescripciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow row in gdvDescripciones.SelectedRows.Cast<DataGridViewRow>().ToList())
                {
                    if (!row.IsNewRow)
                    {
                        gdvDescripciones.Rows.Remove(row);
                    }
                }
                if (gdvDescripciones.SelectedRows.Count == 0 && gdvDescripciones.CurrentRow != null && !gdvDescripciones.CurrentRow.IsNewRow)
                {
                    gdvDescripciones.Rows.Remove(gdvDescripciones.CurrentRow);
                }
                e.Handled = true;
            }
        }

        private void btnImportDescripciones_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos JSON (*.json)|*.json|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                    openFileDialog.Title = "Seleccionar archivo de descripciones";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    string content = File.ReadAllText(openFileDialog.FileName);
                    Dictionary<string, string>? dict = null;
                    if (openFileDialog.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        dict = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
                    }
                    else
                    {
                        dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        foreach (string line in content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            int sep = line.IndexOf(';');
                            if (sep < 0) sep = line.IndexOf('\t');
                            if (sep < 0) continue;
                            string codigo = line.Substring(0, sep).Trim();
                            string descripcion = line.Substring(sep + 1).Trim();
                            if (!string.IsNullOrWhiteSpace(codigo))
                            {
                                dict[codigo] = descripcion;
                            }
                        }
                    }

                    if (dict == null)
                    {
                        MessageBox.Show("No se pudo leer el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (var kv in dict)
                    {
                        bool exists = false;
                        foreach (DataGridViewRow row in gdvDescripciones.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (string.Equals(row.Cells["colCodigoDesc"].Value?.ToString(), kv.Key, StringComparison.OrdinalIgnoreCase))
                            {
                                row.Cells["colDescripcion"].Value = kv.Value;
                                exists = true;
                                break;
                            }
                        }
                        if (!exists && !string.IsNullOrWhiteSpace(kv.Key))
                        {
                            gdvDescripciones.Rows.Add(kv.Key, kv.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar descripciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportDescripciones_Click(object sender, EventArgs e)
        {
            try
            {
                var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataGridViewRow row in gdvDescripciones.Rows)
                {
                    if (row.IsNewRow) continue;
                    string codigo = row.Cells["colCodigoDesc"].Value?.ToString()?.Trim() ?? string.Empty;
                    string descripcion = row.Cells["colDescripcion"].Value?.ToString() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(codigo)) continue;
                    dict[codigo] = descripcion.Trim();
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos JSON (*.json)|*.json|Archivos de texto (*.txt)|*.txt";
                    saveFileDialog.Title = "Guardar descripciones";
                    saveFileDialog.FileName = "articulos_descripcion.json";
                    if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                    if (saveFileDialog.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        string json = JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                        File.WriteAllText(saveFileDialog.FileName, json);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var kv in dict.OrderBy(x => x.Key))
                        {
                            sb.AppendLine(kv.Key + ";" + kv.Value);
                        }
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar descripciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewDescripciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Functions.EnumerarFilasDataGrid(sender, e);
        }
    }
}