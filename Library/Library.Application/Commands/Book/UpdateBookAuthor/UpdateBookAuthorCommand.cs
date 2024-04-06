namespace Library.Application.Commands.Book.UpdateBookAuthor;

public struct UpdateBookAuthorCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid AuthorId { get; init; }
    public Guid BookId { get; init; }
}