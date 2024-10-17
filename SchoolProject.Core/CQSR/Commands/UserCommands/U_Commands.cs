namespace SchoolProject.Core.CQSR.Commands.UserCommands;

public record AddNewUser(
    AddUser addUser)
    : IRequest<Response<string>>
{ }

public record AddRoleToUser(
    string username, string role)
    : IRequest<Response<bool>>
{ }

public class ChangePassword
    : IRequest<Response<string>>
{
    public string _email { get; set; } = null!;

    public string _password { get; set; } = null!;

    public string _newpassword { get; set; } = null!;

    public string _confirmnewpassword { get; set; } = null!;
}

public record SendEmilForResetPassword(
    string email)
    : IRequest<Response<string>>
{ }

public record ConfirmCodeToResetPassword(
    string code, string email)
    : IRequest<Response<string>>
{ }

public record ResetPassword(
    string email, string password, string confirmpasswod)
    : IRequest<Response<string>>
{ }
