using CargoAPI.DTOs;

namespace CargoAPI.Interfaces
{
    public interface ICarrierConfigurationService
    {
        Task<IEnumerable<CarrierConfigurationDto>> GetAllCarrierConfigurationsAsync();
        Task<CarrierConfigurationDto> GetCarrierConfigurationByIdAsync(int id);
        Task AddCarrierConfigurationAsync(CarrierConfigurationDto carrierConfigurationDto);
        Task UpdateCarrierConfigurationAsync(CarrierConfigurationDto carrierConfigurationDto);
        Task DeleteCarrierConfigurationAsync(int id);
    }
}
