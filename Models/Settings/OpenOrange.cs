using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Settings
{
    public class OpenOrange
    {
        public OpenOrangeStructure ColumnCode { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnUnits { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnSerialNumber { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnDueDate { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnPrice { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnBatch { get; set; } = new OpenOrangeStructure();
        public OpenOrangeStructure ColumnKit { get; set; } = new OpenOrangeStructure();

        public OpenOrange()
        {
            ColumnCode.name = "ArtCode";
            ColumnUnits.name = "Qty";
            ColumnSerialNumber.name = "SerialNr";
            ColumnDueDate.name = "ExpireDate";
            ColumnPrice.name = "Price";
            ColumnBatch.name = "BatchStatus";
            ColumnKit.name = "Kit";
        }

    }

    public class OpenOrangeStructure
    {
        public string name { get; set; }
        public bool isActive { get; set; }

    }
}
