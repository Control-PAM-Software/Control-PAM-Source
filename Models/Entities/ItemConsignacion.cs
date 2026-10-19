namespace Control.Models.Entities
{
    public class ItemConsignacion
    {
        public string Serial { get; set; } = "";
        public string Code { get; set; } = "";
        public string CurrentDepot { get; set; } = "";
        public string DepartureDate { get; set; } = "";
        public int DaysElapsed { get; set; } = 0;
        public bool Delivered { get; set; } = false;
        public bool SerieSinMovimiento { get; set; } = false;
        public ConsignacionEstado State { get; set; } = ConsignacionEstado.EnPlazo;
    }
}