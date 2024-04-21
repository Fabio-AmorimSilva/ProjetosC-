namespace Library.Application.Commands.Library.UpdateLibrary;

public class UpdateLibraryCommandHandler(LibraryContext context) : IRequestHandler<UpdateLibraryCommand, ResultResponse<Unit>>
{
    public async Task<ResultResponse<Unit>> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await context.Libraries.FirstOrDefaultAsync(l => l.Id == request.LibraryUnitId, cancellationToken);
        if (library is null)
            return new NotFoundResponse<Unit>(ErrorMessages.NotFound<LibraryUnit>());

        var result = library.UpdateLibrary(
            name: request.Name,
            city: request.City
        );

        if (!result.Success)
            return new UnprocessableResponse<Unit>(result.Message);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return new NoContentResponse<Unit>();
    }
}