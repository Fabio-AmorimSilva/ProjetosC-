namespace Library.Application.Queries.Books.GetBook;

public struct GetBookQuery(Guid id) : IRequest<ResultViewModel<BookViewModel>>
{
    public Guid Id { get; init; } = id;
}