namespace Library.Application.Queries;

public struct ListLibrariesQuery : IRequest<ResultViewModel<IEnumerable<LibraryUnitViewModel>>>
{
}