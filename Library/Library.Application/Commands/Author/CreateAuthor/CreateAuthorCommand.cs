namespace Library.Application.Commands.Author.CreateAuthor;

public class CreateAuthorCommand(
    string name, 
    string country, 
    DateTime birth
) : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; } = name;
    public string Country { get; init; } = country;
    public DateTime Birth { get; init; } = birth;
}