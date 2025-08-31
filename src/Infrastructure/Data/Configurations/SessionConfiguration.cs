using Domain.Entities;
using Shared.Infrastructure;

namespace Infrastructure.Data.Configurations;

public class SessionConfiguration : BaseEntityConfiguration<Session>
{
    public override void Configure(EntityTypeBuilder<Session> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.StartsAt)
            .IsRequired();

        builder.Property(e => e.EndsAt)
            .IsRequired();

        builder.Property(e => e.MovieId)
            .IsRequired();

        builder.Property(e => e.HallId)
            .IsRequired();

        builder.HasIndex(e => e.Date);
        builder.HasIndex(e => new { e.MovieId, e.HallId });

        builder.HasOne<Hall>()
            .WithMany()
            .HasForeignKey(e => e.HallId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}