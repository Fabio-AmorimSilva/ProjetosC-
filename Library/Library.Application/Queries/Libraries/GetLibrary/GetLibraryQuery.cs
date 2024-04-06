using Library.Application.ViewModels.Library;

namespace Library.Application.Queries.Libraries.GetLibrary;

public struct GetLibraryQuery : IRequest<ResultViewModel<LibraryUnitViewModel>>
{
    public Guid Id { get; init; }

    public GetLibraryQuery(Guid id)
        => Id = id;
}