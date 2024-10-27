namespace UniversityProject.Data.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int Level { get; set; }
    public int Term { get; set; }
    public int DepId { get; set; }
    [ForeignKey(nameof(DepId))]
    public virtual Department Department { get; set; }
    public virtual List<Subject> Subjects { get; set; } = [];
    public virtual List<StudentSubject> Studentsubjects { get; set; } = [];
    public virtual List<Doctor> Doctors { get; set; } = [];
    public virtual List<StudentDoctors> StudentDoctors { get; set; } = [];
    public virtual List<TeachingAssistant> TeachingAssistants { get; set; } = [];
    public virtual List<StudentTeachingAssistants> StudentTeachingAssistants { get; set; } = [];
    public virtual List<StudentSections> StudentSections { get; set; } = [];
    public virtual List<Section> Sections { get; set; } = [];

}
