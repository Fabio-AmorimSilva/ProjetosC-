namespace Library.Application.Commands;

public class CreateAuthorCommand : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; }
    public string Country { get; init; }
    public DateTime Birth { get; init; }

    public CreateAuthorCommand(string name, string country, DateTime birth)
    {
        Name = name;
        Country = country;
        Birth = birth;
    }
}