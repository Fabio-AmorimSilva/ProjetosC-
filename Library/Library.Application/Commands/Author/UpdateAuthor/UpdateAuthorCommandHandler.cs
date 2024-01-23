using Library.Domain.Entities.ErrorHandling;
using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateAuthorCommandHandler(LibraryContext context)
        =>  _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (author is null)
            return new ResultViewModel<Unit>(Messages.NotFound<Author>());
        
        var result = author.UpdateAuthor(
            name: request.Name,
            country: author.Country,
            birth: author.Birth
        );

        if (!result.Success)
            return new ResultViewModel<Unit>(result.Message);

        await _context.SaveChangesAsync(cancellationToken);
        
        return new ResultViewModel<Unit>();
    }
}