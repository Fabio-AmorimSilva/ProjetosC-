namespace Library.Application.Commands;

public class UpdateBookLibraryCommandHandler : IRequestHandler<UpdateBookLibraryCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateBookLibraryCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateBookLibraryCommand request, CancellationToken cancellationToken)
    {
        var libraryExists = await _context.Libraries
            .AnyAsync(lu => lu.Id == request.LibraryId, cancellationToken);

        if (libraryExists is false)
            return new ResultViewModel<Unit>("Library not found");

        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == request.BookId, cancellationToken);

        if (book is null)
            return new ResultViewModel<Unit>("Book not found");
        
        var result = book.UpdateLibrary(request.LibraryId);

        if (!result.Success)
            return new ResultViewModel<Unit>(result.Message);
        
        return new ResultViewModel<Unit>();
    }
}