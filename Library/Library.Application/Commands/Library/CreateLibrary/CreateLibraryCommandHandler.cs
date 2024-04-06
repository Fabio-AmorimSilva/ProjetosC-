namespace Library.Application.Commands.Library.CreateLibrary;

public class CreateLibraryCommandHandler(LibraryContext context) : IRequestHandler<CreateLibraryCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = new LibraryUnit(
            name: request.Name,
            city: request.City
        );

        await context.Libraries.AddAsync(library, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}