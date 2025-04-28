namespace UniversityProject.Data.Helper;

public class ManageUserClaims
{
    public int Userid { get; set; }
    public List<Claim> claims { get; set; }
}
public class UpdateUserClaims
    : ManageUserClaims
{ }
