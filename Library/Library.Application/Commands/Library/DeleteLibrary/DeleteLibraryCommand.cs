namespace Library.Application.Commands;

public struct DeleteLibraryCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; init; }

    public DeleteLibraryCommand(Guid id)
        => Id = id;
}