namespace Library.Application.Queries.Author.GetAuthor;

public readonly struct GetAuthorQuery(Guid id) : IRequest<ResultResponse<AuthorViewModel>>
{
    public Guid Id { get; init; } = id;
}