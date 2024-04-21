namespace Library.Application.Commands.Author.CreateAuthor;

public readonly struct CreateAuthorCommand(
    string name, 
    string country, 
    DateTime birth
) : IRequest<ResultResponse<Guid>>
{
    public string Name { get; init; } = name;
    public string Country { get; init; } = country;
    public DateTime Birth { get; init; } = birth;
}