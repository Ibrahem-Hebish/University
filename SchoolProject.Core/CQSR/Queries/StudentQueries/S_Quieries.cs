namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentById(
    int Id)
    : IRequest<Response<GetStudentDto>>
{ }
public record GetAllStudents()
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record GetStudentByName(
    string Name)
    : IRequest<Response<GetStudentDto>>
{ }
public record GroupStudentsByDep(
    string Name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record GroupStudentsByCourse(
    string Name)
    : IRequest<Response<List<GetStudentDto>>>
{ }
public record StudentPagination(int Pagenum,
                                int Pagesize,
                                string? Search,
                                StudentOrderEnum StudentOrder)
    : IRequest<PaginationResponse<GetStudentDto>>
{ }
