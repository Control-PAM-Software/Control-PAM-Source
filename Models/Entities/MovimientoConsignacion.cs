using System;

namespace Control.Models.Entities
{
    public class MovimientoConsignacion
    {
        public string Serial { get; set; } = "";
        public string Code { get; set; } = "";
        public DateTime? Date { get; set; } = null;
        public string FromDepto { get; set; } = "";
        public string ToDepto { get; set; } = "";
    }
}