namespace Library.Application.Commands.Author.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteAuthorCommand.Id)));
    }
}