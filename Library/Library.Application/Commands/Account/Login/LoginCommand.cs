namespace Library.Application.Commands.Account.Login;

public readonly struct LoginCommand(
    string username,
    string password
) : IRequest<ResultResponse<string>>
{
    public string Username { get; init; } = username;
    public string Password { get; init; } = password;
}