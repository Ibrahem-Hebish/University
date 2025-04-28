namespace UniversityProject.Core.CQSR.Handlers.RoleHandler.Commands;

public class UpdateRoleHandler(IRoleServices roleServices) :
  ResponseHandler, IRequestHandler<UpdateRole, Response<string>>

{
    public async Task<Response<string>> Handle(
        UpdateRole request,
        CancellationToken cancellationToken)
    {
        var result = await roleServices.UpdateRole(request.CurrentName, request.NewName);

        switch (result)
        {
            case "Bad request":
                return BadRequest<string>("There is no role with ths name");

            case "Server error":
                return InternalServerError<string>("Error happens while deleting the data");

        }

        return Success("Data is updated");
    }

}


