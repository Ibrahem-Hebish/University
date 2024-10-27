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
    public virtual ICollection<Student> Students { get; set; } = [];
    public virtual ICollection<StudentSections> StudentSections { get; set; } = [];
    public int? TeachingAssistantId { get; set; }
    [ForeignKey(nameof(TeachingAssistantId))]
    public virtual TeachingAssistant TeachingAssistant { get; set; }
    public int SubjectId { get; set; }
    [ForeignKey(nameof(SubjectId))]
    public virtual Subject Subject { get; set; }
    public string? LabName { get; set; }
    [ForeignKey(nameof(LabName))]
    public virtual Lab Lab { get; set; }

}


