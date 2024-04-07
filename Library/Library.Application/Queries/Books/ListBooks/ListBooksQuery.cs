namespace Library.Application.Queries.Books.ListBooks;

public struct ListBooksQuery : IRequest<ResultResponse<IEnumerable<ListBookViewModel>>>
{
}