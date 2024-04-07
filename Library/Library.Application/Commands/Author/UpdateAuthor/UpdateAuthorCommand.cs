namespace Library.Application.Commands.Author.UpdateAuthor;

public readonly struct UpdateAuthorCommand(
    Guid id, 
    string name, 
    string country, 
    DateTime birth
) : IRequest<ResultResponse<Unit>>
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Country { get; init; } = country;
    public DateTime Birth { get; init; } = birth;
}