namespace Library.Application.Commands.Library.DeleteLibrary;

public readonly struct DeleteLibraryCommand(Guid libraryUnitId) : IRequest<ResultResponse<Unit>>
{
    public Guid LibraryUnitId { get; init; } = libraryUnitId;
}