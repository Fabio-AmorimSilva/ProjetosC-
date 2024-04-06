using Library.Application.ViewModels.Library;

namespace Library.Application.Queries.Libraries.GetLibrary;

public class GetLibraryQueryHandler : IRequestHandler<GetLibraryQuery, ResultViewModel<LibraryUnitViewModel>>
{
    private readonly LibraryContext _context;

    public GetLibraryQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<LibraryUnitViewModel>> Handle(GetLibraryQuery request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (library is null)
            return new ResultViewModel<LibraryUnitViewModel>(ErrorMessages.NotFound<LibraryUnit>());

        return new ResultViewModel<LibraryUnitViewModel>(new LibraryUnitViewModel
        {
            Name = library.Name,
            City = library.City
        });
    }
}