using Library.Domain.ErrorMessages;

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

        var authorNameAlreadyExists = await _context.Authors
            .WithSpecification(new AuthorNameAlreadyExistsSpec(author.Id, author.Name))
            .AnyAsync(cancellationToken);

        if (authorNameAlreadyExists)
            return new ResultViewModel<Unit>(ErrorMessages.AlreadyExists(nameof(CreateAuthorCommand.Name)));

        await _context.Authors.AddAsync(author, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}