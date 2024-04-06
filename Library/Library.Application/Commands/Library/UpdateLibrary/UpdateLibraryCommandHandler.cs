namespace Library.Application.Commands.Library.UpdateLibrary;

public class UpdateLibraryCommandHandler : IRequestHandler<UpdateLibraryCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateLibraryCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
        if (library is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        var result = library.UpdateLibrary(
            name: request.Name,
            city: request.City
        );

        if (!result.Success)
            return new ResultViewModel<Unit>(result.Message);
        
        await _context.SaveChangesAsync(cancellationToken);
        return new ResultViewModel<Unit>();
    }
}