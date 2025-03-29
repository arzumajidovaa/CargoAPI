using CargoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CargoAPI.Cargo.Data

{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext(DbContextOptions<CargoDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Carrier)
                .WithMany()
                .HasForeignKey(o => o.CarrierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
