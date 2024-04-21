namespace Library.Application.Commands.Author.UpdateAuthor;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(command => command.AuthorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.AuthorId)));
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Name)));
        
        RuleFor(command => command.Name)
            .MaximumLength(Domain.Entities.Author.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Domain.Entities.Author.NameMaxLength));
        
        RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Country)));
        
        RuleFor(command => command.Country)
            .MaximumLength(Domain.Entities.Author.CountryMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateAuthorCommand.Country), Domain.Entities.Author.CountryMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateAuthorCommand.Birth)));
    }
}