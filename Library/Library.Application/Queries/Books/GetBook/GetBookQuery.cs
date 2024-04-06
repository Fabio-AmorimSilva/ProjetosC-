namespace Library.Application.Queries.Books.GetBook;

public readonly struct GetBookQuery(Guid id) : IRequest<ResultViewModel<BookViewModel>>
{
    public Guid Id { get; init; } = id;
}