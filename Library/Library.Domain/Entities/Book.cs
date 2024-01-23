using Library.Domain.ErrorMessages;

namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public const int TitleMaxLength = 80;
    public const int PagesMinLength = 0;
    
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
        Guard.HasSizeLessThan(title, TitleMaxLength, nameof(Title));
        Guard.IsGreaterThan(pages, PagesMinLength, nameof(pages));
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
            return Result.FailureResult(Messages.CannotBeEmpty(nameof(title)));
        
        if(title.Length > TitleMaxLength)
            return Result.FailureResult(Messages.HasMaxLength(nameof(title), TitleMaxLength));
        
        if(pages <= PagesMinLength)
            return Result.FailureResult(Messages.HasToBeGreaterThan(nameof(pages), PagesMinLength));
        
        if(authorId == default)
            return Result.FailureResult(Messages.CannotBeEmpty(nameof(authorId)));
        
        if(libraryId == default)
            return Result.FailureResult(Messages.CannotBeEmpty(nameof(libraryId)));
        
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
            return Result.FailureResult(Messages.CannotBeEmpty(nameof(authorId)));
        
        AuthorId = authorId;
        
        return Result.SuccessResult();
    }

    public Result UpdateLibrary(Guid libraryId)
    {
        if(libraryId == default)
            return Result.FailureResult(Messages.CannotBeEmpty(nameof(libraryId)));
        
        LibraryId = libraryId;
        
        return Result.SuccessResult();
    }
    
    public Result UpdateQuantity(int quantity)
    {
        if (quantity < 0)
            return Result.FailureResult(Messages.HasToBeGreaterThan(nameof(quantity), PagesMinLength));
        
        Quantity = quantity;

        return Result.SuccessResult();
    }
}