namespace UniversityProject.Core.CQSR.Handlers.DoctorHandlers.Commands;

public class DeleteDoctorHandler(IDoctorRepository doctorRepository) :
    ResponseHandler,
    IRequestHandler<DeleteDoctor, Response<string>>
{
    public async Task<Response<string>> Handle(
        DeleteDoctor request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<string>("Id must be greater than 0");

        var Doctor = await doctorRepository.FindAsync(request.Id);

        if (Doctor == null)
            return NotFouned<string>();

        var result = await doctorRepository.DeleteAsync(Doctor, request.Id);

        if (!result)
            return InternalServerError<string>();

        return Deleted<string>();
    }
}


