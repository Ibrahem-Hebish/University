

namespace SchoolProject.Infrustructure.Seeder;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        var UsersCount = await userManager.Users.CountAsync();

        if (UsersCount <= 0)
        {
            var user = new User()
            {
                UserName = "Ibrahem",

                Email = "Ibrahem@gmail.com",

                Address = "Elmahalla",

                Country = "Egypt",

                PhoneNumber = "1234567890",

                EmailConfirmed = true,

                PhoneNumberConfirmed = true,
            };

            var User = await userManager.CreateAsync(user, "Ibrahem123");

            if (User.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim("Create", "true"));

                await userManager.AddClaimAsync(user, new Claim("Get", "true"));

                await userManager.AddClaimAsync(user, new Claim("Update", "true"));

                await userManager.AddClaimAsync(user, new Claim("Delete", "true"));

                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "SuperAdmin"));

                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));

                var Claims = new List<Claim>
              {
                 new (ClaimTypes.NameIdentifier,user.Email!),
                 new (ClaimTypes.Name,user.UserName!),
                 new (ClaimTypes.Country,user.Country??"Unknown")
              };

                await userManager.AddClaimsAsync(user, Claims);

                await userManager.AddToRoleAsync(user, "SuperAdmin");

                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
