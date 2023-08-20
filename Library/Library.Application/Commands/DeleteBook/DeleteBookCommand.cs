namespace Library.Application.Commands;

public class DeleteBookCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; set; }

    public DeleteBookCommand(Guid id)
        =>  Id = id;
}