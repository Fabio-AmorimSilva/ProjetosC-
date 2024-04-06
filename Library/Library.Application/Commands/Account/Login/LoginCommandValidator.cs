namespace Library.Application.Commands.Account.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Username)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Username)));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Password)));
    }
}