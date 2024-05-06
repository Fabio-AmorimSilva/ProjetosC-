using Library.Core.Entities;
using Library.Core.ErrorHandling;
using Library.Core.Messages;

namespace Library.Domain.Entities;

public class LibraryUnit : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int CityMaxLength = 80;
    
    public string Name { get; private set; }
    public string City { get; private set; }
    
    private List<Book> _books = [];
    public IReadOnlyCollection<Book> Books => _books;

    public LibraryUnit(
        string name, 
        string city
    )
    {
        Guard.HasSizeLessThan(name, NameMaxLength, nameof(name));
        Guard.HasSizeLessThan(city, CityMaxLength, nameof(city));
        
        Name = name;
        City = city;
    }
    
    public Result UpdateLibrary(string name, string city)
    {
        if(string.IsNullOrEmpty(name))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(name)));
        
        if(name.Length > NameMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(name), NameMaxLength));
        
        if(string.IsNullOrEmpty(city))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(city)));
        
        if(city.Length > CityMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(city), CityMaxLength));
        
        Name = name;
        City = city;
        
        return Result.SuccessResult();
    }

    public Book? GetBook(Guid bookId)
        => _books.FirstOrDefault(b => b.Id == bookId);
    
    public void AddBook(Book book)
        => _books.Add(book);

    public void DeleteBook(Book book)
        => _books.Remove(book);
}
