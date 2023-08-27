namespace Library.Application.Commands;

public struct UpdateAuthorCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Country { get; init; }
    public DateTime Birth { get; init; }

    public UpdateAuthorCommand(Guid id, string name, string country, DateTime birth)
    {
        Id = id;
        Name = name;
        Country = country;
        Birth = birth;
    }
}