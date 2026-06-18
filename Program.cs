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
    }
}