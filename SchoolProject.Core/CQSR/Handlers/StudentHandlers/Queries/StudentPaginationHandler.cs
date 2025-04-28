namespace UniversityProject.Core.CQSR.Handlers.StudentHandlers.Queries;

public class StudentPaginationHandler(IStudentService studentService,
    IMapper mapper) :
    ResponseHandler,
    IRequestHandler<StudentPagination, PaginationResponse<GetStudentDto>>
{
    public async Task<PaginationResponse<GetStudentDto>> Handle(
        StudentPagination request,
        CancellationToken cancellationToken)
    {
        if (request.Pagenum < 0 || request.Pagesize < 0)
            return new PaginationResponse<GetStudentDto> { Successed = false, Count = 0 };

        var Students = studentService.Filter(request.StudentOrder, request.Search);

        var studentsDtos = mapper.Map<IQueryable<GetStudentDto>>(Students);

        var paginatedlist = await studentsDtos.ToPaginate(request.Pagenum, request.Pagesize);

        return paginatedlist;
    }
}


