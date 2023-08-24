namespace Library.Application.Queries;

public struct ListBooksQuery : IRequest<ResultViewModel<IEnumerable<ListBookViewModel>>>
{
}