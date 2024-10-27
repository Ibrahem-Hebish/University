namespace UniversityProject.Data.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int Level { get; set; }
    public int Term { get; set; }
    public virtual List<Student>? Students { get; set; }
    public virtual List<StudentSubject>? Studentsubjects { get; set; } = [];
    public virtual List<Section> Sections { get; set; } = [];
    public int DepartmentId { get; set; }
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department Department { get; set; }
    public int? DoctorId { get; set; }
    [ForeignKey(nameof(DoctorId))]
    public virtual Doctor Doctor { get; set; }
    public string? HallName { get; set; }
    [ForeignKey(nameof(HallName))]
    public virtual Hall Hall { get; set; }
}

