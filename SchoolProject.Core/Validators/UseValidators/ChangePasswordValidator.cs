namespace SchoolProject.Core.Validators.UseValidators;

public class ChangePasswordValidator
    : AbstractValidator<ChangePassword>
{
    public ChangePasswordValidator()
    {
        ApplyValidation();
    }
    public void ApplyValidation()
    {
        RuleFor(x => x._email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();

        RuleFor(x => x._password)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .MinimumLength(8);

        RuleFor(x => x._newpassword)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .MinimumLength(6);

        RuleFor(x => x._confirmnewpassword)
            .Equal(x => x._confirmnewpassword).WithMessage("ConfirmedPassword must equal password");
    }
}
