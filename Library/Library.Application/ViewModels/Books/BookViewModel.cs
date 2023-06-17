using Library.Domain.Entities.Enums;
using Library.Domain.Entities;

namespace Library.Application.ViewModels.Books;

public struct BookViewModel
{
    public string Title { get; init; }
    public DateTime Year { get; init; }
    public int Pages { get; init; }
    public int Quantity { get; init; }
    public Guid AuthorId { get; init; }
    public Author? Author { get; init; }
    public Guid LibraryId { get; init; }
    public LibraryUnit? Library { get; init; }
    public BookGenre Genre { get; init; }
}
