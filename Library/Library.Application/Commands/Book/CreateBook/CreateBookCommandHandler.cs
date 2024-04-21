namespace Library.Application.Commands.Book.CreateBook;

public class CreateBookCommandHandler(LibraryContext context) : IRequestHandler<CreateBookCommand, ResultResponse<Guid>>
{
    public async Task<ResultResponse<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (author is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Domain.Entities.Author>());
        
        var book = new Domain.Entities.Book(
            title: request.Title,
            year: request.Year,
            pages: request.Pages,
            genre: request.Genre
        );
        
        author.AddBook(book);

        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new CreatedResponse<Guid>(book.Id);
    }
}