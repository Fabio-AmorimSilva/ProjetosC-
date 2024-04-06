namespace Library.Application.Commands.Library.DeleteLibrary;

public struct DeleteLibraryCommand(Guid id) : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; init; } = id;
}