using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Configure Id as primary key
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        // Configure Guid with a unique constraint
        builder.Property(e => e.Guid)
            .IsRequired();

        builder.HasIndex(e => e.Guid)
            .IsUnique();

        // Configure CreatedAt
        builder.Property(e => e.CreatedAt)
            .IsRequired();

        // Configure UpdatedAt
        builder.Property(e => e.UpdatedAt)
            .IsRequired();
    }
}