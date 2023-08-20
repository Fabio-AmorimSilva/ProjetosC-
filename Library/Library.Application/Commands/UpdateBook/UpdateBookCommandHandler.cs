namespace Library.Application.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateBookCommandHandler(LibraryContext context)
        =>  _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var bookFromDatabase = await _context
            .Books
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (bookFromDatabase is null)
            return new ResultViewModel<Unit>("Book not found.");
        
        bookFromDatabase.UpdateBook(
            title: request.Title, 
            year: request.Year, 
            pages: request.Pages,
            authorId: request.AuthorId, 
            libraryId: request.LibraryId, 
            genre: request.Genre
        );
        
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>("Book has been updated!");
    }
}