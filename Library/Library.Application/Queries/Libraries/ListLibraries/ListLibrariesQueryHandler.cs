using Library.Application.ViewModels.Library;

namespace Library.Application.Queries.Libraries.ListLibraries;

public class ListLibrariesQueryHandler : IRequestHandler<ListLibrariesQuery, ResultResponse<IEnumerable<LibraryUnitViewModel>>>
{
    private readonly LibraryContext _context;

    public ListLibrariesQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultResponse<IEnumerable<LibraryUnitViewModel>>> Handle(ListLibrariesQuery request, CancellationToken cancellationToken)
    {
        var libraries = await _context.Libraries
            .Select(l => new LibraryUnitViewModel
            {
                Name = l.Name,
                City = l.City
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<LibraryUnitViewModel>>(libraries);
    }
}