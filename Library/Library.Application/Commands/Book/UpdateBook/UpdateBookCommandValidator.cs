using Library.Application.Commands.Book.CreateBook;

namespace Library.Application.Commands.Book.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.BookId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Title)));
        
        RuleFor(command => command.Title)
            .MaximumLength(Domain.Entities.Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Title), Domain.Entities.Book.TitleMaxLength));

        RuleFor(command => command.Pages)
            .Must(p => p > Domain.Entities.Book.PagesMinLength)
            .WithMessage(ErrorMessages.HasToBeGreaterThan(nameof(CreateBookCommand.Pages), Domain.Entities.Book.PagesMinLength));
    }
}