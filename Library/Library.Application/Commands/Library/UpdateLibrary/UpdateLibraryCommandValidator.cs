namespace Library.Application.Commands.Library.UpdateLibrary;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(command => command.LibraryUnitId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateLibraryCommand.LibraryUnitId)));
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateLibraryCommand.Name), LibraryUnit.NameMaxLength));
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateLibraryCommand.City), LibraryUnit.CityMaxLength));
    }
}