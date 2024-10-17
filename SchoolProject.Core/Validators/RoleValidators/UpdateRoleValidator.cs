namespace SchoolProject.Core.Validators.RoleValidators;

public class UpdateRoleValidator
    : AbstractValidator<UpdateRole>
{
    public UpdateRoleValidator()
    {
        RuleFor(x => x.currentName)
            .NotEmpty().WithMessage("currentName can not be empty")
            .NotNull().WithMessage("currentName can not be null");

        RuleFor(x => x.newName)
            .NotEmpty().WithMessage("newName can not be empty")
            .NotNull().WithMessage("newName can not be null");
    }
}
