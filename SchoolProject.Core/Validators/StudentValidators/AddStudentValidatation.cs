namespace UniversityProject.Core.Validators.StudentValidators;

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

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.DepId)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Level)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .LessThan(5).WithMessage("{PropertyName} must be less than 5");

        RuleFor(x => x.Term)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0")
            .LessThan(3).WithMessage("{PropertyName} must be 1 or 2");
    }
}
