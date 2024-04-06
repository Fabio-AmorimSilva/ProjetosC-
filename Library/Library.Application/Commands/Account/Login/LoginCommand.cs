namespace Library.Application.Commands.Account.Login;

public struct LoginCommand(
    string username,
    string password) : IRequest<string>
{
    public string Username { get; init; } = username;
    public string Password { get; init; } = password;
}