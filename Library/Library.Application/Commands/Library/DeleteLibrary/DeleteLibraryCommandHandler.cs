using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public DeleteLibraryCommandHandler(LibraryContext context)
        => _context = context;
        
    public async Task<ResultViewModel<Unit>> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (library is null)
            return new ResultViewModel<Unit>(Messages.NotFound<LibraryUnit>());

        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}