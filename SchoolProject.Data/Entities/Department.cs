namespace UniversityProject.Data.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual List<Subject> Subjects { get; set; } = [];
    public virtual List<Student> Students { get; set; } = [];
    public virtual List<Doctor> Doctors { get; set; } = [];
    public virtual List<TeachingAssistant> TeachingAssistants { get; set; } = [];
    public int? ManagerId { get; set; }
    [ForeignKey(nameof(ManagerId))]
    public virtual Doctor Manager { get; set; }
}
