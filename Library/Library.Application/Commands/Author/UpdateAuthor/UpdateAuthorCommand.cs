namespace Library.Application.Commands.Author.UpdateAuthor;

public readonly struct UpdateAuthorCommand(
    Guid authorId, 
    string name, 
    string country, 
    DateTime birth
) : IRequest<ResultResponse<Unit>>
{
    public Guid AuthorId { get; init; } = authorId;
    public string Name { get; init; } = name;
    public string Country { get; init; } = country;
    public DateTime Birth { get; init; } = birth;
}