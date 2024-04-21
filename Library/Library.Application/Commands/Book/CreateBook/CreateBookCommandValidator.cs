namespace Library.Application.Commands.Book.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Title)));
        
        RuleFor(command => command.Title)
            .MaximumLength(Domain.Entities.Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookCommand.Title), Domain.Entities.Book.TitleMaxLength));

        RuleFor(command => command.Pages)
            .Must(p => p > Domain.Entities.Book.PagesMinLength)
            .WithMessage(ErrorMessages.HasToBeGreaterThan(nameof(CreateBookCommand.Pages), Domain.Entities.Book.PagesMinLength));
        
        RuleFor(command => command.Year)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Year)));
        
        RuleFor(command => command.AuthorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.AuthorId)));
        
        RuleFor(command => command.Genre)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookCommand.Genre)));
    }
}