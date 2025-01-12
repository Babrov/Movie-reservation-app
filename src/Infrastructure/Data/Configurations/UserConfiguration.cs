namespace Infrastructure.Data.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Email)
            .IsRequired();

        builder.Property(e => e.FirstName)
            .IsRequired();

        builder.Property(e => e.LastName)
            .IsRequired();

        builder.Property(e => e.PasswordHash)
            .IsRequired();

        builder.HasIndex(e => e.Email);
    }
}