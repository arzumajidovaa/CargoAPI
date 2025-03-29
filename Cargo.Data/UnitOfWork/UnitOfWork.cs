using CargoAPI.Interfaces;  // Doğru namespace
using CargoAPI.Cargo.Data.Repositories;
using CargoAPI.Entities;
using System.Threading.Tasks;

namespace CargoAPI.Cargo.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CargoDbContext _context;

        public UnitOfWork(CargoDbContext context)
        {
            _context = context;
            Orders = new GenericRepository<Order>(_context);
            Carriers = new GenericRepository<Carrier>(_context);
            CarrierConfigurations = new GenericRepository<CarrierConfiguration>(_context);
        }

        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<Carrier> Carriers { get; }
        public IGenericRepository<CarrierConfiguration> CarrierConfigurations { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
