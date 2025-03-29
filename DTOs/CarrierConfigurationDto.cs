namespace CargoAPI.DTOs
{
    public class CarrierConfigurationDto
    {
        public int Id { get; set; }
        public int CarrierId { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }

}
