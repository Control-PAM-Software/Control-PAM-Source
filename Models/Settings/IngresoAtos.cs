using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Settings
{
    public class IngresoAtos
    {
        public string ColumnCode { get; set; } = "Artículo";
        public string ColumnUnits { get; set; } = "Stock";
        public string ColumnDescription { get; set; } = "Descripción";
        public string ColumnSerialNumber { get; set; } = "Nro Serie";
        public string ColumnDueDate { get; set; } = "Fecha Vto.";
    }
}
