namespace Library.Application.Commands;

public class SignupCommandValidator : AbstractValidator<SignupCommand>
{
    public SignupCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");
        
        RuleFor(command => command.Name)
            .MaximumLength(80)
            .WithMessage("Name has to be less than 80 characters");
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty");
        
        RuleFor(command => command.Password)
            .MaximumLength(256)
            .WithMessage("Password has to be less than 256 characters");
        
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty");
        
        RuleFor(command => command.Role)
            .NotEmpty()
            .WithMessage("Role cannot be empty");
    }
}