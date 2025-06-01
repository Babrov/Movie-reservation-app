using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesCatalog.Domain;
using Shared.Infrastructure;

namespace MoviesCatalog.Infrastructure;

public class MovieConfiguration : BaseEntityConfiguration<Movie>
{
    public override void Configure(EntityTypeBuilder<Movie> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Title).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Genre).HasMaxLength(50).HasConversion<string>().IsRequired();
        builder.Property(e => e.Duration).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(500).HasDefaultValue(string.Empty);

        builder.HasIndex(e => e.Title);
        builder.HasIndex(e => e.Genre);
    }
}