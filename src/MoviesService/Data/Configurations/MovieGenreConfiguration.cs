using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesService.Entities;

namespace MoviesService.Data;

public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasKey(e => new { e.MovieId, e.GenreId });

        builder.HasOne<Movie>()
            .WithMany()
            .HasForeignKey(e => e.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Genre>()
            .WithMany()
            .HasForeignKey(e => e.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}