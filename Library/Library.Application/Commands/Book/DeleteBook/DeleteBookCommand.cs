namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; set; } = id;
}