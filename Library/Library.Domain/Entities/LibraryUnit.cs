namespace Library.Domain.Entities;

public class LibraryUnit : BaseEntity
{
    public string Name { get; set; }
    public string City { get; set; }
    public List<Book?> Books { get; set; } = new();

    public LibraryUnit(string name, string city)
    {
        Id = Guid.NewGuid();
        Name = name;
        City = city;
    }
    
    public void UpdateLibrary(string name, string city)
    {
        Name = name;
        City = city;
    }
}
