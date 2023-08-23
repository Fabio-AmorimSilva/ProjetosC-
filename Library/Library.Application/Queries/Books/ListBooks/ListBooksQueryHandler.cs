using Library.Application.ViewModels.Books;

namespace Library.Application.Queries;

public class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, ResultViewModel<IEnumerable<ListBookViewModel>>>
{
    private readonly LibraryContext _context;

    public ListBooksQueryHandler(LibraryContext context)
        =>  _context = context;
    
    public async Task<ResultViewModel<IEnumerable<ListBookViewModel>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Library)
            .Select(b => new ListBookViewModel
            {
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                Library = b.Library,
                Pages = b.Pages,
                Quantity = b.Quantity,
                Year = b.Year
            })
            .ToListAsync(cancellationToken);
        
        return new ResultViewModel<IEnumerable<ListBookViewModel>>(books);
    }
}