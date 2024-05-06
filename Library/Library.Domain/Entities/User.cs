using Library.Core.Entities;
using Library.Core.ErrorHandling;
using Library.Core.Messages;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
    public const int NameMaxLength = 80;
    public const int EmailMaxLength = 80;
    public const int PasswordMaxLength = 256;
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }

    public User(
        string name, 
        string email,  
        Role role
    )
    {
        Guard.HasSizeLessThan(name, NameMaxLength, nameof(name));
        Guard.HasSizeLessThan(email, EmailMaxLength, nameof(email));
        
        Name = name;
        Email = email;
        Role = role;
    }

    public void SetPassword(string password)
        => Password = password;
    
    public Result UpdateUser(string name, string email)
    {
        if (string.IsNullOrEmpty(name))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(name)));

        if (name.Length > NameMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(name), NameMaxLength));
        
        if (string.IsNullOrEmpty(email))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(email)));

        Name = name;
        Email = email;
        
        return Result.SuccessResult();
    }

    public void UpdateRole(Role role)
        => Role = role;

    public Result UpdatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return Result.FailureResult(ErrorMessages.CannotBeEmpty(nameof(password)));

        if (password.Length > PasswordMaxLength)
            return Result.FailureResult(ErrorMessages.HasMaxLength(nameof(password), PasswordMaxLength));
        
        Password = password;

        return Result.SuccessResult();
    }
}
