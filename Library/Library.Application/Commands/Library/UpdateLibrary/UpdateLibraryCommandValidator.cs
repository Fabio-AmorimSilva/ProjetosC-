using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateLibraryCommand.Id)));
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(UpdateLibraryCommand.Name), LibraryUnit.NameMaxLength));
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(UpdateLibraryCommand.City), LibraryUnit.CityMaxLength));
    }
}