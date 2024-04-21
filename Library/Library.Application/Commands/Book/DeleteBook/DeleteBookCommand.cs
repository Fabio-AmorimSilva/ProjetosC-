namespace Library.Application.Commands.Book.DeleteBook;

public readonly struct DeleteBookCommand(Guid bookId) : IRequest<ResultResponse<Unit>>
{
    public Guid BookId { get; init; } = bookId;
}