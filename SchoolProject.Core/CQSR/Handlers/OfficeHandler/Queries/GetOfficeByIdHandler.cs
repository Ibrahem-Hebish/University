using UniversityProject.Core.CQSR.Queries.OfficeQueries;
using UniversityProject.Core.Dtos.OfficeDtos;

namespace UniversityProject.Core.CQSR.Handlers.OfficeHandler.Queries;

public class GetOfficeByIdHandler(IOfficeRepository officeRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetOfficeById, Response<GetOffice>>
{
    public async Task<Response<GetOffice>> Handle(GetOfficeById request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest<GetOffice>("Name is required");

        var office = await officeRepository.FindByNameAsync(request.Name);

        if (office is null)
            return NotFouned<GetOffice>("There is no office with this name");

        var officeDto = mapper.Map<GetOffice>(office);

        return Success(officeDto);
    }

}



