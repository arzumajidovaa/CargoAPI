using CargoAPI.Entities;
using CargoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CargoAPI.Cargo.Data.Repositories
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly CargoDbContext _dbContext;

        public OrderRepository(CargoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all orders
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        // Get order by ID
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        // Add new order
        public async Task AddAsync(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Update existing order
        public async Task UpdateAsync(Order entity)
        {
            _dbContext.Orders.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete order by ID
        public async Task DeleteAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
