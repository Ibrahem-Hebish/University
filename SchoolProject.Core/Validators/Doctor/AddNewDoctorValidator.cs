namespace UniversityProject.Core.Validators.Doctor;

public class AddNewDoctorValidator : AbstractValidator<AddNewDoctor>
{
    public AddNewDoctorValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("{PropertyName} must not be empty")
          .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.DepartmentID)
            .GreaterThan(0).WithMessage("{PropertyName} must not be null");

    }
}
