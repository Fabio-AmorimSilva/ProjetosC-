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
            .MaximumLength(Author.AuthorNameMaxLength)
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage("");
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryNameMaxLength)
            .WithMessage("");

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage("");
    }
}