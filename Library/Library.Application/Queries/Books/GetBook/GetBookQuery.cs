namespace Library.Application.Queries;

public struct GetBookQuery : IRequest<ResultViewModel<BookViewModel>>
{
    public Guid Id { get; init; }

    public GetBookQuery(Guid id)
        =>  Id = id;
}