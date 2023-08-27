namespace Library.Application.Commands;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public DeleteAuthorCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (author is null)
            return new ResultViewModel<Unit>("Author not found");

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}