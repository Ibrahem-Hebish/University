namespace UniversityProject.Core.Validators.UserValidators;

public class AddRoleTOUserValidator
    : AbstractValidator<AddRoleToUser>
{
    public AddRoleTOUserValidator()
    {
        RuleFor(x => x.Username)
           .NotEmpty().WithMessage("{PropertyName} must not be empty")
           .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");
    }
}
