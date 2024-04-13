namespace Library.Application.Commands.Book.UpdateBook;

public class UpdateBookCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<User>());
        
        var result = book.UpdateBook(
            title: request.Title, 
            year: request.Year, 
            pages: request.Pages,
            authorId: request.AuthorId, 
            libraryId: request.LibraryId, 
            genre: request.Genre
        );

        if (result is { Success: false, Message: not null })
            return new UnprocessableResponse<Unit>(result.Message);
        
        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}