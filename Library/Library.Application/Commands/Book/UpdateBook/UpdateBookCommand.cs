namespace Library.Application.Commands.Book.UpdateBook;

public struct UpdateBookCommand(
    Guid bookId,
    string title,
    DateTime year,
    int pages,
    Guid authorId,
    BookGenre genre)
    : IRequest<ResultResponse<Unit>>
{
    public Guid BookId { get; set; } = bookId;
    public string Title { get; init; } = title;
    public DateTime Year { get; init; } = year;
    public int Pages { get; init; } = pages;
    public Guid AuthorId { get; init; } = authorId;
    public BookGenre Genre { get; init; } = genre;
}