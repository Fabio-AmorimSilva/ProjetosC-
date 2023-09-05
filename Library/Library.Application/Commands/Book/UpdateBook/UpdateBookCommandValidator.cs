namespace Library.Application.Commands;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Id should not be empty");
        
        RuleFor(command => command.Title)
            .MaximumLength(80)
            .WithMessage("Book title be less than 80 characters");

        RuleFor(command => command.Pages)
            .Must(p => p > 0)
            .WithMessage("Pages should not be 0");
    }
}