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
    [Route(Router.DoctorRouter.GetDoctorSubjects)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetSubjectDto>>> GetDoctorSubjects(int id)
    {
        var Doctors = await mediator.Send(new GetDoctorSubjects(id));

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
    public async Task<ActionResult<List<GetSubjectDto>>> Delete(int id)
    {
        var Doctors = await mediator.Send(new DeleteDoctor(id));

        return NewRsponse(Doctors);
    }
}
