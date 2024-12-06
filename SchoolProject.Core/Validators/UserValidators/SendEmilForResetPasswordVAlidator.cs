namespace UniversityProject.Core.Validators.UserValidators;

public class SendEmilForResetPasswordVAlidator
    : AbstractValidator<SendEmilForResetPassword>
{
    public SendEmilForResetPasswordVAlidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress().WithMessage("{PropertyName} must be valid"); ;
    }
}
