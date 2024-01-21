namespace Library.Infrastructure.Mappings;

public class AuthorEntityMapping
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .ConfigureEntityConventions();
        
        builder
            .Property(a => a.Name)
            .HasMaxLength(Author.NameMaxLength)
            .IsRequired();

        builder
            .Property(a => a.Country)
            .HasMaxLength(Author.CountryMaxLength)
            .IsRequired();

        builder
            .Property(a => a.Birth)
            .IsRequired();

        builder
            .HasMany(a => a.Books)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
