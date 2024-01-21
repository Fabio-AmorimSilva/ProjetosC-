namespace Library.Application.Commands;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Name field is required");
        
        RuleFor(command => command.Name)
            .MaximumLength(Author.AuthorNameMaxLength)
            .WithMessage("Name must be less than 80 characters");
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage("Country is required");
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryNameMaxLength)
            .WithMessage("Country must be less than 80 characters");

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage("Birth Date is required");
    }
}