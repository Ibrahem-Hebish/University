namespace UniversityProject.Core.Dtos.CourseDtos;

public class GetCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Day { get; set; }
    public string HallName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int Level { get; set; }
    public int Term { get; set; }
}
