using Library.Application.ViewModels.Authors;

namespace Library.Application.Queries.Author.ListAuthors;

public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, ResultViewModel<IEnumerable<AuthorViewModel>>>
{
    private readonly LibraryContext _context;

    public ListAuthorsQueryHandler(LibraryContext context)
        => _context = context;
        
    public async Task<ResultViewModel<IEnumerable<AuthorViewModel>>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _context.Authors
            .AsNoTrackingWithIdentityResolution()
            .Select(a => new AuthorViewModel
            {
                Name = a.Name,
                Country = a.Country,
                Birth = a.Birth
            })
            .ToListAsync(cancellationToken);

        return new ResultViewModel<IEnumerable<AuthorViewModel>>(authors);
    }
}