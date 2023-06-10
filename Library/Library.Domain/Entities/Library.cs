using Library.Domain.Entities.Core;

namespace Library.Domain.Entities;

public class Library : BaseEntity
{
    public string Name { get; set; }
    public string City { get; set; }
    public List<Book> Books { get; set; } = new();

    public Library(string name, string city)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = null;

        Name = name;
        City = city;
    }

    public bool AddBook(Book book)
    {
        if(book is null)
            return false;

        Books.Add(book);
        return true;
    }
}
