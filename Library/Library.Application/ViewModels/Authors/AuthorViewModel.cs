namespace Library.Application.ViewModels.Authors;

public readonly record struct AuthorViewModel
{
    public required string Name { get; init; }
    public required string Country { get; init; }
    public required DateTime Birth { get; init; }
    public IEnumerable<Book>? Books { get; init; }
}
