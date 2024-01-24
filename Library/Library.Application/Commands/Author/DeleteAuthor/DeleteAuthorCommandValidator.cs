using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteAuthorCommand.Id)));
    }
}