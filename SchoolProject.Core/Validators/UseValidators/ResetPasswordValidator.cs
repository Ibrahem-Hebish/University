namespace SchoolProject.Core.Validators.UseValidators;

public class ResetPasswordValidator
    : AbstractValidator<ResetPassword>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.email)
           .NotEmpty().WithMessage("{PropertyName} must not be empty")
           .NotNull().WithMessage("{PropertyName} must not be null")
           .EmailAddress();

        RuleFor(x => x.password)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.confirmpasswod)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .Equal(x => x.password);
    }
}
