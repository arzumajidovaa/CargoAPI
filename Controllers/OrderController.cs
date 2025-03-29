
using CargoAPI.DTOs;
using CargoAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Cargo.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class OrderController : ControllerBase
        {
            private readonly IOrderService _orderService;
            private readonly ICarrierService _carrierService;
            private readonly ICarrierConfigurationService _carrierConfigurationService;

            public OrderController(IOrderService orderService, ICarrierService carrierService, ICarrierConfigurationService carrierConfigurationService)
            {
                _orderService = orderService;
                _carrierService = carrierService;
                _carrierConfigurationService = carrierConfigurationService;
            }

            [HttpGet]
            public async Task<IActionResult> GetOrders()
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }

            [HttpPost]
            public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
            {
                var configurations = await _carrierConfigurationService.GetAllCarrierConfigurationsAsync();
                var suitableConfig = configurations.FirstOrDefault(c => orderDto.OrderDesi >= c.CarrierMinDesi && orderDto.OrderDesi <= c.CarrierMaxDesi);

                if (suitableConfig != null)
                {
                    orderDto.OrderCarrierCost = suitableConfig.CarrierCost;
                }
                else
                {
                    var closestConfig = configurations.OrderBy(c => Math.Abs(orderDto.OrderDesi - c.CarrierMaxDesi)).FirstOrDefault();
                    if (closestConfig != null)
                    {
                        int extraDesi = orderDto.OrderDesi - closestConfig.CarrierMaxDesi;
                        var carrier = await _carrierService.GetCarrierByIdAsync(closestConfig.CarrierId);
                        orderDto.OrderCarrierCost = closestConfig.CarrierCost + (extraDesi * carrier.CarrierPlusDesiCost);
                    }
                }

                await _orderService.AddOrderAsync(orderDto);
                return Ok("Sipariş eklendi ve kargo maliyeti hesaplandı.");
            }
        }
    }
