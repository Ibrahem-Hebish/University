namespace UniversityProject.Core.Validators.TeachingAssistant;

internal class AddTeachingAssistantValidator : AbstractValidator<AddTeachingAssistant>
{
    public AddTeachingAssistantValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("{PropertyName} must not be empty")
          .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.DepartmentID)
            .GreaterThan(0).WithMessage("{PropertyName} must not be null");

    }
}
