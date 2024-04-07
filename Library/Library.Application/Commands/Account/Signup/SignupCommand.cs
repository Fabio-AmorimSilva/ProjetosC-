namespace Library.Application.Commands.Account.Signup;

public readonly struct SignupCommand(
    string name,
    string email,
    string password,
    Role role)
    : IRequest<ResultResponse<Guid>>
{
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public Role Role { get; init; } = role;
}