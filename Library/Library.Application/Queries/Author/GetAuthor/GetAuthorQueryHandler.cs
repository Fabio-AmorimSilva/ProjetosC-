namespace Library.Application.Queries.Author.GetAuthor;

public class GetAuthorQueryHandler(LibraryContext context) : IRequestHandler<GetAuthorQuery, ResultResponse<AuthorViewModel>>
{
    public async Task<ResultResponse<AuthorViewModel>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (author is null)
            return new NotFoundResponse<AuthorViewModel>(ErrorMessages.NotFound<Domain.Entities.Author>());

        return new OkResponse<AuthorViewModel>(new AuthorViewModel
        {
            Name = author.Name,
            Country = author.Country,
            Birth = author.Birth
        });
    }
}