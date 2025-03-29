using CargoAPI.DTOs;
using CargoAPI.Entities;
using CargoAPI.Interfaces;

namespace CargoAPI.Cargo.Service.Services
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly IGenericRepository<CarrierConfiguration> _carrierConfigRepository;

        public CarrierConfigurationService(IGenericRepository<CarrierConfiguration> carrierConfigRepository)
        {
            _carrierConfigRepository = carrierConfigRepository;
        }

        // Kargo firması konfigürasyonlarını listeleme
        public async Task<IEnumerable<CarrierConfigurationDto>> GetAllCarrierConfigurationsAsync()
        {
            var carrierConfigs = await _carrierConfigRepository.GetAllAsync();
            var carrierConfigDtos = new List<CarrierConfigurationDto>();

            foreach (var config in carrierConfigs)
            {
                carrierConfigDtos.Add(new CarrierConfigurationDto
                {
                    Id = config.Id,
                    CarrierId = config.CarrierId,
                    CarrierMaxDesi = config.CarrierMaxDesi,
                    CarrierMinDesi = config.CarrierMinDesi,
                    CarrierCost = config.CarrierCost
                });
            }

            return carrierConfigDtos;
        }

        // Kargo firması konfigürasyonu ekleme
        public async Task AddCarrierConfigurationAsync(CarrierConfigurationDto carrierConfigurationDto)
        {
            var carrierConfiguration = new CarrierConfiguration
            {
                CarrierId = carrierConfigurationDto.CarrierId,
                CarrierMaxDesi = carrierConfigurationDto.CarrierMaxDesi,
                CarrierMinDesi = carrierConfigurationDto.CarrierMinDesi,
                CarrierCost = carrierConfigurationDto.CarrierCost
            };

            await _carrierConfigRepository.AddAsync(carrierConfiguration);
        }

        // Kargo firması konfigürasyonu güncelleme
        public async Task UpdateCarrierConfigurationAsync(CarrierConfigurationDto carrierConfigurationDto)
        {
            var carrierConfiguration = await _carrierConfigRepository.GetByIdAsync(carrierConfigurationDto.Id);

            if (carrierConfiguration != null)
            {
                carrierConfiguration.CarrierMaxDesi = carrierConfigurationDto.CarrierMaxDesi;
                carrierConfiguration.CarrierMinDesi = carrierConfigurationDto.CarrierMinDesi;
                carrierConfiguration.CarrierCost = carrierConfigurationDto.CarrierCost;

                await _carrierConfigRepository.UpdateAsync(carrierConfiguration);
            }
        }

        // Kargo firması konfigürasyonu silme
        public async Task DeleteCarrierConfigurationAsync(int id)
        {
            await _carrierConfigRepository.DeleteAsync(id);
        }

        // Kargo firması konfigürasyonunu ID ile getirme
        public async Task<CarrierConfigurationDto> GetCarrierConfigurationByIdAsync(int id)
        {
            var carrierConfig = await _carrierConfigRepository.GetByIdAsync(id);

            if (carrierConfig == null)
                return null;

            return new CarrierConfigurationDto
            {
                Id = carrierConfig.Id,
                CarrierId = carrierConfig.CarrierId,
                CarrierMaxDesi = carrierConfig.CarrierMaxDesi,
                CarrierMinDesi = carrierConfig.CarrierMinDesi,
                CarrierCost = carrierConfig.CarrierCost
            };
        }

    }
}
