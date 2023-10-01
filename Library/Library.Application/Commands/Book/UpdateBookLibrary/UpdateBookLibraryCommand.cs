namespace Library.Application.Commands;

public struct UpdateBookLibraryCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid LibraryId { get; init; }
    public Guid BookId { get; init; }
}