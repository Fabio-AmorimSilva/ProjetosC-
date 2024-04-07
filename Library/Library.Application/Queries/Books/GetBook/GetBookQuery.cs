namespace Library.Application.Queries.Books.GetBook;

public readonly struct GetBookQuery(Guid id) : IRequest<ResultResponse<BookViewModel>>
{
    public Guid Id { get; init; } = id;
}