using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class DeleteLibraryCommandValidator : AbstractValidator<DeleteLibraryCommand>
{
    public DeleteLibraryCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(DeleteLibraryCommand.Id)));
    }
}