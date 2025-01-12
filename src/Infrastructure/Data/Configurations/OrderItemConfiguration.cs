namespace Infrastructure.Data.Configurations;

public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
{
    public override void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        base.Configure(builder);

        builder.Property(oi => oi.OrderId)
            .IsRequired();

        builder.Property(oi => oi.SessionSeatId)
            .IsRequired();

        builder.Property(oi => oi.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .HasOne(e => e.Ticket)
            .WithOne()
            .HasForeignKey<Ticket>(e => e.OrderItemId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}