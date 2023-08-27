namespace Library.Application.Commands;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public CreateAuthorCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author(
            name: request.Name,
            country: request.Country,
            birth: request.Birth
        );

        await _context.Authors.AddAsync(author, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}