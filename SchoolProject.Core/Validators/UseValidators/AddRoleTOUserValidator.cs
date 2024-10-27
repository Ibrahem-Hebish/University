namespace UniversityProject.Core.Validators.UseValidators;

public class AddRoleTOUserValidator
    : AbstractValidator<AddRoleToUser>
{
    public AddRoleTOUserValidator()
    {
        RuleFor(x => x.username)
           .NotEmpty().WithMessage("{PropertyName} must not be empty")
           .NotNull().WithMessage("{PropertyName} must not be null");

        RuleFor(x => x.role)
            .NotEmpty().WithMessage("{PropertyName} must not be empty")
            .NotNull().WithMessage("{PropertyName} must not be null");
    }
}
