namespace Library.Application.Commands.Author.DeleteAuthor;

public readonly struct DeleteAuthorCommand(Guid authorId) : IRequest<ResultResponse<Unit>>
{
    public Guid AuthorId { get; init; } = authorId;
}