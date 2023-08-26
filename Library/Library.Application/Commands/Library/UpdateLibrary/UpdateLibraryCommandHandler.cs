namespace Library.Application.Commands;

public class UpdateLibraryCommandHandler : IRequestHandler<UpdateLibraryCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateLibraryCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
        if (library is null)
            return new ResultViewModel<Unit>("Book not found");

        library.UpdateLibrary(request.Name, request.City);

        await _context.SaveChangesAsync(cancellationToken);
        return new ResultViewModel<Unit>();
    }
}