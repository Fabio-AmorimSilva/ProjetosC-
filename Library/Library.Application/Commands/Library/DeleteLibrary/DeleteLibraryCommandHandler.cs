namespace Library.Application.Commands.Library.DeleteLibrary;

public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, ResultResponse<Unit>>
{
    private readonly LibraryContext _context;

    public DeleteLibraryCommandHandler(LibraryContext context)
        => _context = context;
        
    public async Task<ResultResponse<Unit>> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (library is null)
            return new ResultResponse<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultResponse<Unit>();
    }
}