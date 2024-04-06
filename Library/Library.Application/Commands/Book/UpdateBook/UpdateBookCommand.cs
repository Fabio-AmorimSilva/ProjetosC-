namespace Library.Application.Commands.Book.UpdateBook;

public class UpdateBookCommand(
    Guid id,
    string title,
    DateTime year,
    int pages,
    Guid authorId,
    Guid libraryId,
    BookGenre genre)
    : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; set; } = id;
    public string Title { get; init; } = title;
    public DateTime Year { get; init; } = year;
    public int Pages { get; init; } = pages;
    public Guid AuthorId { get; init; } = authorId;
    public Guid LibraryId { get; init; } = libraryId;
    public BookGenre Genre { get; init; } = genre;
}