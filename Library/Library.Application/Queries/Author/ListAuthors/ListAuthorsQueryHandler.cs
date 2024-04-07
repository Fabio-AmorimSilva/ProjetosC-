namespace Library.Application.Queries.Author.ListAuthors;

public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, ResultResponse<IEnumerable<AuthorViewModel>>>
{
    private readonly LibraryContext _context;

    public ListAuthorsQueryHandler(LibraryContext context)
        => _context = context;
        
    public async Task<ResultResponse<IEnumerable<AuthorViewModel>>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _context.Authors
            .Select(a => new AuthorViewModel
            {
                Name = a.Name,
                Country = a.Country,
                Birth = a.Birth
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<AuthorViewModel>>(authors);
    }
}