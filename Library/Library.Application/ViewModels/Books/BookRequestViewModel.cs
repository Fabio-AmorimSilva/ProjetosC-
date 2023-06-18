using Library.Domain.Entities.Enums;

namespace Library.Application.ViewModels.Books;

public struct BookRequestViewModel
{
    public string Title { get; init; }
    public DateTime Year { get; init; }
    public int Pages { get; init; }
    public int Quantity { get; init; }
    public Guid AuthorId { get; init; }
    public Guid LibraryId { get; init; }
    public BookGenre Genre { get; init; }
}
