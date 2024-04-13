using Library.Application.ViewModels.Library;

namespace Library.Application.Queries.Libraries.GetLibrary;

public class GetLibraryQueryHandler : IRequestHandler<GetLibraryQuery, ResultResponse<LibraryUnitViewModel>>
{
    private readonly LibraryContext _context;

    public GetLibraryQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultResponse<LibraryUnitViewModel>> Handle(GetLibraryQuery request, CancellationToken cancellationToken)
    {
        var library = await _context.Libraries
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (library is null)
            return new NotFoundResponse<LibraryUnitViewModel>(ErrorMessages.NotFound<LibraryUnit>());

        return new OkResponse<LibraryUnitViewModel>(new LibraryUnitViewModel
        {
            Name = library.Name,
            City = library.City
        });
    }
}