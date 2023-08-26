namespace Library.Application.Commands;

public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public CreateLibraryCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = new LibraryUnit(
            name: request.Name,
            city: request.City
        );

        await _context.Libraries.AddAsync(library, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}