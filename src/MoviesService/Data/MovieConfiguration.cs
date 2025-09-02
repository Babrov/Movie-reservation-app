using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesService.Entities;
using Shared.Infrastructure;

namespace MoviesService.Data;

public class MovieConfiguration : BaseEntityConfiguration<Movie>
{
    public override void Configure(EntityTypeBuilder<Movie> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Title).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Slug).HasMaxLength(255).HasDefaultValue(string.Empty);
        builder.Property(e => e.Description).HasMaxLength(512).HasDefaultValue(string.Empty);
        builder.Property(e => e.ReleaseYear).IsRequired();
        builder.Property(e => e.RuntimeMinutes).IsRequired();

        builder.HasIndex(e => e.Title).IsUnique();
        builder.HasIndex(e => e.Slug).IsUnique();
    }
}