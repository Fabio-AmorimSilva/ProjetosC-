using Library.Application.ViewModels.Library;

namespace Library.Application.Queries.Libraries.ListLibraries;

public struct ListLibrariesQuery : IRequest<ResultViewModel<IEnumerable<LibraryUnitViewModel>>>
{
}