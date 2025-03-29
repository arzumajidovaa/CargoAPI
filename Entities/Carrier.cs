namespace CargoAPI.Entities
{
    public class Carrier : BaseEntity
    {
        public string CarrierName { get; set; } = string.Empty;
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public ICollection<CarrierConfiguration> CarrierConfigurations { get; set; } = new List<CarrierConfiguration>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}