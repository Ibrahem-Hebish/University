namespace UniversityProject.Services.Services;

public class UserService(
    AppDbContext AppDBcontext,
    IEmailService emailService,
    UserManager<User> userManager,
    IActionContextAccessor contextAccessor,
    IUrlHelper urlHelper)

    : IUserService
{
    public async Task<string> Register(User user, string password)
    {
        using var transaction = AppDBcontext.Database.BeginTransaction();
        try
        {
            var IsExsist = await userManager.FindByNameAsync(user.UserName!);

            if (IsExsist is not null) return ("Try another username");

            var IsExsist2 = await userManager.FindByEmailAsync(user.Email!);

            if (IsExsist2 is not null) return ("Try another email");

            var code = Guid.NewGuid();

            TemporaryUserStore.Users.Add(user);

            TemporaryUserStore.Passwords.Add(password);

            var httpRequest = contextAccessor.ActionContext!.HttpContext.Request;
            var url = httpRequest.Scheme
                + "://"
                + httpRequest.Host + urlHelper.Action(
                "ConfirmEmail", "Authontication", new { code });

            var message = await emailService.SendEmailAsync(
                user.Email!,
                url,
                "Confirming Email");

            transaction.Commit();

            return "success";
        }
        catch
        {
            transaction.Rollback();

            return "Failed To register";
        }
    }

    public async Task<string> SendCodeToResetPassword(string email)
    {
        using var transaction = AppDBcontext.Database.BeginTransaction();
        try
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null) return "User Not Found";

            var code = Random.Shared.Next(0, 1000000).ToString("D6");

            user.Code = code;

            await userManager.UpdateAsync(user);

            var message = await emailService.SendEmailAsync(
                email, $"Your code is {code}",
                "Your code for reset password");

            if (message == "Fail") return "Failed sending email";

            transaction.Commit();

            return "Success";
        }
        catch
        {
            transaction.Rollback();

            return "Fail";
        }
    }
    public async Task<string> ConfirmCodeToResetPassword(
        string code,
        string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user is null) return "User is not found";

        var usercode = user.Code;

        if (code == usercode) return "true code";

        return "false code";
    }

    public async Task<string> ResetPassword(
        string email,
        string password)
    {
        using var transaction = AppDBcontext.Database.BeginTransaction();
        try
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null) return "User is not found";

            var pass = await userManager.RemovePasswordAsync(user);

            await userManager.AddPasswordAsync(user, password);

            transaction.Commit();

            return "Success operation";
        }
        catch
        {
            transaction.Rollback();

            return "Fail";
        }
    }
}
