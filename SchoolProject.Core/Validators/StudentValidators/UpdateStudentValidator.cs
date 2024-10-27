namespace UniversityProject.Core.Validators.StudentValidators
{
    public class UpdateStudentStudentValidatation
    : AbstractValidator<UpdateStudent>
    {
        public UpdateStudentStudentValidatation()
        {
            ApplyValidation();

        }
        public void ApplyValidation()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyName} must not be null");
        }
    }

}
