using CargoAPI.Interfaces;
using CargoAPI.Entities;
using System.Threading.Tasks;

namespace CargoAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Carrier> Carriers { get; }
        IGenericRepository<CarrierConfiguration> CarrierConfigurations { get; }
        Task<int> CompleteAsync();
    }
}
