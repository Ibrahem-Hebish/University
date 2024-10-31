namespace UniversityProject.Core.Validators.UserValidators;

public class AddUserValidatation
    : AbstractValidator<AddNewUser>
{
    public AddUserValidatation()
    {
        ApplyValidation();
    }
    public void ApplyValidation()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .MinimumLength(6);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .EmailAddress();

        RuleFor(x => x.ConfirmedPassword)
            .Equal(x => x.Password).WithMessage("ConfirmedPassword must equal password");
    }
}
