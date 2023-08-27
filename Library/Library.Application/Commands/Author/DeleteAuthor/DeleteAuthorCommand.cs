namespace Library.Application.Commands;

public struct DeleteAuthorCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; init; }

    public DeleteAuthorCommand(Guid id)
        => Id = id;
}