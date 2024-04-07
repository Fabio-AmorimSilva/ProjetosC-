namespace Library.Application.Commands.Library.CreateLibrary;

public class CreateLibraryCommandHandler(LibraryContext context) : IRequestHandler<CreateLibraryCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = new LibraryUnit(
            name: request.Name,
            city: request.City
        );

        await context.Libraries.AddAsync(library, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new ResultResponse<Unit>();
    }
}