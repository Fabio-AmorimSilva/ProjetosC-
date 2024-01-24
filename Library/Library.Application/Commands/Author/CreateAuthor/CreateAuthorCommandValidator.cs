using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(Author.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateAuthorCommand.Name), Author.NameMaxLength));
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Country)));
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateAuthorCommand.Country), Author.CountryMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Birth)));
    }
}