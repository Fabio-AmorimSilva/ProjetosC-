using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Title)));
        
        RuleFor(command => command.Title)
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Title), Book.TitleMaxLength));

        RuleFor(command => command.Pages)
            .Must(p => p > Book.PagesMinLength)
            .WithMessage(ErrorMessages.HasToBeGreaterThan(nameof(CreateBookCommand.Pages), Book.PagesMinLength));
        
        RuleFor(command => command.Year)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Year)));
        
        RuleFor(command => command.AuthorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.AuthorId)));
        
        RuleFor(command => command.LibraryId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.LibraryId)));
        
        RuleFor(command => command.Genre)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Genre)));
    }
}