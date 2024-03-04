using Library.Domain.Messages;

namespace Library.Application.Commands;

public class UpdateBookLibraryCommandValidator : AbstractValidator<UpdateBookLibraryCommand>
{
    public UpdateBookLibraryCommandValidator()
    {
        RuleFor(command => command.LibraryId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookLibraryCommand.LibraryId)));
        
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookLibraryCommand.BookId)));
    }
}