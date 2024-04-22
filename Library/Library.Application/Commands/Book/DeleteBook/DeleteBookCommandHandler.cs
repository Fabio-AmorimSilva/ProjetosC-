namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommandHandler(LibraryContext context) : IRequestHandler<DeleteBookCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (author is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        var book = author.GetBook(bookId: request.BookId);
        
        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());

        author.DeleteBook(book: book);
        
        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}