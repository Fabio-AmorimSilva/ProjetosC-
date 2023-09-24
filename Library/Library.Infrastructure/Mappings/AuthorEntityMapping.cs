namespace Library.Infrastructure.Mappings;

public class AuthorEntityMapping
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
            .ConfigureEntityConventions();
        
        builder
            .Property(a => a.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(a => a.Country)
            .HasMaxLength(80)
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
