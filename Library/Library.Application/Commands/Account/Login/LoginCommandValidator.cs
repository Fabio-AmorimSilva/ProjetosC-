using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Username)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(LoginCommand.Username)));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(LoginCommand.Password)));
    }
}