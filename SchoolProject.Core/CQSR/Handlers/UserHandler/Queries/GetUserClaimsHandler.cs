namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Queries;

public class GetUserClaimsHandler(UserManager<User> userManager, IRoleServices roleServices) :
  ResponseHandler, IRequestHandler<GetUserClaims, Response<ManageUserClaims>>

{
    public async Task<Response<ManageUserClaims>> Handle(
         GetUserClaims request,
         CancellationToken cancellationToken)
    {
        if (request.Id <= 0) return
                BadRequest<ManageUserClaims>("Id must be greater than 0");

        var user = await userManager.FindByIdAsync(request.Id.ToString());

        if (user is null) return NotFouned<ManageUserClaims>("User is not found");

        var manageuserclaims = await roleServices.GetManageuserclaimsAsync(user);

        return Success(manageuserclaims);
    }

}


