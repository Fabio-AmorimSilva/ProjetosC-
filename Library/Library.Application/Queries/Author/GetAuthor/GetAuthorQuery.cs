namespace Library.Application.Queries;

public struct GetAuthorQuery(Guid id) : IRequest<ResultViewModel<AuthorViewModel>>
{
    public Guid Id { get; init; } = id;
}