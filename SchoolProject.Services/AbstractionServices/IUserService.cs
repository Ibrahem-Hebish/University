namespace SchoolProject.Services.AbstractionServices;

public interface IUserService
{
    Task<string> Register(User user,
                          string password);

    Task<string> SendCodeToResetPassword(string email);

    Task<string> ConfirmCodeToResetPassword(string code,
                                            string email);

    Task<string> ResetPassword(string email,
                               string password);
}
