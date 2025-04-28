using Claim = System.Security.Claims.Claim;
using UpdateUserClaims = UniversityProject.Core.CQSR.Commands.RolesCommands.UpdateUserClaims;

namespace UniversityProject.Core.CQSR.Handlers.UserHandler.Commands;

public class UpdateUserClaimsHandler(
    UserManager<User> userManager,
    AppDbContext appDbContext) :
  ResponseHandler, IRequestHandler<UpdateUserClaims, Response<string>>

{
    public async Task<Response<string>> Handle(
        UpdateUserClaims request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Userid.ToString());

        if (user is null)
            return NotFouned<string>("User is not found");

        var userclaims = await userManager.GetClaimsAsync(user);

        using (var scope = appDbContext.Database.BeginTransaction())
        {
            try
            {
                await userManager.RemoveClaimsAsync(user, userclaims);

                List<Claim> claims = [];

                var newclaims = request.claims
                     .Where(c => c.Value == true).ToList();

                foreach (var claim in newclaims)
                {
                    var claimToAdd = new Claim(claim.Type, $"{claim.Value}");

                    claims.Add(claimToAdd);
                }
                await userManager.AddClaimsAsync(user, claims);

                scope.Commit();
            }
            catch
            {
                scope.Rollback();

                return InternalServerError<string>("somethig wrong happend while updating the data please,try again later");
            }
        }

        return NoContent<string>("Updated Successfully");
    }

}


