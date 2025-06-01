using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain;

namespace MoviesCatalog.Infrastructure;

public class MovieCatalogDbContext : DbContext
{
    public MovieCatalogDbContext(DbContextOptions<MovieCatalogDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}