namespace SchoolProject.Core.Validators.SigningInValidators;

public class SignInValidator
    : AbstractValidator<SignIn>
{
    public SignInValidator()
    {
        RuleFor(s => s.UserName)
            .NotEmpty().WithMessage("Username can not be empty")
            .NotNull().WithMessage("Username can not be empty");

        RuleFor(s => s.Password)
            .NotEmpty().WithMessage("Password can not be empty")
            .NotNull().WithMessage("Password can not be empty");

    }
}
