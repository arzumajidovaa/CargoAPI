namespace CargoAPI.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public int CarrierId { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderCarrierCost { get; set; }
}