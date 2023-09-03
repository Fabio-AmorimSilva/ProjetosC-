namespace Library.Application.Commands;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("");
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("");
        
        RuleFor(command => command.Name)
            .MaximumLength(80)
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .MaximumLength(80)
            .WithMessage("");

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage("");
    }
}