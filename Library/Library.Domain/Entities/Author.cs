using Library.Core.Core;
using Library.Core.ErrorHandling;
using Library.Core.Messages;

namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int CountryMaxLength = 80;
    
    public string Name { get; set; }
    public string Country { get; set; }
    public DateTime Birth { get; set; }
    public List<Book> Books { get; set; } = [];
    
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
}
