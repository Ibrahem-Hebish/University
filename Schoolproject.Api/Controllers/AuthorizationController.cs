namespace Universityproject.Api.Controllers;

public class AuthorizationController(
    IMediator mediator)
    : AppController
{
    [HttpGet]
    [Route(Router.RoleRouter.GetRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRole(
        int id)
    {

        var result = await mediator.Send(new GetRole(id));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.RoleRouter.GetRoles)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRoles()
    {
        var result = await mediator.Send(new GetRoles());

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.RoleRouter.ManageUserRoles)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ManageUserRoles(int id)
    {

        var result = await mediator.Send(new GetUserRoles(id));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.RoleRouter.ManageUserClaims)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ManageUserclaims(
        int id)
    {

        var result = await mediator.Send(new GetUserClaims(id));

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.RoleRouter.AddRole)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> AddRole(
        AddRoleCommand command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }
    [HttpPut]
    [Route(Router.RoleRouter.UpdateRole)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> UpdateRole(
        UpdateRole command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }
    [HttpPut]
    [Route(Router.RoleRouter.Updateuserclaims)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateUserClaims(
        [FromBody] Updateuserclaims command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }

    [HttpDelete]
    [Route(Router.RoleRouter.DeleteRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteRole(
        DeleteRole command)
    {
        var result = await mediator.Send(command);

        return NewRsponse(result);
    }

}
