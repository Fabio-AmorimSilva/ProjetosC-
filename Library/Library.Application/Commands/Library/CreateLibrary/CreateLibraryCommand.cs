namespace Library.Application.Commands;

public struct CreateLibraryCommand : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; }
    public string City { get; init; }

    public CreateLibraryCommand(string name, string city)
    {
        Name = name;
        City = city;
    }
}