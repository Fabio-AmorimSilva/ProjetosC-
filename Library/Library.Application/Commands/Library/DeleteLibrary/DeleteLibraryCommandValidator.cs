namespace Library.Application.Commands.Library.DeleteLibrary;

public class DeleteLibraryCommandValidator : AbstractValidator<DeleteLibraryCommand>
{
    public DeleteLibraryCommandValidator()
    {
        RuleFor(command => command.LibraryUnitId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteLibraryCommand.LibraryUnitId)));
    }
}