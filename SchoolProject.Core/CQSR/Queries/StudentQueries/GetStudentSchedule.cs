namespace UniversityProject.Core.CQSR.Queries.StudentQueries;

public record GetStudentSchedule(int Id) : IRequest<Response<StudentSchedule>> { }
