using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        IMutableNavigation? navigation = builder.Metadata.FindNavigation(nameof(Order.Items));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(order => order.Status)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(order => order.UserId)
            .IsRequired();

        builder.HasIndex(e => e.Status);

        builder
            .HasMany(order => order.Items)
            .WithOne()
            .HasForeignKey(e => e.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(e => e.Payment)
            .WithOne()
            .HasForeignKey<Payment>(e => e.OrderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}