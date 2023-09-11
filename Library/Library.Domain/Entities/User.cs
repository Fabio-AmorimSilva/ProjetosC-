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
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public bool UpdateUser(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            return false;
        
        if (string.IsNullOrEmpty(email))
            return false;

        Name = name;
        Email = email;
        
        return true;
    }

    public void UpdateRole(Role role)
        => Role = role;

    public bool UpdatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        Password = password;

        return true;
    }
}
