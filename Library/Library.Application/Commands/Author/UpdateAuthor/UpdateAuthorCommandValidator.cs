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
            .MaximumLength(Author.NameMaxLength)
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryMaxLength)
            .WithMessage("");

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage("");
    }
}