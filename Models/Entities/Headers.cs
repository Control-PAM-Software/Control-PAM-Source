using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Models.Entities
{
    public class Headers
    {
        public HeaderStructure ArtCode { get; set; } = new HeaderStructure("ArtCode");
        public HeaderStructure Qty { get; set; } = new HeaderStructure("Quantity");
        public HeaderStructure Description { get; set; } = new HeaderStructure("Description");
        public HeaderStructure SerialNr { get; set; } = new HeaderStructure("SerialNr");
        public HeaderStructure DueDate { get; set; } = new HeaderStructure("DueDate");
    }

    public class HeaderStructure
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public HeaderStructure(string name)
        {
            Name = name;
            Position = 0;
        }
    }
}
