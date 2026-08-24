using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Settings
{
    public class Etiquetas
    {
        public OpenOrangeStructure ColumnCode { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnSerialNumber { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnUnits { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnDespacho { get; set; } = new OpenOrangeStructure();

        /// <summary>
        /// Carpeta donde se exporta el Excel. Si está vacía se muestra el diálogo de guardado.
        /// </summary>
        public string ExportPath { get; set; } = "";

        /// <summary>
        /// Nombre del archivo exportado. Se usa exactamente como se configura (más la extensión .xlsx),
        /// ya que es consumido por otro sistema.
        /// </summary>
        public string FileName { get; set; } = "Etiquetas";

        public Etiquetas()
        {
            ColumnCode.name = "Código";
            ColumnCode.isActive = true;

            ColumnSerialNumber.name = "Serie";
            ColumnSerialNumber.isActive = true;

            ColumnUnits.name = "Cantidad";
            ColumnUnits.isActive = true;

            ColumnDespacho.name = "Despacho";
            ColumnDespacho.isActive = true;
        }
    }
}
