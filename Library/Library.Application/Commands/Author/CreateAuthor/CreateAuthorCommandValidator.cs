namespace Library.Application.Commands.Author.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(Domain.Entities.Author.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateAuthorCommand.Name), Domain.Entities.Author.NameMaxLength));
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Country)));
        
        RuleFor(command => command.Country)
            .MaximumLength(Domain.Entities.Author.CountryMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateAuthorCommand.Country), Domain.Entities.Author.CountryMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateAuthorCommand.Birth)));
    }
}