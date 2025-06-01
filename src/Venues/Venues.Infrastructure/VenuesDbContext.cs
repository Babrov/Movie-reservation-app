using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Venues.Domain;

namespace Venues.Infrastructure;

public class VenuesDbContext : DbContext
{
    public VenuesDbContext(DbContextOptions<VenuesDbContext> options) : base(options)
    {
    }

    public DbSet<Venue> Halls { get; set; }
    public DbSet<Seat> Seats { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}