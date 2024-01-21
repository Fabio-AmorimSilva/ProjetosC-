namespace Library.Application.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage("Book title should not be empty");
        
        RuleFor(command => command.Title)
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage("Book title be less than 80 characters");

        RuleFor(command => command.Pages)
            .Must(p => p > Book.PagesMinLength)
            .WithMessage("Pages should not be 0");
        
        RuleFor(command => command.Year)
            .NotEmpty()
            .WithMessage("Year should not be empty");
        
        RuleFor(command => command.AuthorId)
            .NotEmpty()
            .WithMessage("Author should not be empty");
        
        RuleFor(command => command.LibraryId)
            .NotEmpty()
            .WithMessage("Library should not be empty");
        
        RuleFor(command => command.Genre)
            .NotEmpty()
            .WithMessage("Genre should not be empty");
    }
}