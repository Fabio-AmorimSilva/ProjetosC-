using Library.Application.ViewModels.Library;

namespace Library.Application.ViewModels.Books;

public readonly record struct ListBookViewModel
{
    public required BookViewModel Book { get; init; }
    public required AuthorViewModel Author { get; init; }
    public required LibraryUnitViewModel Library { get; init; }
}
