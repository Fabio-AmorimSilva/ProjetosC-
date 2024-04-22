namespace Library.Application.Commands.Book.DeleteBook;

public readonly struct DeleteBookCommand(
    Guid bookId,
    Guid authorId
) : IRequest<ResultResponse<Unit>>
{
    public Guid BookId { get; init; } = bookId;
    public Guid AuthorId { get; init; } = authorId;
}