using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Control.Models.Settings
{
    public static class AppSettings
    {
        public static SettingsModel settings { get; set; }

        public static void saveSettings()
        {
            string path = Path.Combine(Application.StartupPath, "Settings", "SettingSys.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(SettingsModel));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, settings);
            }
        }
    }
}
