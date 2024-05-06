using Library.Core.Entities;
using Library.Core.ErrorHandling;
using Library.Core.Messages;

namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int CountryMaxLength = 80;
    
    public string Name { get; private set; }
    public string Country { get; private set; }
    public DateTime Birth { get; private set; }
    
    private List<Book> _books = [];
    public IReadOnlyCollection<Book> Books => _books;
    
    public Author( 
        string name, 
        string country, 
        DateTime birth
    )
    {
        Guard.HasSizeLessThan(name, NameMaxLength, nameof(name));
        Guard.HasSizeLessThan(country, CountryMaxLength, nameof(country));
        
        Name = name;
        Country = country;
        Birth = birth;
    }
    
    public Result UpdateAuthor(
        string name, 
        string country, 
        DateTime birth
    )
    {
        if(string.IsNullOrEmpty(name))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(name)));
        
        if(name.Length > NameMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(name), NameMaxLength));

        if (string.IsNullOrEmpty(country))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(country)));
        
        if(name.Length > CountryMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(country),CountryMaxLength));
        
        Name = name;
        Country = country;
        Birth = birth;
        
        return Result.SuccessResult();
    }

    public Book? GetBook(Guid bookId)
        => _books.FirstOrDefault(b => b.Id == bookId);
    
    public void AddBook(Book book)
        => _books.Add(book);

    public void DeleteBook(Book book)
        => _books.Remove(book);
}
