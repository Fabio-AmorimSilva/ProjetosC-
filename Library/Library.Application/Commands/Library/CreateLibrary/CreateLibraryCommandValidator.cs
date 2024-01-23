using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class CreateLibraryCommandValidator : AbstractValidator<CreateLibraryCommand>
{
    public CreateLibraryCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(CreateLibraryCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(CreateLibraryCommand.Name), LibraryUnit.NameMaxLength));
        
        RuleFor(command => command.City)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(CreateLibraryCommand.City)));
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(CreateLibraryCommand.City), LibraryUnit.CityMaxLength));
    }
}