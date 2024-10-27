namespace UniversityProject.Core.Validators.UseValidators;

public class SendEmilForResetPasswordVAlidator
    : AbstractValidator<SendEmilForResetPassword>
{
    public SendEmilForResetPasswordVAlidator()
    {
        RuleFor(x => x.email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();
    }
}
