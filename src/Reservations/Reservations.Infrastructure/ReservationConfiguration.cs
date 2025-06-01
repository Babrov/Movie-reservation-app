using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservations.Domain;
using Shared.Infrastructure;

namespace Reservations.Infrastructure;

public class ReservationConfiguration : BaseEntityConfiguration<Reservation>
{
    public override void Configure(EntityTypeBuilder<Reservation> builder)
    {
        base.Configure(builder);

        IMutableNavigation? navigation = builder.Metadata.FindNavigation(nameof(Reservation.Seats));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(order => order.Status)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(order => order.UserId)
            .IsRequired();

        builder.HasIndex(e => e.Status);

        builder
            .HasMany(order => order.Seats)
            .WithOne()
            .HasForeignKey(e => e.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}