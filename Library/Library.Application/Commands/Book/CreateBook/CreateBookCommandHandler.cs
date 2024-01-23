namespace Library.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ResultViewModel<Guid>>
{
    private readonly LibraryContext _context;

    public CreateBookCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(
            title: request.Title,
            year: request.Year,
            pages: request.Pages,
            request.AuthorId,
            request.LibraryId,
            genre: request.Genre
        );

        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Guid>(book.Id);
    }
}