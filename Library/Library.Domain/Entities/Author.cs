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
        Id = Guid.NewGuid();
        Name = name;
        Country = country;
        Birth = birth;
    }
    
    public void UpdateAuthor(
        string name, 
        string country, 
        DateTime birth
    )
    {
        Name = name;
        Country = country;
        Birth = birth;
    }
}
