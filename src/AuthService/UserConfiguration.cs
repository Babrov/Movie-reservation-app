using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace AuthService;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.PasswordHash)
            .IsRequired();

        builder.Property(e => e.IsAdmin).HasDefaultValue(false);
        builder.Property(e => e.IsActive).HasDefaultValue(true);


        builder.HasIndex(e => e.Email).IsUnique();
    }
}