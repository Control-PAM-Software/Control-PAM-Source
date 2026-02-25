using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models
{
    public class VersionInfo
    {
        public string version { get; set; }
        public string installer { get; set; }
        public bool mandatory { get; set; }
        public string notes { get; set; }       
    }
}
