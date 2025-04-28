using UniversityProject.Core.CQSR.Queries.SectionQuiries;
using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Handlers.SectionHandler.Queries;

public class GetSectionByIdHandler(ISectionRepository sectionRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetSectionById, Response<GetSectionDto>>

{
    public async Task<Response<GetSectionDto>> Handle(GetSectionById request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<GetSectionDto>("Id must be grater than 0");

        var Section = await sectionRepository.FindAsync(request.Id);

        if (Section is null)
            return NotFouned<GetSectionDto>("There is no section with this id");

        var SectionDto = mapper.Map<GetSectionDto>(Section);

        return Success(SectionDto);
    }

}

