namespace Library.Application.Queries;

public struct GetBookQuery(Guid id) : IRequest<ResultViewModel<BookViewModel>>
{
    public Guid Id { get; init; } = id;
}