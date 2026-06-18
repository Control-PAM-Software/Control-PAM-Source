
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Update
{
    /// <summary>
    /// Clase utilizada para actualizaciones automáticas
    /// Misma estructura que archivo version.json del repositorio de distribución
    /// </summary>
    public class UpdateInfo
    {
        public string version { get; set; } = string.Empty;
        public string release_date { get; set; } = string.Empty;
        public string url_download { get; set; } = string.Empty;
        public bool mandatory { get; set; } = false;
        public List<string> changelog { get; set; } = new();
        public string checksum { get; set; } = string.Empty;
    }
}
