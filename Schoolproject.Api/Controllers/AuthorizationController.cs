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
        if (id <= 0) return BadRequest("Id must be greater than 0");

        var isCreated = await mediator.Send(new GetRole(id));

        return NewRsponse(isCreated);
    }

    [HttpGet]
    [Route(Router.RoleRouter.GetRoles)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetRoles()
    {
        var isCreated = await mediator.Send(new GetRoles());

        return NewRsponse(isCreated);
    }

    [HttpGet]
    [Route(Router.RoleRouter.ManageUserRoles)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ManageUserRoles(int id)
    {
        if (id <= 0) return BadRequest("Id must be greater than 0");

        var isCreated = await mediator.Send(new GetUserRoles(id));

        return NewRsponse(isCreated);
    }

    [HttpGet]
    [Route(Router.RoleRouter.ManageUserClaims)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> ManageUserclaims(
        int id)
    {
        if (id <= 0) return BadRequest("Id must be greater than 0");

        var isCreated = await mediator.Send(new GetUserClaims(id));

        return NewRsponse(isCreated);
    }

    [HttpPost]
    [Route(Router.RoleRouter.AddRole)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> AddRole(
        AddRoleCommand command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }
    [HttpPut]
    [Route(Router.RoleRouter.UpdateRole)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> UpdateRole(
        UpdateRole command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }
    [HttpPut]
    [Route(Router.RoleRouter.Updateuserclaims)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateUserClaims(
        [FromBody] Updateuserclaims command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }

    [HttpDelete]
    [Route(Router.RoleRouter.DeleteRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteRole(
        DeleteRole command)
    {
        var isCreated = await mediator.Send(command);

        return NewRsponse(isCreated);
    }

}
