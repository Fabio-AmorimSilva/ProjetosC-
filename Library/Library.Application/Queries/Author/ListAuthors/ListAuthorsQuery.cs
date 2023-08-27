namespace Library.Application.Queries;

public struct ListAuthorsQuery : IRequest<ResultViewModel<IEnumerable<AuthorViewModel>>>
{
}