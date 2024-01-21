namespace Library.Application.Commands;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id should not be empty");
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage("Name should have less than 80 characters");
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage("Name should have less than 80 characters");
    }
}