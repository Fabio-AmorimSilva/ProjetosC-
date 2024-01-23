using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateAuthorCommand.Id)));
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateAuthorCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(Author.NameMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Author.NameMaxLength));
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateAuthorCommand.Country)));
        
        RuleFor(command => command.Country)
            .MaximumLength(Author.CountryMaxLength)
            .WithMessage(Messages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Author.CountryMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(Messages.CannotBeEmpty(nameof(UpdateAuthorCommand.Birth)));
    }
}