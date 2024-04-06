using Library.Application.ViewModels.Authors;

namespace Library.Application.Queries.Author.ListAuthors;

public struct ListAuthorsQuery : IRequest<ResultViewModel<IEnumerable<AuthorViewModel>>>
{
}