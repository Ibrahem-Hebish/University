namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Queries;

public class GetDoctorHandler(IDoctorRepository doctorRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetDoctor, Response<GetDoctorDto>>
{
    public async Task<Response<GetDoctorDto>> Handle(GetDoctor request, CancellationToken cancellationToken)
    {
        if (request.id <= 0)
            return BadRequest<GetDoctorDto>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.id);

        if (Doctor == null)
            return NotFouned<GetDoctorDto>();

        var DoctorDto = mapper.Map<GetDoctorDto>(Doctor);

        return Success(DoctorDto);
    }

}


