using Library.Domain.Messages;

namespace Library.Application.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookCommand.Title)));
        
        RuleFor(command => command.Title)
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Title), Book.TitleMaxLength));

        RuleFor(command => command.Pages)
            .Must(p => p > Book.PagesMinLength)
            .WithMessage(ErrorMessages.HasToBeGreaterThan(nameof(CreateBookCommand.Pages), Book.PagesMinLength));
    }
}