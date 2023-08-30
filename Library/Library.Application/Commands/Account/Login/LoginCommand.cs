namespace Library.Application.Commands;

public struct LoginCommand : IRequest<string>
{
    public string Username { get; init; }
    public string Password { get; init; }

    public LoginCommand(
        string username, 
        string password
    )
    {
        Username = username;
        Password = password;
    }
}