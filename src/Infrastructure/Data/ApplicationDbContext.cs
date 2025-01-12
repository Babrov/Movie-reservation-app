using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Hall> Halls { get; set; }
    public DbSet<Seat> Seats { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<PricingRule> PricingRules { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionSeat> SessionSeats { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}