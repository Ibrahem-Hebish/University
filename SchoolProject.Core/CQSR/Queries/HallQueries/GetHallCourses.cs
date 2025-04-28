namespace UniversityProject.Core.CQSR.Queries.HallQueries;
public record GetHallCourses(string Name) : IRequest<Response<List<GetCourseDto>>> { }
