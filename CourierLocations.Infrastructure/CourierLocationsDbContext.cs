using CourierLocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierLocations.Infrastructure;

public sealed class CourierLocationsDbContext(DbContextOptions<CourierLocationsDbContext> options) 
    : DbContext(options) 
{
    public DbSet<Location> Locations { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
