namespace UniversityProject.Core.Validators.SigningInValidators;

public class TokenValidator
    : AbstractValidator<RefreshTokenDto>
{
    public TokenValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty().WithMessage("Access Token can not be empty")
            .NotNull().WithMessage("Access Token can not be null");

        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("Refresh Token can not be empty")
            .NotNull().WithMessage("Refresh Token can not be null");
    }
}
