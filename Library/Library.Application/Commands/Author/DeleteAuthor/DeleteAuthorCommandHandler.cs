namespace Library.Application.Commands.Author.DeleteAuthor;

public class DeleteAuthorCommandHandler(LibraryContext context) : IRequestHandler<DeleteAuthorCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
        if (author is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Domain.Entities.Author>());

        context.Authors.Remove(author);
        await context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}