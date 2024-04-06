namespace Library.Application.Commands.Book.CreateBook;

public class CreateBookCommandHandler(LibraryContext context) : IRequestHandler<CreateBookCommand, ResultViewModel<Guid>>
{
    public async Task<ResultViewModel<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Domain.Entities.Book(
            title: request.Title,
            year: request.Year,
            pages: request.Pages,
            request.AuthorId,
            request.LibraryId,
            genre: request.Genre
        );

        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Guid>(book.Id);
    }
}