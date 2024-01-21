namespace Library.Infrastructure.Mappings;

public class BookEntityMapping
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .ToTable("Books");
        
        builder
            .ConfigureEntityConventions();
        
        builder
            .Property(b => b.Title)
            .HasMaxLength(Book.TitleMaxLength)
            .IsRequired();

        builder
            .Property(b => b.Year)
            .IsRequired();

        builder
            .Property(b => b.Pages)
            .IsRequired();

        builder
            .Property(b => b.Quantity)
            .IsRequired();

        builder
            .Property(b => b.Genre)
            .IsRequired();

        builder
            .HasOne(b => b.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.Library)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.LibraryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
