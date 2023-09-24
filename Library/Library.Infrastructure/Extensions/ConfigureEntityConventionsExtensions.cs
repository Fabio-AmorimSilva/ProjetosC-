namespace Library.Infrastructure.Extensions;

public static class ConfigureEntityConventionsExtensions
{
    public static void ConfigureEntityConventions(this EntityTypeBuilder builder)
    {
        builder.As<EntityTypeBuilder>().TryConfigureEntityBase();
    }
    
    public static void TryConfigureEntityBase(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo<BaseEntity>())
            return;

        builder
            .HasKey(nameof(BaseEntity.Id));

        builder
            .Property(nameof(BaseEntity.Id))
            .ValueGeneratedNever();
        
        builder
            .Property(nameof(BaseEntity.CreatedAt))
            .IsRequired();
        
        builder
            .Property(nameof(BaseEntity.Id))
            .IsRequired(false);
    }

    private static T As<T>(this object obj)
        => (T)obj;
}