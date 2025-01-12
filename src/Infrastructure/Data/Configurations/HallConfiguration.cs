using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data.Configurations;

public class HallConfiguration : BaseEntityConfiguration<Hall>
{
    public override void Configure(EntityTypeBuilder<Hall> builder)
    {
        base.Configure(builder);

        IMutableNavigation? navigation = builder.Metadata.FindNavigation(nameof(Hall.Seats));
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