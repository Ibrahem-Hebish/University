using UniversityProject.Core.CQSR.Commands.DoctorCommands;

namespace Universityproject.Api.Controllers;

public class DoctorController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.DoctorRouter.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GetDoctorDto>> Get(int id)
    {
        var Doctors = await mediator.Send(new GetDoctor(id));

        return NewRsponse(Doctors);
    }

    [HttpGet]
    [Route(Router.DoctorRouter.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<GetDoctorDto>>> GetAll()
    {
        var Doctors = await mediator.Send(new GetAllDoctors());

        return NewRsponse(Doctors);
    }

    [HttpGet]
    [Route(Router.DoctorRouter.GetDoctorCourses)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> GetDoctorCourses(int id)
    {
        var Doctors = await mediator.Send(new GetDoctorCourses(id));

        return NewRsponse(Doctors);
    }
    [HttpPost]
    [Route(Router.DoctorRouter.AddDoctor)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> Create(AddNewDoctor Command)
    {
        var Doctors = await mediator.Send(Command);

        return NewRsponse(Doctors);
    }

    [HttpPut]
    [Route(Router.DoctorRouter.ChangeDoctorOffice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDoctorDto>> Delete(ChangeDoctorOffice Command)
    {
        var Doctors = await mediator.Send(Command);

        return NewRsponse(Doctors);
    }

    [HttpDelete]
    [Route(Router.DoctorRouter.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> Delete(int id)
    {
        var Doctors = await mediator.Send(new DeleteDoctor(id));

        return NewRsponse(Doctors);
    }
}
