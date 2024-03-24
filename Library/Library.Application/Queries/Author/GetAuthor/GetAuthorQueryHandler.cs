using Library.Domain.Messages;

namespace Library.Application.Queries;

public class GetAuthorQueryHandler(LibraryContext context) : IRequestHandler<GetAuthorQuery, ResultViewModel<AuthorViewModel>>
{
    public async Task<ResultViewModel<AuthorViewModel>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (author is null)
            return new ResultViewModel<AuthorViewModel>(ErrorMessages.NotFound<Author>());

        return new ResultViewModel<AuthorViewModel>(new AuthorViewModel
        {
            Name = author.Name,
            Country = author.Country,
            Birth = author.Birth
        });
    }
}