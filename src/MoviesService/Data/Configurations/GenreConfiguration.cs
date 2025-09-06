using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesService.Entities;
using Shared.Infrastructure;

namespace MoviesService.Data;

public class GenreConfiguration : BaseEntityConfiguration<Genre>
{
    public override void Configure(EntityTypeBuilder<Genre> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();

        builder.HasIndex(e => e.Name).IsUnique();
    }
}