namespace UniversityProject.Core.Validators.Custom;

public class NotEmptyAttribute
    : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? Value, ValidationContext validationContext)
    {
        var val = Value as string;

        if (val.IsNullOrEmpty() || String.IsNullOrWhiteSpace(val))
            return new ValidationResult("This Field can not be null or empty");

        return ValidationResult.Success;
    }
}
