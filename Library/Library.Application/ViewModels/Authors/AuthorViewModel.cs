using Library.Domain.Entities;

namespace Library.Application.ViewModels.Authors;

public struct AuthorViewModel
{
    public string Name { get; init; }
    public string Country { get; init; }
    public DateTime Birth { get; init; }
    public IEnumerable<Book> Books { get; init; }
}
