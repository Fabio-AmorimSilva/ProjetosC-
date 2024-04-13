namespace Library.Application.Queries.Books.GetBook;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery , ResultResponse<BookViewModel>>
{
    private readonly LibraryContext _context;

    public GetBookQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultResponse<BookViewModel>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (book is null)
            return new NotFoundResponse<BookViewModel>(ErrorMessages.NotFound<Book>());

        return new OkResponse<BookViewModel>(new BookViewModel
        {
            Title = book.Title,
            Genre = book.Genre,
            Quantity = book.Quantity,
            Pages = book.Pages,
            Year = book.Year
        });
    }
}