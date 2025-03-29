namespace CargoAPI.DTOs
{
    public class CarrierDto
    {
        public int Id { get; set; }
        public string CarrierName { get; set; } = string.Empty;
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}
