namespace Library.Application.ViewModels.Library;

public readonly record struct LibraryUnitViewModel
{
    public required string Name { get; init; }
    public required string City { get; init; }
    public List<BookViewModel> Books { get; init; }
}
