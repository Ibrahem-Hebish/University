namespace UniversityProject.Core.Validators.RoleValidators;

public class DeleteRoleValidator
    : AbstractValidator<DeleteRole>
{
    public DeleteRoleValidator()
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("Id can not be empty")
            .NotNull().WithMessage("Id can not be null")
            .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than 0");
    }
}
