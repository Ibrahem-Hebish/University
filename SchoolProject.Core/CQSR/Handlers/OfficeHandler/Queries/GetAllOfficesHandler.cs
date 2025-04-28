using UniversityProject.Core.CQSR.Queries.OfficeQueries;
using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler.Queries;

public class GetAllOfficesHandler(IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetAllOffices, Response<List<GetOffice>>>
{
    public async Task<Response<List<GetOffice>>> Handle(GetAllOffices request, CancellationToken cancellationToken)
    {
        var offices = await officeRepository.GetAllAsync();

        if (!offices.Any())
            return NotFouned<List<GetOffice>>("There are no labs in the system");

        var officesDto = mapper.Map<List<GetOffice>>(offices.ToList());


        return Success(officesDto);
    }

}



