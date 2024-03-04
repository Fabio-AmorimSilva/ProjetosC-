using Library.Domain.Messages;

namespace Library.Application.Commands;

public class UpdateBookAuthorCommandValidator : AbstractValidator<UpdateBookAuthorCommand>
{
    public UpdateBookAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookAuthorCommand.AuthorId)));
        
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookAuthorCommand.BookId)));
    }
}