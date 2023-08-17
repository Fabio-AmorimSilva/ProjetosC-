using Library.Infrastructure;

namespace Library.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ResultViewModel<Guid>>
{
    public readonly LibraryContext _context;

    public CreateBookCommandHandler(LibraryContext context)
        => _context = context;
    
    public Task<ResultViewModel<Guid>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}