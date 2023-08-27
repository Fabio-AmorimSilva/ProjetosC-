namespace Library.Application.Queries;

public struct GetAuthorQuery : IRequest<ResultViewModel<AuthorViewModel>>
{
    public Guid Id { get; init; }

    public GetAuthorQuery(Guid id)
        => Id = id;
}