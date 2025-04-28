namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record StudentPagination(int Pagenum,
                                int Pagesize,
                                string? Search,
                                StudentOrderEnum StudentOrder)
    : IRequest<PaginationResponse<GetStudentDto>>
{ }
