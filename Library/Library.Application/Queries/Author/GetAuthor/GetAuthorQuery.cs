using Library.Application.ViewModels.Authors;

namespace Library.Application.Queries.Author.GetAuthor;

public readonly struct GetAuthorQuery(Guid id) : IRequest<ResultViewModel<AuthorViewModel>>
{
    public Guid Id { get; init; } = id;
}