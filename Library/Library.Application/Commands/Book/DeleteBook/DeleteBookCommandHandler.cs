namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommandHandler(LibraryContext context) : IRequestHandler<DeleteBookCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookExists = await context.Books
            .AnyAsync(b => b.Id == request.Id, cancellationToken);

        if (!bookExists)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());

        context.Books.Remove(new Domain.Entities.Book{ Id = request.Id });
        await context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>("Book has been deleted");
    }
}