namespace Library.Infrastructure.Mappings;

public class LibraryUnitEntityMapping
{
    public void Configure(EntityTypeBuilder<LibraryUnit> builder)
    {
        builder
            .ToTable("Libraries");

        builder
            .ConfigureEntityConventions();
        
        builder
            .Property(lu => lu.Name)
            .HasMaxLength(LibraryUnit.NameMaxLength)
            .IsRequired();

        builder
            .Property(lu => lu.City)
            .HasMaxLength(LibraryUnit.CityMaxLength)
            .IsRequired();

        builder
            .HasMany(lu => lu.Books)
            .WithOne(lu => lu.Library)
            .HasForeignKey(lu => lu.LibraryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
