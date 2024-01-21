namespace Library.Domain.Entities;

public class Author : BaseEntity
{
    public const int AuthorNameMaxLength = 80;
    public const int CountryNameMaxLength = 80;
    
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
        Guard.HasSizeLessThan(name, AuthorNameMaxLength, nameof(name));
        Guard.HasSizeLessThan(country, CountryNameMaxLength, nameof(country));
        
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
        
        if(name.Length > AuthorNameMaxLength)
            return Result.FailureResult("Name must have less than 80 characters");
        
        if(string.IsNullOrEmpty(country))
            return Result.FailureResult("Cannot be empty");
        
        if(name.Length > CountryNameMaxLength)
            return Result.FailureResult("Country must have less than 80 characters");
        
        Name = name;
        Country = country;
        Birth = birth;
        
        return Result.SuccessResult();
    }
}
