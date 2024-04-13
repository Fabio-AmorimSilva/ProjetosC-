namespace Library.Application.Commands.Book.UpdateBookLibrary;

public class UpdateBookLibraryCommandHandler(LibraryContext context) : IRequestHandler<UpdateBookLibraryCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateBookLibraryCommand request, CancellationToken cancellationToken)
    {
        var libraryExists = await context.Libraries
            .AnyAsync(lu => lu.Id == request.LibraryId, cancellationToken);

        if (libraryExists is false)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        var book = await context.Books
            .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());
        
        var result = book.UpdateLibrary(request.LibraryId);

        if (!result.Success)
            return new UnprocessableResponse<Unit>(result.Message);
        
        return new NoContentResponse<Unit>();
    }
}