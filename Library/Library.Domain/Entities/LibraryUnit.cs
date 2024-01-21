namespace Library.Domain.Entities;

public class LibraryUnit : BaseEntity
{
    public const int LibraryNameMaxLength = 80;
    public const int CityNameMaxLength = 80;
    
    public string Name { get; set; }
    public string City { get; set; }
    public List<Book?> Books { get; set; } = new();

    public LibraryUnit(
        string name, 
        string city
    )
    {
        Guard.HasSizeLessThan(name, LibraryNameMaxLength, nameof(name));
        Guard.HasSizeLessThan(city, CityNameMaxLength, nameof(city));
        
        Id = Guid.NewGuid();
        Name = name;
        City = city;
    }
    
    public Result UpdateLibrary(string name, string city)
    {
        if(string.IsNullOrEmpty(name))
            return Result.FailureResult("Name cannot be null");
        
        if(name.Length > LibraryNameMaxLength)
            return Result.FailureResult("Name cannot have more than 80 characters");
        
        if(string.IsNullOrEmpty(city))
            return Result.FailureResult("City cannot be empty");
        
        if(city.Length > CityNameMaxLength)
            return Result.FailureResult("City cannot have more than 80 characters");
        
        Name = name;
        City = city;
        
        return Result.SuccessResult();
    }
}
