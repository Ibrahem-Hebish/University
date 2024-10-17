namespace SchoolProject.Core.Validators.RoleValidators;

public class GetRoleValidator
    : AbstractValidator<GetRole>
{
    public GetRoleValidator()
    {
        RuleFor(x => x.id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null")
           .GreaterThanOrEqualTo(1).WithMessage("Id must be greater than 0");
    }
}
