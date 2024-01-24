using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateBookAuthorCommandHandler : IRequestHandler<UpdateBookAuthorCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateBookAuthorCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorExists = await _context.Authors
            .AnyAsync(a => a.Id == request.AuthorId, cancellationToken);

        if (authorExists is false)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Author>());

        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Book>());
        
        var result = book.UpdateAuthor(request.AuthorId);

        if (!result.Success)
            return new ResultViewModel<Unit>(result.Message);
            
        return new ResultViewModel<Unit>();
    }
}