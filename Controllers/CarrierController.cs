
using CargoAPI.DTOs;
using CargoAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarriers()
        {
            var carriers = await _carrierService.GetAllCarriersAsync();
            return Ok(carriers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrier([FromBody] CarrierDto carrierDto)
        {
            await _carrierService.AddCarrierAsync(carrierDto);
            return Ok("Kargo firması eklendi.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrier(int id, [FromBody] CarrierDto carrierDto)
        {
            if (id != carrierDto.Id)
            {
                return BadRequest("Kargo firması ID'leri eşleşmiyor.");
            }

            await _carrierService.UpdateCarrierAsync(carrierDto);
            return Ok("Kargo firması güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            await _carrierService.DeleteCarrierAsync(id);
            return Ok($"Kargo firması {id} ID'li kayıt silindi.");
        }
    }
}
