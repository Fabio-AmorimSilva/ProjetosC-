namespace Library.Application.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public DeleteBookCommandHandler(LibraryContext context)
        =>  _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookExists = await _context
            .Books
            .AnyAsync(b => b.Id == request.Id, cancellationToken);

        if (!bookExists)
            return new ResultViewModel<Unit>("Book not found");

        _context.Books.Remove(new Book{ Id = request.Id });
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>("Book has been deleted");
    }
}