using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;
using Venues.Domain;

namespace Venues.Infrastructure;

public class VenueConfiguration : BaseEntityConfiguration<Venue>
{
    public override void Configure(EntityTypeBuilder<Venue> builder)
    {
        base.Configure(builder);

        IMutableNavigation? navigation = builder.Metadata.FindNavigation(nameof(Venue.Seats));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(hall => hall.Type)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.HasIndex(e => e.Type);

        builder
            .HasMany(hall => hall.Seats)
            .WithOne()
            .HasForeignKey(e => e.HallId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}