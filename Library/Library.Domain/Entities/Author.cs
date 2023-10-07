namespace Library.Domain.Entities;

public class Author : BaseEntity
{
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
        Guard.HasSizeLessThan(name, 80, nameof(name));
        Guard.HasSizeLessThan(country, 80, nameof(country));
        
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
        
        if(name.Length > 80)
            return Result.FailureResult("Name must have less than 80 characters");
        
        if(string.IsNullOrEmpty(country))
            return Result.FailureResult("Cannot be empty");
        
        if(name.Length > 80)
            return Result.FailureResult("Country must have less than 80 characters");
        
        Name = name;
        Country = country;
        Birth = birth;
        
        return Result.SuccessResult();
    }
}
