namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int CountryMaxLength = 80;
    
    public string Name { get; set; }
    public string Country { get; set; }
    public DateTime Birth { get; set; }
    public List<Book> Books { get; set; } = new();
    
    public Author( 
        string name, 
        string country, 
        DateTime birth
    )
    {
        Guard.HasSizeLessThan(name, NameMaxLength, nameof(name));
        Guard.HasSizeLessThan(country, CountryMaxLength, nameof(country));
        
        Id = Guid.NewGuid();
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
            return Result.FailureResult("Cannot be empty");
        
        if(name.Length > NameMaxLength)
            return Result.FailureResult("Name must have less than 80 characters");
        
        if(string.IsNullOrEmpty(country))
            return Result.FailureResult("Cannot be empty");
        
        if(name.Length > CountryMaxLength)
            return Result.FailureResult("Country must have less than 80 characters");
        
        Name = name;
        Country = country;
        Birth = birth;
        
        return Result.SuccessResult();
    }
}
