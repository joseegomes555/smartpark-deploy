using Microsoft.EntityFrameworkCore;
using SmartPark.Data.Entities;

namespace SmartPark.Data;

public class SmartParkDbContext : DbContext
{
    public SmartParkDbContext(DbContextOptions<SmartParkDbContext> options) : base(options) { }

    public DbSet<ParkingLot> ParkingLots => Set<ParkingLot>();
    public DbSet<Spot> Spots => Set<Spot>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingLot>()
            .HasMany(p => p.Spots)
            .WithOne(s => s.ParkingLot!)
            .HasForeignKey(s => s.ParkingLotId);

        modelBuilder.Entity<ParkingLot>().HasData(
            new ParkingLot { ParkingLotId = 1, Name = "Campus - Parque A", Address = "IPCA", Capacity = 50 }
        );

        modelBuilder.Entity<Spot>().HasData(
            new Spot { SpotId = 1, ParkingLotId = 1, Code = "A-01", Status = "free" },
            new Spot { SpotId = 2, ParkingLotId = 1, Code = "A-02", Status = "occupied" }
        );
    }
}
