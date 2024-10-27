namespace UniversityProject.Data.Entities;

public class StudentSubject
{
    public int StuId { get; set; }
    public int SubId { get; set; }
    [ForeignKey(nameof(StuId))]
    public virtual Student student { get; set; } = null!;
    [ForeignKey(nameof(SubId))]

    public virtual Subject subject { get; set; } = null!;
}
