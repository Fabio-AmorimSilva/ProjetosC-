namespace Library.Application.Commands;

public struct SignupCommand : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public Role Role { get; init; }

    public SignupCommand(
        string name, 
        string email, 
        string password, 
        Role role
    )
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
}