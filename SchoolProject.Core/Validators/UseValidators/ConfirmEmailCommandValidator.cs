namespace UniversityProject.Core.Validators.UseValidators;

public class ConfirmEmailCommandValidator
    : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(x => x.Code)
          .NotEmpty().WithMessage("{PropertyName} must not be empty")
          .NotNull().WithMessage("{PropertyName} must not be null");
    }
}
