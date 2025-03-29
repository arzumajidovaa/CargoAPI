using CargoAPI.DTOs;

namespace CargoAPI.Interfaces
{
    public interface ICarrierService
    {
        Task<IEnumerable<CarrierDto>> GetAllCarriersAsync();
        Task<CarrierDto> GetCarrierByIdAsync(int id);
        Task AddCarrierAsync(CarrierDto carrierDto);
        Task UpdateCarrierAsync(CarrierDto carrierDto);
        Task DeleteCarrierAsync(int id);
    }
}
