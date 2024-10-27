namespace UniversityProject.Core.Validators.Email;

public class SendEmailValidator
    : AbstractValidator<SendEmailCommand>
{
    public SendEmailValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .NotNull().WithMessage("Email can not be null");

        RuleFor(x => x.message)
            .NotEmpty().WithMessage("message can not be empty")
            .NotNull().WithMessage("message can not be null");

        RuleFor(x => x.subject)
            .NotEmpty().WithMessage("subject can not be empty")
            .NotNull().WithMessage("subject can not be null");
    }
}
