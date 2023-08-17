namespace Library.Infrastructure.Mappings;

public class LibraryUnitEntityMapping : BaseEntityMapping<LibraryUnit>
{
    public override void Configure(EntityTypeBuilder<LibraryUnit> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Libraries");

        builder
            .Property(lu => lu.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(lu => lu.City)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .HasMany(lu => lu.Books)
            .WithOne(lu => lu.Library)
            .HasForeignKey(lu => lu.LibraryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
