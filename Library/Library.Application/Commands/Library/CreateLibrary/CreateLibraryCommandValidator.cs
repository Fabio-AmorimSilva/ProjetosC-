namespace Library.Application.Commands;

public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
{
    public CreateLibraryCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Name should not be empty");
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage("Name have less than 80 characters");
        
        RuleFor(command => command.City)
            .NotEmpty()
            .WithMessage("City should not be empty");
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage("City have less than 80 characters");
    }
}