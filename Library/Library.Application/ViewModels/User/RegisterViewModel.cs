using Library.Domain.Entities.Enums;

namespace Library.Application.ViewModels.User;

public struct RegisterViewModel
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public Role Role { get; init; }
}
