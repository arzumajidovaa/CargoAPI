using CargoAPI.DTOs;
using CargoAPI.Entities;
using CargoAPI.Interfaces;

namespace CargoAPI.Cargo.Service.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly IGenericRepository<Carrier> _carrierRepository;

        public CarrierService(IGenericRepository<Carrier> carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        // Kargo firmalarını listeleme
        public async Task<IEnumerable<CarrierDto>> GetAllCarriersAsync()
        {
            var carriers = await _carrierRepository.GetAllAsync();
            var carrierDtos = new List<CarrierDto>();

            foreach (var carrier in carriers)
            {
                carrierDtos.Add(new CarrierDto
                {
                    Id = carrier.Id,
                    CarrierName = carrier.CarrierName,
                    CarrierIsActive = carrier.CarrierIsActive,
                    CarrierPlusDesiCost = carrier.CarrierPlusDesiCost
                });
            }

            return carrierDtos;
        }

        // Kargo firması ekleme
        public async Task AddCarrierAsync(CarrierDto carrierDto)
        {
            var carrier = new Carrier
            {
                CarrierName = carrierDto.CarrierName,
                CarrierIsActive = carrierDto.CarrierIsActive,
                CarrierPlusDesiCost = carrierDto.CarrierPlusDesiCost
            };

            await _carrierRepository.AddAsync(carrier);
        }

        // Kargo firması güncelleme
        public async Task UpdateCarrierAsync(CarrierDto carrierDto)
        {
            var carrier = await _carrierRepository.GetByIdAsync(carrierDto.Id);

            if (carrier != null)
            {
                carrier.CarrierName = carrierDto.CarrierName;
                carrier.CarrierIsActive = carrierDto.CarrierIsActive;
                carrier.CarrierPlusDesiCost = carrierDto.CarrierPlusDesiCost;

                await _carrierRepository.UpdateAsync(carrier);
            }
        }

        // Kargo firması silme
        public async Task DeleteCarrierAsync(int id)
        {
            await _carrierRepository.DeleteAsync(id);
        }

        // Kargo firması ID ile getirme
        public async Task<CarrierDto> GetCarrierByIdAsync(int id)
        {
            var carrier = await _carrierRepository.GetByIdAsync(id);

            if (carrier == null)
                return null;

            return new CarrierDto
            {
                Id = carrier.Id,
                CarrierName = carrier.CarrierName,
                CarrierIsActive = carrier.CarrierIsActive,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost
            };
        }
    }
}
