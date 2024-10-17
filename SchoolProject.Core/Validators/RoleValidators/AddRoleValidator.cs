namespace SchoolProject.Core.Validators.RoleValidators;

public class AddRoleValidator
    : AbstractValidator<AddRoleCommand>
{
    private readonly IRoleServices _roleServices;
    public AddRoleValidator(IRoleServices roleServices)
    {
        RoleValidation();

        CustomValidation();

        _roleServices = roleServices;
    }
    public void RoleValidation()
    {
        RuleFor(x => x.name)
            .NotEmpty().WithMessage("Name can not be empty")
            .NotNull().WithMessage("Name can not be null");
    }
    public void CustomValidation()
    {
        RuleFor(r => r.name)
            .MustAsync(async (key, cancilationtoken) => !await _roleServices.IsExsist(key))
            .WithMessage("RoleName exsists");
    }
}
