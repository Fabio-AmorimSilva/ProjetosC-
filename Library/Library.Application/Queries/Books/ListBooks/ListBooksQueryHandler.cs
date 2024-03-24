namespace Library.Application.Queries;

public class ListBooksQueryHandler(LibraryContext context) : IRequestHandler<ListBooksQuery, ResultViewModel<IEnumerable<ListBookViewModel>>>
{
    public async Task<ResultViewModel<IEnumerable<ListBookViewModel>>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await context.Books
            .AsNoTrackingWithIdentityResolution()
            .Select(b => new ListBookViewModel
            {
                Book = new BookViewModel
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Pages = b.Pages,
                    Quantity = b.Quantity,
                    Year = b.Year
                },
                Author = new AuthorViewModel
                {
                    Name = b.Author!.Name,
                    Birth = b.Author.Birth,
                    Country = b.Author.Country
                },
                Library = new LibraryUnitViewModel
                {
                    Name = b.Library!.Name,
                    City = b.Library.City
                },
            })
            .ToListAsync(cancellationToken);
        
        return new ResultViewModel<IEnumerable<ListBookViewModel>>(books);
    }
}