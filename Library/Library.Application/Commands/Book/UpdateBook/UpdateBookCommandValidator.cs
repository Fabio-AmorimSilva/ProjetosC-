using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateBookCommand.Title)));
        
        RuleFor(command => command.Title)
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(CreateBookCommand.Title), Book.TitleMaxLength));

        RuleFor(command => command.Pages)
            .Must(p => p > Book.PagesMinLength)
            .WithMessage(Messages.HasToBeGreaterThan(nameof(CreateBookCommand.Pages), Book.PagesMinLength));
    }
}