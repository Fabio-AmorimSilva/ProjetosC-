namespace Library.Application.Queries;

public class ListLibrariesQueryHandler : IRequestHandler<ListLibrariesQuery, ResultViewModel<IEnumerable<LibraryUnitViewModel>>>
{
    private readonly LibraryContext _context;

    public ListLibrariesQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<IEnumerable<LibraryUnitViewModel>>> Handle(ListLibrariesQuery request, CancellationToken cancellationToken)
    {
        var libraries = await _context.Libraries
            .AsNoTrackingWithIdentityResolution()
            .Select(l => new LibraryUnitViewModel
            {
                Name = l.Name,
                City = l.City
            })
            .ToListAsync(cancellationToken);

        return new ResultViewModel<IEnumerable<LibraryUnitViewModel>>(libraries);
    }
}