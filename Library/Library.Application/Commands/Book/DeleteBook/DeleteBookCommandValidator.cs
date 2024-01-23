using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(DeleteBookCommand.Id)));
    }
}