namespace Library.Application.Queries;

public struct GetLibraryQuery : IRequest<ResultViewModel<LibraryUnitViewModel>>
{
    public Guid Id { get; init; }

    public GetLibraryQuery(Guid id)
        => Id = id;
}