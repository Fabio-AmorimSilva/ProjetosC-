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
        BookGenre genre
    ) 
    {
        Guard.HasSizeLessThan(title, 80, nameof(Title));
        Guard.IsGreaterThan(pages, 0, nameof(pages));
        Guard.IsDefault(authorId, nameof(authorId));
        Guard.IsDefault(libraryId, nameof(libraryId));
        
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
    }

    public Result UpdateBook(
        string title,
        DateTime year,
        int pages,
        Guid authorId,
        Guid libraryId,
        BookGenre genre
    )
    {
        if(string.IsNullOrEmpty(title))
            return Result.FailureResult("Cannot be empty");
        
        if(title.Length > 80)
            return Result.FailureResult("Name must have less than 80 characters");
        
        if(pages <= 0)
            return Result.FailureResult("Pages must be greater than 0");
        
        if(authorId == default)
            return Result.FailureResult("Author cannot be empty");
        
        if(libraryId == default)
            return Result.FailureResult("Library cannot be empty");
        
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
        
        return Result.SuccessResult();
    }

    public Result UpdateAuthor(Guid authorId)
    {
        if (authorId == default)
            return Result.FailureResult("Id cannot be empty");
        
        AuthorId = authorId;
        
        return Result.SuccessResult();
    }

    public Result UpdateLibrary(Guid libraryId)
    {
        if(libraryId == default)
            return Result.FailureResult("Id cannot be empty");
        
        LibraryId = libraryId;
        
        return Result.SuccessResult();
    }
    
    public Result UpdateQuantity(int quantity)
    {
        if (quantity < 0)
            return Result.FailureResult("Quantity must be greater than 0");
        
        Quantity = quantity;

        return Result.SuccessResult();
    }
}