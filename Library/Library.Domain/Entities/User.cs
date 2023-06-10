using Library.Domain.Entities.Core;
using Library.Domain.Entities.Enums;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public User(
        string name, 
        string email, 
        string password, 
        Role role)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = null;

        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
}
