using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Id)));
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(Author.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Author.NameMaxLength));
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Country)));
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Author.CountryMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Birth)));
    }
}