namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Queries;

public class GetDoctorsHandler(IDoctorRepository doctorRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllDoctors, Response<List<GetDoctorDto>>>
{
    public async Task<Response<List<GetDoctorDto>>> Handle(GetAllDoctors request, CancellationToken cancellationToken)
    {
        var Doctors = await doctorRepository.GetAllAsync();

        if (Doctors is null || !Doctors.Any())
            return NotFouned<List<GetDoctorDto>>();

        var DoctorsDtos = mapper.Map<List<GetDoctorDto>>(Doctors);

        return Success(DoctorsDtos);
    }

}


