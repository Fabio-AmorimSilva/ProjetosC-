namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; private set; }
    public DateTime Year { get; private set; }
    public int Pages { get; private set; }
    public int Quantity { get; private set; }
    public Guid AuthorId { get; private set; }
    public Author? Author { get; private set; }
    public Guid LibraryId { get; private set; }
    public LibraryUnit? Library { get; private set; }
    public BookGenre Genre { get; private set; }

    public Book(){}
    
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

    public void UpdateBook(string title,
        DateTime year,
        int pages,
        Guid authorId,
        Guid libraryId,
        BookGenre genre
    )
    {
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
    }

    public void UpdateQuantity(int quantity)
        => Quantity = quantity;
}