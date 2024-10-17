namespace SchoolProject.Core.Validators.StudentValidators;

public class AddStudentValidatation
    : AbstractValidator<AddStudennt>
{
    public AddStudentValidatation()
    {
        ApplyValidation();

    }
    public void ApplyValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Subjects)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.DepId)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }
}
