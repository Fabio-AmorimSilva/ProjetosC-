namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public DateTime Year { get; set; }
    public int Pages { get; set; }
    public int Quantity { get; set; }
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    public Guid LibraryId { get; set; }
    public LibraryUnit? Library { get; set; }
    public BookGenre Genre { get; set; }

    public Book( 
        string title, 
        DateTime year, 
        int pages, 
        Guid authorId,
        Guid libraryId,
        BookGenre genre) 
    {
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
    }
}
