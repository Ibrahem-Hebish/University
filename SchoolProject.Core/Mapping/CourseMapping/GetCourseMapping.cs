
namespace UniversityProject.Core.Mapping.CourseMapping;

public partial class CourseMapping
{
    public void GetCourseMapping()
    {
        CreateMap<Course, GetCourseDto>();
    }
}
