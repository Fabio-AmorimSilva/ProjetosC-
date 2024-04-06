namespace Library.Application.Commands.Author.UpdateAuthor;

public class UpdateAuthorCommandHandler(LibraryContext context) : IRequestHandler<UpdateAuthorCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (author is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());
        
        var result = author.UpdateAuthor(
            name: request.Name,
            country: author.Country,
            birth: author.Birth
        );

        if (result is { Success: false, Message: not null }) 
            return new ResultViewModel<Unit>(result.Message);

        await context.SaveChangesAsync(cancellationToken);
        
        return new ResultViewModel<Unit>();
    }
}