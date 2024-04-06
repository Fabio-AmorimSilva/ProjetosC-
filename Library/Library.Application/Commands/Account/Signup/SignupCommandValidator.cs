namespace Library.Application.Commands.Account.Signup;

public class SignupCommandValidator : AbstractValidator<SignupCommand>
{
    public SignupCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(SignupCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(User.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(SignupCommand.Name), User.NameMaxLength));
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(SignupCommand.Password)));
        
        RuleFor(command => command.Password)
            .MaximumLength(User.PasswordMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(SignupCommand.Password), User.PasswordMaxLength));
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(SignupCommand.Name)));
        
        RuleFor(command => command.Role)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(SignupCommand.Role)));
    }
}