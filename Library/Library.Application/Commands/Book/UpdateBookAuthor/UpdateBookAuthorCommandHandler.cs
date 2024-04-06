namespace Library.Application.Commands.Book.UpdateBookAuthor;

public class UpdateBookAuthorCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookAuthorCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(UpdateBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorExists = await context.Authors
            .AnyAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (authorExists is false)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        var book = await context.Books
            .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());
        
        var result = book.UpdateAuthor(request.AuthorId);

        if (!result.Success)
            return new ResultViewModel<Unit>(result.Message);
            
        return new ResultViewModel<Unit>();
    }
}