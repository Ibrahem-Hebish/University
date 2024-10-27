namespace UniversityProject.Data.Helper;

public class Manageuserclaims
{
    public int Userid { get; set; }
    public List<Claim> claims { get; set; }
}
public class UpdateUserClaims
    : Manageuserclaims
{ }
