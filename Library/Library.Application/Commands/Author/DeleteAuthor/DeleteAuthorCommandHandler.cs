namespace Library.Application.Commands.Author.DeleteAuthor;

public class DeleteAuthorCommandHandler(LibraryContext context) : IRequestHandler<DeleteAuthorCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);
        if (author is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        context.Authors.Remove(author);
        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}