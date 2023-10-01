namespace Library.Application.Commands;

public struct UpdateBookAuthorCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid AuthorId { get; init; }
    public Guid BookId { get; init; }
}