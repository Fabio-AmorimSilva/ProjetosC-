namespace Library.Application.Commands.Author.DeleteAuthor;

public struct DeleteAuthorCommand(Guid id) : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; init; } = id;
}