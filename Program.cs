using Control.Models.Settings;
using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.DataSourceVersioning;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;

namespace Control
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppSettings.settings = LoadSettings();

            AppSettings.saveSettings();

            CheckForUpdates();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmHome());
        }

        /// <summary>
        /// Consulta el archivo SettingsSys en la carpeta Settings.
        /// </summary>
        /// <returns>Archivo SettingsSys deserializado en clase SettingsModel</returns>
        static SettingsModel LoadSettings()
        {
            string path = Path.Combine(Application.StartupPath, "Settings", "SettingSys.xml");

            if (!File.Exists(path))
            {
                MessageBox.Show("No se encontró el archivo de configuración.");
                return new SettingsModel(); // Devuelve valores por defecto
            }

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            if(serializer != null)
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        return (SettingsModel)serializer.Deserialize(fs);

                    }
                    catch (Exception)
                    {
                        return new SettingsModel();
                    }
                }
            }

            return new SettingsModel();
        }

        /// <summary>
        /// Comapara versión del Assemby vs versión indicada en archivo Update/version.json
        /// </summary>
        static void CheckForUpdates()
        {            
            string updatesPath = Path.Combine(Application.StartupPath, "Update");

            string versionFile = Path.Combine(updatesPath, "version.json");

            if (!File.Exists(versionFile))
                return;

            var json = File.ReadAllText(versionFile);
            var remote = JsonConvert.DeserializeObject<Models.VersionInfo>(json);

            System.Version remoteVersion = new System.Version(remote.version);
            System.Version localVersion = Assembly.GetExecutingAssembly().GetName().Version;

            if (remoteVersion > localVersion)
            {
                ShowUpdateDialog(remote, updatesPath);
            }
        }

        /// <summary>
        /// Ejecuta el instalador indicado en Update/version.json
        /// </summary>
        /// <param name="info">Objeto VersionInfo - deserializado del archivo Update/version.json</param>
        /// <param name="basePath">Path de la carpeta Update</param>
        static void ShowUpdateDialog(Models.VersionInfo info, string basePath)
        {
            var msg = $"Hay una nueva versión disponible: {info.version}\n{info.notes}\n¿Desea actualizar ahora?";

            if (info.mandatory || MessageBox.Show(msg, "Actualización", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string installerPath = Path.Combine(basePath, info.installer);

                if (!File.Exists(installerPath))
                {
                    MessageBox.Show("El archivo de actualización no se encontró. Se cancelará el proceso y se iniciará la versión actual.", "Error de Rollback", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Aquí haces el rollback lógico: no cierras la app y sigue al Main
                }

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = installerPath,
                        UseShellExecute = true
                    });
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo iniciar el instalador: {ex.Message}. Volviendo a la aplicación...");
                    // No llamamos a Exit, permitiendo que la app continúe
                }
            }
        }
    }
}