namespace UniversityProject.Core.CQSR.Handlers.AuthonticationHandler;

public class ConfirmEmailHandler(UserManager<User> userManager)
        : ResponseHandler,
    IRequestHandler<ConfirmEmailCommand, Response<string>>
{
    public async Task<Response<string>> Handle(
        ConfirmEmailCommand request
        , CancellationToken cancellationToken)
    {
        var user = TemporaryUserStore.Users.LastOrDefault();

        var password = TemporaryUserStore.Passwords.LastOrDefault();

        if (user is null) return BadRequest<string>("User is not found");

        if (password is null) return BadRequest<string>("User is not found");

        user.EmailConfirmed = true;

        var NewUser = await userManager.CreateAsync(user, password);

        if (NewUser.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");

            await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypes.Role, "User"));

            var Claims = new List<System.Security.Claims.Claim>
              {
                 new System.Security.Claims.Claim(ClaimTypes.NameIdentifier,user.Email!),
                 new System.Security.Claims.Claim(ClaimTypes.Name,user.UserName!),
                 new System.Security.Claims.Claim(ClaimTypes.Country,user.Country??"Unknown")
              };

            await userManager.AddClaimsAsync(user, Claims);


            TemporaryUserStore.Users.Clear();

            TemporaryUserStore.Passwords.Clear();

            return NoContent<string>("Email Confirmed");
        }

        return BadRequest<string>(NewUser.Errors.First().Description);
    }
}
