namespace Library.Application.Commands.Book.CreateBook;

public readonly struct CreateBookCommand(
    string title,
    DateTime year,
    int pages,
    Guid authorId,
    Guid libraryId,
    BookGenre genre)
    : IRequest<ResultResponse<Guid>>
{
    public string Title { get; init; } = title;
    public DateTime Year { get; init; } = year;
    public int Pages { get; init; } = pages;
    public Guid AuthorId { get; init; } = authorId;
    public Guid LibraryId { get; init; } = libraryId;
    public BookGenre Genre { get; init; } = genre;
}