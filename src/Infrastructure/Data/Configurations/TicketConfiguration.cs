namespace Infrastructure.Data.Configurations;

public class TicketConfiguration : BaseEntityConfiguration<Ticket>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);

        builder.Property(ticket => ticket.Status)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(ticket => ticket.OrderItemId)
            .IsRequired();

        builder.Property(bi => bi.Code)
            .IsRequired();
    }
}