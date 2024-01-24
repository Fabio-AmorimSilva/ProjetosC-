using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteBookCommand.Id)));
    }
}