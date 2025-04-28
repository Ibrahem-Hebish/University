using UniversityProject.Core.Dtos.SectionDtos;

namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class GetStudentSectionsHandler(IStudentRepository studentRepository,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<GetStudentSections, Response<List<GetSectionDto>>>
{
    public async Task<Response<List<GetSectionDto>>> Handle(GetStudentSections request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return BadRequest<List<GetSectionDto>>("Id must be grater than 0");

        var student = await studentRepository.FindAsync(request.Id);

        if (student is null)
            return BadRequest<List<GetSectionDto>>("There is no student with this id");

        var studentSections = await studentRepository.GetStudentSections(student);

        if (studentSections is null)
            return NotFouned<List<GetSectionDto>>("There has not been sections attached to this student yet");

        var sectionsDto = mapper.Map<List<GetSectionDto>>(studentSections);

        return Success(sectionsDto);
    }

}

