namespace Library.Application.Commands.Library.CreateLibrary;

public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
{
    public CreateLibraryCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateLibraryCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateLibraryCommand.Name), LibraryUnit.NameMaxLength));
        
        RuleFor(command => command.City)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateLibraryCommand.City)));
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateLibraryCommand.City), LibraryUnit.CityMaxLength));
    }
}