namespace UniversityProject.Core.Validators.UserValidators;

public class ConfirmCodeToResetPasswordValidator
    : AbstractValidator<ConfirmCodeToResetPassword>
{
    public ConfirmCodeToResetPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");
    }
}
