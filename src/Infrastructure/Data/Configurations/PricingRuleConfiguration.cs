using Domain.Entities;
using Shared.Infrastructure;

namespace Infrastructure.Data.Configurations;

public class PricingRuleConfiguration : BaseEntityConfiguration<PricingRule>
{
    public override void Configure(EntityTypeBuilder<PricingRule> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.SeatType)
            .HasMaxLength(50)
            .HasConversion<string>()
            .IsRequired();

        builder.HasIndex(e => e.SeatType);
    }
}