using AutoMapper;
using CargoAPI.DTOs;
using CargoAPI.Entities;
using CargoAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoAPI.Cargo.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IMapper _mapper;  

        public OrderService(IGenericRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        // Get all orders
        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            // AutoMapper ile dönüşüm
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        // Get order by ID
        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);
            if (orderEntity == null)
            {
                throw new Exception($"Order with ID {id} not found.");
            }

            // AutoMapper ile dönüşüm
            return _mapper.Map<OrderDto>(orderEntity);
        }

        // Add new order
        public async Task AddOrderAsync(OrderDto orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto); // AutoMapper ile dönüşüm
            await _orderRepository.AddAsync(orderEntity);
        }

        // Update existing order
        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto); // AutoMapper ile dönüşüm
            await _orderRepository.UpdateAsync(orderEntity);
        }

        // Delete order by ID
        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
