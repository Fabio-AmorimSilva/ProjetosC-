namespace Library.Application.Commands.Book.UpdateBookAuthor;

public class UpdateBookAuthorCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookAuthorCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (author is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        var book = author.GetBook(bookId: request.BookId);
            
        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());
        
        var result = book.UpdateAuthor(request.AuthorId);

        if (!result.Success)
            return new UnprocessableResponse<Unit>(result.Message);

        await context.SaveChangesAsync(cancellationToken);
            
        return new NoContentResponse<Unit>();
    }
}