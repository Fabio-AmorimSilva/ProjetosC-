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

    public Result UpdateUser(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            return Result.FailureResult("Name cannot be empty");
        
        if (string.IsNullOrEmpty(email))
            return Result.FailureResult("Email cannot be empty");

        Name = name;
        Email = email;
        
        return Result.SuccessResult();
    }

    public void UpdateRole(Role role)
        => Role = role;

    public Result UpdatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return Result.FailureResult("Password cannot be empty");

        Password = password;

        return Result.SuccessResult();
    }
}
