using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Settings
{
    public class AccessoriesAB
    {
        public string ColumnCode { get; set; } = "Modelo";
        public string ColumnDueDate { get; set; } = "Vencimiento";
        public string ColumnDescription { get; set; } = "Descripción";
        public string ColumnUnits { get; set; } = "Cantidad";
        public string ColumnSerialNumber { get; set; } = "Lote";
    }
}
