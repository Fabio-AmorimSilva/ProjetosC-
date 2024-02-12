using Library.Domain.Messages;

namespace Library.Application.Queries;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ResultViewModel<AuthorViewModel>>
{
    private readonly LibraryContext _context;

    public GetAuthorQueryHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<AuthorViewModel>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors
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