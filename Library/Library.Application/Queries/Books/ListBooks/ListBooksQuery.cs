namespace Library.Application.Queries.Books.ListBooks;

public struct ListBooksQuery : IRequest<ResultViewModel<IEnumerable<ListBookViewModel>>>
{
}