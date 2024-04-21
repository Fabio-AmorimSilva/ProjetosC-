namespace Library.Application.Commands.Library.UpdateLibrary;

public readonly struct UpdateLibraryCommand(
    Guid libraryUnitId, 
    string name, 
    string city
) : IRequest<ResultResponse<Unit>>
{
    public Guid LibraryUnitId { get; init; } = libraryUnitId;
    public string Name { get; init; } = name;
    public string City { get; init; } = city;
}