namespace UniversityProject.Core.CQSR.Commands.UserCommands;

public class AddNewUser : AddUser,
     IRequest<Response<string>>
{ }

public record AddRoleToUser(
    string username, string role)
    : IRequest<Response<bool>>
{ }

public class ChangePassword
    : IRequest<Response<string>>
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Newpassword { get; set; } = null!;

    public string Confirmnewpassword { get; set; } = null!;
}

public record SendEmilForResetPassword(
    string Email)
    : IRequest<Response<string>>
{ }

public record ConfirmCodeToResetPassword(
    string Code, string Email)
    : IRequest<Response<string>>
{ }

public record ResetPassword(
    string Email, string Password, string Confirmpasswod)
    : IRequest<Response<string>>
{ }
