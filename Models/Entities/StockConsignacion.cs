namespace Control.Models.Entities
{
    public class StockConsignacion
    {
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public string Serial { get; set; } = "";
        public string Depto { get; set; } = "";
        public int Qty { get; set; }
    }
}