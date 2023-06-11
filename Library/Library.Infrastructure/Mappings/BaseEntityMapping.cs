using Library.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Mappings;

public class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .HasIndex(r => r.Id);

        builder
            .Property(r => r.Id)
            .ValueGeneratedNever();

        builder
            .Property(r => r.CreatedAt)
            .IsRequired();

        builder
            .Property (r => r.UpdatedAt)
            .IsRequired(false);
    }
}
