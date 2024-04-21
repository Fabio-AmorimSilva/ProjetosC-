namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommandHandler(LibraryContext context) : IRequestHandler<DeleteBookCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookExists = await context.Books
            .AnyAsync(b => b.Id == request.BookId, cancellationToken);

        if (!bookExists)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<Domain.Entities.Book>());

        context.Books.Remove(new Domain.Entities.Book{ Id = request.BookId });
        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse<Unit>();
    }
}