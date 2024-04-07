namespace Library.Application.Commands.Book.UpdateBookAuthor;

public struct UpdateBookAuthorCommand : IRequest<ResultResponse<Unit>>
{
    public Guid AuthorId { get; init; }
    public Guid BookId { get; init; }
}