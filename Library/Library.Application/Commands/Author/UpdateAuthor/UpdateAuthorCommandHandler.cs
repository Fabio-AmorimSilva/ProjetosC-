namespace Library.Application.Commands.Author.UpdateAuthor;

public class UpdateAuthorCommandHandler(LibraryContext context) : IRequestHandler<UpdateAuthorCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);
        if (author is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());
        
        var result = author.UpdateAuthor(
            name: request.Name,
            country: author.Country,
            birth: author.Birth
        );

        if (result is { Success: false, Message: not null }) 
            return new UnprocessableResponse<Unit>(result.Message);

        await context.SaveChangesAsync(cancellationToken);
        
        return new NoContentResponse<Unit>();
    }
}