using UniversityProject.Core.Dtos.Student_Dtos;

namespace Universityproject.Api.Controllers;

public class StudentController(
    IMediator mediator)
    : AppController
{

    [HttpGet]
    [Route(Router.StudentRouter.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EnableRateLimiting(policyName: "slidingPolicy")]
    public async Task<ActionResult<GetStudentDto>> GetById(
        int id)
    {

        var result = await mediator.Send(new GetStudentById(id));

        return NewRsponse(result);
    }
    [HttpGet]
    [Route(Router.StudentRouter.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStudentDto>> Get()
    {
        var result = await mediator.Send(new GetAllStudents());

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GetByName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStudentDto>> GetByName(
        string name)
    {

        var result = await mediator.Send(new GetStudentByName(name));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.StudentRouter.Paginate)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetStudentDto>>> Paginate(
        [FromQuery] StudentPagination sp)
    {

        var result = await mediator.Send(sp);

        return Ok(result);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GroupBySubname)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GetStudentDto>>> GroupBySubName(
        string subname)
    {

        var result = await mediator.Send(new GroupStudentsByCourse(subname));

        return NewRsponse(result);
    }

    [HttpGet]
    [Route(Router.StudentRouter.GroupByDepname)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetStudentDto>> GroupByDepartment(
        string Depname)
    {

        var result = await mediator.Send(new GroupStudentsByDep(Depname));

        return NewRsponse(result);
    }

    [HttpPost]
    [Route(Router.StudentRouter.AddNewStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create(
        [FromBody] AddStudent AddStudent)
    {

        var result = await mediator.Send(AddStudent);

        return NewRsponse(result);
    }

    [HttpPut]
    [Route(Router.StudentRouter.UpdateStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetStudentDto>> Update(
        UpdateStudent UpdateStudent)
    {

        var result = await mediator.Send(UpdateStudent);

        return NewRsponse(result);
    }

    [HttpDelete]
    [Route(Router.StudentRouter.DeleteStudent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Delete(
        int id)
    {

        var result = await mediator.Send(new DeleteStudennt(id));

        return NewRsponse(result);
    }
}
