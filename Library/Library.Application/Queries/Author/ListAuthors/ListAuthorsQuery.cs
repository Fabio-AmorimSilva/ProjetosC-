namespace Library.Application.Queries.Author.ListAuthors;

public struct ListAuthorsQuery : IRequest<ResultResponse<IEnumerable<AuthorViewModel>>>
{
}