namespace Library.Application.Commands.Library.DeleteLibrary;

public class DeleteLibraryCommandValidator : AbstractValidator<DeleteLibraryCommand>
{
    public DeleteLibraryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteLibraryCommand.Id)));
    }
}