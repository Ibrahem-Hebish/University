namespace UniversityProject.Core.Validators.UserValidators;

public class ResetPasswordValidator
    : AbstractValidator<ResetPassword>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("{PropertyName} must not be empty")
           .NotNull().WithMessage("{PropertyName} must not be null")
           .EmailAddress().WithMessage("{PropertyName} must be valid"); ;

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Confirmpasswod)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .Equal(x => x.Password);
    }
}
