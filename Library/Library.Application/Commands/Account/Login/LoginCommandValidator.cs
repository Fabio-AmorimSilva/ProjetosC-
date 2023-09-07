namespace Library.Application.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Username)
            .NotEmpty()
            .WithMessage("Username cannot be empty");
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty");
    }
}