namespace SchoolProject.Data.Helper;

public static class SystemClaims
{
    public static List<SystemClaim> GetSystemClaims()
    {
        return
        [
            new() { Id = 1, Type = "Get" },
            new() { Id = 2, Type = "Create" },
            new() { Id = 3, Type = "Update" },
            new() { Id = 4, Type = "Delete" }
        ];
    }
}
