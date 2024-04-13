namespace Library.Application.Commands.Author.CreateAuthor;

public class CreateAuthorCommandHandler(LibraryContext context) : IRequestHandler<CreateAuthorCommand, ResultResponse<Guid>>
{
    public async Task<ResultResponse<Guid>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Domain.Entities.Author(
            name: request.Name,
            country: request.Country,
            birth: request.Birth
        );

        var authorNameAlreadyExists = await context.Authors
            .WithSpecification(new AuthorNameAlreadyExistsSpec(author.Id, author.Name))
            .AnyAsync(cancellationToken);

        if (authorNameAlreadyExists)
            return new ConflictResponse<Guid>(ErrorMessages.AlreadyExists(nameof(CreateAuthorCommand.Name)));

        await context.Authors.AddAsync(author, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new CreatedResponse<Guid>(author.Id);
    }
}