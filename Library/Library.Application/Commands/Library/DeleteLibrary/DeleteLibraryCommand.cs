namespace Library.Application.Commands.Library.DeleteLibrary;

public readonly struct DeleteLibraryCommand(Guid id) : IRequest<ResultResponse<Unit>>
{
    public Guid Id { get; init; } = id;
}