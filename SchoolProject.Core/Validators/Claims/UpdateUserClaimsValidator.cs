namespace SchoolProject.Core.Validators.Claims;

public class UpdateUserClaimsValidator
    : AbstractValidator<Updateuserclaims>
{
    public UpdateUserClaimsValidator()
    {
        RuleFor(uc => uc.Userid)
            .NotNull().WithMessage("Id Can not be null")
            .NotEmpty().WithMessage("Id Can not be empty")
            .GreaterThan(0).WithMessage("Id must be grater than zero");

        RuleForEach(uc => uc.claims)
            .ChildRules(claim =>
            {
                claim.RuleFor(c => c.Type)
                    .NotNull().WithMessage("Claim Type cannot be null")
                    .NotEmpty().WithMessage("Claim Type cannot be empty");

                claim.RuleFor(c => c.Value)
                    .NotNull().WithMessage("Claim Value cannot be null")
                    .NotEmpty().WithMessage("Claim Value cannot be empty");
            });
    }
}
