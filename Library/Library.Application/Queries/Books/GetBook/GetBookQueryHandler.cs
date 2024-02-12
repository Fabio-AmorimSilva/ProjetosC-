using Library.Domain.Messages;

namespace Library.Application.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery , ResultViewModel<BookViewModel>>
{
    private readonly LibraryContext _context;

    public GetBookQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (book is null)
            return new ResultViewModel<BookViewModel>(ErrorMessages.NotFound<Book>());

        return new ResultViewModel<BookViewModel>(new BookViewModel
        {
            Title = book.Title,
            Genre = book.Genre,
            Quantity = book.Quantity,
            Pages = book.Pages,
            Year = book.Year
        });
    }
}