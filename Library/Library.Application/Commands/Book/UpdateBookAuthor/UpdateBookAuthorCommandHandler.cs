namespace Library.Application.Commands.Book.UpdateBookAuthor;

public class UpdateBookAuthorCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookAuthorCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorExists = await context.Authors
            .AnyAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (authorExists is false)
            return new ResultResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        var book = await context.Books
            .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return new ResultResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());
        
        var result = book.UpdateAuthor(request.AuthorId);

        if (!result.Success)
            return new ResultResponse<Unit>(result.Message);
            
        return new NoContentResponse<Unit>();
    }
}