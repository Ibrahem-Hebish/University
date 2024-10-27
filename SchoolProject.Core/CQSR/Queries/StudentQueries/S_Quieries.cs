namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentById(
    int Id)
    : IRequest<Response<GetStudentDto>>
{ }
public record GetAllStudents()
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record GetStudentByName(
    string name)
    : IRequest<Response<GetStudentDto>>
{ }
public record GroupStudentsByDep(
    string name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record GroupStudentsBySub(
    string name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record StudentPagination(int pagenum,
                                int pagesize,
                                string? search,
                                StudentOrderEnum StudentOrder)
    : IRequest<PaginationResponse<GetStudentDto>>
{ }
