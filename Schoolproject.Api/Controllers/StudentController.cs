using Microsoft.AspNetCore.RateLimiting;
using SchoolProject.Core.Dtos.Student_Dtos;

namespace Schoolproject.Api.Controllers;

public class StudentController(
    IMediator mediator, IConfiguration configuration)
    : AppController(mediator)
{

    [HttpGet]
    [Route(Router.StudentRouter.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EnableRateLimiting(policyName: "slidingPolicy")]
    public async Task<ActionResult<GetStudentDto>> GetById(
        int id)
    {
        if (id <= 0) return BadRequest();

        var s_dto = await mediator.Send(new GetStudentById(id));

        return NewRsponse(s_dto);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GetByName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStudentDto>> GetByName(
        string name)
    {
        if (name is null) return BadRequest();

        var s_dto = await mediator.Send(new GetStudentByName(name));

        return NewRsponse(s_dto);
    }

    [HttpGet]
    [Route(Router.StudentRouter.Paginate)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetStudentDto>>> Paginate(
        [FromQuery] StudentPagination sp)
    {
        if (sp.pagenum <= 0 || sp.pagesize <= 0) return BadRequest();

        var S_Dtos = await mediator.Send(sp);

        return Ok(S_Dtos);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GroupBySubname)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetStudentDto>>> GroupBySubName(
        string subname)
    {
        if (string.IsNullOrWhiteSpace(subname)) return BadRequest();

        var S_Dtos = await mediator.Send(new GroupStudentsBySub(subname));

        return NewRsponse(S_Dtos);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GroupByDepname)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStudentDto>> GroupByDepartment(
        string Depname)
    {
        if (Depname is null) return BadRequest();

        var s_dto = await mediator.Send(new GroupStudentsByDep(Depname));

        return NewRsponse(s_dto);
    }

    [HttpPost]
    [Route(Router.StudentRouter.AddNewStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create(
        [FromBody] AddStudennt AddStudent)
    {
        if (AddStudent is null) return BadRequest();

        var IsCreated = await mediator.Send(AddStudent);

        return NewRsponse(IsCreated);
    }

    [HttpPut]
    [Route(Router.StudentRouter.UpdateStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetStudentDto>> Update(
        UpdateStudent UpdateStudent)
    {
        if (UpdateStudent is null) return BadRequest();

        var s_dto = await mediator.Send(UpdateStudent);

        return NewRsponse(s_dto);
    }

    [HttpDelete]
    [Route(Router.StudentRouter.DeleteStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<ActionResult<string>> Delete(
        int id)
    {
        if (id <= 0) return BadRequest();

        var s_dto = await mediator.Send(new DeleteStudennt(id));

        return NewRsponse(s_dto);
    }
}
