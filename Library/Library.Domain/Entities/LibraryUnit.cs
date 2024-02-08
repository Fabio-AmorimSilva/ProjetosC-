using Library.Domain.Messages;

namespace Library.Domain.Entities;

public class LibraryUnit : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int CityMaxLength = 80;
    
    public string Name { get; set; }
    public string City { get; set; }
    public List<Book?> Books { get; set; } = new();

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
}
