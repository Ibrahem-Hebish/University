namespace UniversityProject.Data.Entities;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public int Level { get; set; }
    public int Term { get; set; }
    public virtual List<Student> Students { get; set; } = [];
    public virtual List<StudentSections> StudentSections { get; set; } = [];
    public int? TeachingAssistantId { get; set; }
    [ForeignKey(nameof(TeachingAssistantId))]
    public virtual TeachingAssistant TeachingAssistant { get; set; }
    public int CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; }

    public int DepartmentId { get; set; }
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department Department { get; set; }
    public string? LabName { get; set; }
    [ForeignKey(nameof(LabName))]
    public virtual Lab Lab { get; set; }

}


