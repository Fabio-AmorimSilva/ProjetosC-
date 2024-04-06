﻿namespace Library.Application.Commands.Account.Signup;

public struct SignupCommand(
    string name,
    string email,
    string password,
    Role role)
    : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; } = name;
    public string Email { get; init; } = email;
    public string Password { get; init; } = password;
    public Role Role { get; init; } = role;
}