namespace UniversityProject.Core.Dtos.SubjectDtos;

public class GetSubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int Level { get; set; }
    public int Term { get; set; }
}
