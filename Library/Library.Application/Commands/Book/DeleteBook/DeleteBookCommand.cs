namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest<ResultResponse<Unit>>
{
    public Guid Id { get; set; } = id;
}