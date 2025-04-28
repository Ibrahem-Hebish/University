namespace UniversityProject.Core.CQSR.Handlers.RoleHandler.Commands;

public class DeleteRoleHandler(IRoleServices roleServices) :
  ResponseHandler, IRequestHandler<DeleteRole, Response<string>>

{
    public async Task<Response<string>> Handle(
       DeleteRole request,
       CancellationToken cancellationToken)
    {
        var result = await roleServices.DeleteRole(request.Id);

        switch (result)
        {
            case "Not found":
                return NotFouned<string>("There is no role with ths id");
            case "Server error":
                return InternalServerError<string>("Error happens while deleting the data");
        }

        return Deleted<string>();
    }
}


