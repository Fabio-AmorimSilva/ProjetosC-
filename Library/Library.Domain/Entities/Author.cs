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
   
    public bool AddBook(Book book)
    {
        if (book is null)
            return false;

        Books.Add(book);
        return true;
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
