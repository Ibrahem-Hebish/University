namespace UniversityProject.Core.Validators.Custom;

public class GreaterthanAttribute(int num)
        : ValidationAttribute
{

    public override bool IsValid(object? Value)
    {
        var number = (int?)Value;

        if (number is null)
            return false;

        if (number <= num)
            return false;

        return true;
    }
}
