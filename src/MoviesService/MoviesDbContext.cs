using Microsoft.EntityFrameworkCore;
using MoviesService.Entities;

namespace MoviesService;

public class MoviesDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
}