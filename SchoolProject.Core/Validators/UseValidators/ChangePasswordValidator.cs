namespace UniversityProject.Core.Validators.UseValidators;

public class ChangePasswordValidator
    : AbstractValidator<ChangePassword>
{
    public ChangePasswordValidator()
    {
        ApplyValidation();
    }
    public void ApplyValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .MinimumLength(8);

        RuleFor(x => x.Newpassword)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .MinimumLength(6);

        RuleFor(x => x.Confirmnewpassword)
            .Equal(x => x.Confirmnewpassword).WithMessage("ConfirmedPassword must equal password");
    }
}
