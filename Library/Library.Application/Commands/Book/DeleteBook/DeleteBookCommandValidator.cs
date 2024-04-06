namespace Library.Application.Commands.Book.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteBookCommand.Id)));
    }
}