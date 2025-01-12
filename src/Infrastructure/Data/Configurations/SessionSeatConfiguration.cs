namespace Infrastructure.Data.Configurations;

public class SessionSeatConfiguration : BaseEntityConfiguration<SessionSeat>
{
    public override void Configure(EntityTypeBuilder<SessionSeat> builder)
    {
        base.Configure(builder);

        builder.HasOne<Session>()
            .WithMany()
            .HasForeignKey(ss => ss.SessionId);

        builder.HasOne<Seat>()
            .WithMany()
            .HasForeignKey(ss => ss.SeatId);

        builder.Property(ss => ss.IsReserved)
            .IsRequired();
    }
}