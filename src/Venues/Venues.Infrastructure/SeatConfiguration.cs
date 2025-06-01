using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;
using Venues.Domain;

namespace Venues.Infrastructure;

public class SeatConfiguration : BaseEntityConfiguration<Seat>
{
    public override void Configure(EntityTypeBuilder<Seat> builder)
    {
        base.Configure(builder);

        builder.Property(seat => seat.Number)
            .IsRequired();

        builder.Property(seat => seat.Row)
            .IsRequired()
            .HasMaxLength(10)
            .HasConversion<string>();

        builder.Property(seat => seat.Type)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(seat => seat.HallId)
            .IsRequired();

        builder.HasIndex(e => e.Type);

        builder.HasIndex(s => new { s.HallId, s.Row, s.Number }).IsUnique();
    }
}