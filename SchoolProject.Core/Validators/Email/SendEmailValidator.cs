namespace UniversityProject.Core.Validators.Email;

public class SendEmailValidator
    : AbstractValidator<SendEmailCommand>
{
    public SendEmailValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .NotNull().WithMessage("Email can not be null")
            .EmailAddress().WithMessage("Field must be valid email");

        RuleFor(x => x.message)
            .NotEmpty().WithMessage("message can not be empty")
            .NotNull().WithMessage("message can not be null");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject can not be empty")
            .NotNull().WithMessage("Subject can not be null");
    }
}
