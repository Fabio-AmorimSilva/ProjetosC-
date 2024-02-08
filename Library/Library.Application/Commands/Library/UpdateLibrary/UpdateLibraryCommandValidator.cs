using Library.Domain.Messages;

namespace Library.Application.Commands;

public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
{
    public UpdateLibraryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateLibraryCommand.Id)));
        
        RuleFor(command => command.Name)
            .MaximumLength(LibraryUnit.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateLibraryCommand.Name), LibraryUnit.NameMaxLength));
        
        RuleFor(command => command.City)
            .MaximumLength(LibraryUnit.CityMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateLibraryCommand.City), LibraryUnit.CityMaxLength));
    }
}