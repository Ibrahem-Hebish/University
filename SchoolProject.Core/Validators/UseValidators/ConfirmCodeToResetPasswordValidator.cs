namespace SchoolProject.Core.Validators.UseValidators;

public class ConfirmCodeToResetPasswordValidator
    : AbstractValidator<ConfirmCodeToResetPassword>
{
    public ConfirmCodeToResetPasswordValidator()
    {
        RuleFor(x => x.email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();

        RuleFor(x => x.code)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");
    }
}
