namespace SchoolProject.Core.Validators.Custom;

public class GreaterthanAttribute
    : ValidationAttribute
{
    public int _Num { get; set; }
    public GreaterthanAttribute(int num)
    {
        _Num = num;
    }
    public override bool IsValid(object? Value)
    {
        var number = (int?)Value;

        if (number <= 0)
            return false;

        return true;
    }
}
