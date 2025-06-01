using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace Reservations.Infrastructure;

public class ReservationSeatConfiguration : BaseEntityConfiguration<ReservedSeat>
{
    public override void Configure(EntityTypeBuilder<ReservedSeat> builder)
    {
        base.Configure(builder);

        builder.Property(oi => oi.OrderId)
            .IsRequired();

        builder.Property(oi => oi.SessionSeatId)
            .IsRequired();

        builder.Property(oi => oi.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}