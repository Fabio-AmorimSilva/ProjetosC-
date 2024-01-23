using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class SignupCommandValidator : AbstractValidator<SignupCommand>
{
    public SignupCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(SignupCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(User.NameMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(SignupCommand.Name), User.NameMaxLength));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(SignupCommand.Password)));
        
        RuleFor(command => command.Password)
            .MaximumLength(User.PasswordMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(SignupCommand.Password), User.PasswordMaxLength));
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(SignupCommand.Name)));
        
        RuleFor(command => command.Role)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(SignupCommand.Role)));
    }
}