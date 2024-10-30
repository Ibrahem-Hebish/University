namespace UniversityProject.Core.Dtos.SectionDtos;

public class GetSectionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LabName { get; set; }
    public string Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public int Level { get; set; }
    public int Term { get; set; }
}
