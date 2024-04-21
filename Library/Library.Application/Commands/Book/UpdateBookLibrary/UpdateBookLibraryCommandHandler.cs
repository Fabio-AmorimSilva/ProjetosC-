namespace Library.Application.Commands.Book.UpdateBookLibrary;

public class UpdateBookLibraryCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookLibraryCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await context.Libraries
            .Include(lu => lu.Books)
            .FirstOrDefaultAsync(lu => lu.Id == request.LibraryId, cancellationToken);

        if (library is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        var book = library.GetBook(bookId: request.BookId);
        
        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());
        
        var result = book.UpdateLibrary(request.LibraryId);

        if (!result.Success)
            return new UnprocessableResponse<Unit>(result.Message);

        await context.SaveChangesAsync(cancellationToken);
        
        return new NoContentResponse<Unit>();
    }
}