namespace Library.Application.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id should not be empty");
        
        RuleFor(command => command.Title)
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage("Book title be less than 80 characters");

        RuleFor(command => command.Pages)
            .Must(p => p > Book.PagesMinLength)
            .WithMessage("Pages should not be 0");
    }
}