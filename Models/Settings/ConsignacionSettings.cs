using System;

namespace Control.Models.Settings
{
    public class ConsignacionSettings
    {
        public string MovColCode { get; set; } = "Artículo";
        public string MovColSerial { get; set; } = "Nro. Serie";
        public string MovColDate { get; set; } = "Fecha";
        public string MovColFrom { get; set; } = "Desde Depósito";
        public string MovColTo { get; set; } = "Hasta Depósito";

        public string StockColCode { get; set; } = "Artículo";
        public string StockColSerial { get; set; } = "Nro. Serie";
        public string StockColDepot { get; set; } = "Depósito de Stock";
        public string StockColQty { get; set; } = "Stock";

        public int PlazoLimite { get; set; } = 30;
    }
}