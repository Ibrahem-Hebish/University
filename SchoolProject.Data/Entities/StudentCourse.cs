namespace UniversityProject.Data.Entities;

public class StudentCourse
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    [ForeignKey(nameof(StudentId))]
    public virtual Student Student { get; set; } = null!;
    [ForeignKey(nameof(CourseId))]

    public virtual Course Course { get; set; } = null!;
}
