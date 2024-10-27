namespace UniversityProject.Infrustructure.Seeder;

public class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<Role> rolemanager)
    {
        var RolesCount = await rolemanager.Roles.CountAsync();

        if (RolesCount <= 0)
        {
            var Roles = new List<Role>()
            {
                new(){Name = "Admin"},
                new(){Name = "SuperAdmin"},
                new(){Name = "User"}
            };

            await rolemanager.CreateAsync(Roles[0]);

            await rolemanager.CreateAsync(Roles[1]);

            await rolemanager.CreateAsync(Roles[2]);
        }
    }

}
