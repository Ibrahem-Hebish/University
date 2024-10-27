namespace UniversityProject.Data.Entities;

public class StudentSections
{
    public int StudentId { get; set; }
    [ForeignKey(nameof(StudentId))]
    public virtual Student student { get; set; } = null!;
    public int SectionId { get; set; }

    [ForeignKey(nameof(SectionId))]
    public virtual Section Section { get; set; } = null!;
}


