namespace Library.Application.ViewModels.Books;

public readonly record struct BookViewModel
{
    public required string Title { get; init; }
    public required DateTime Year { get; init; }
    public required int Pages { get; init; }
    public required int Quantity { get; init; }
    public required BookGenre Genre { get; init; }
}