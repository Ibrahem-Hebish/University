namespace UniversityProject.Data.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? OfficeName { get; set; }

    [ForeignKey(nameof(OfficeName))]
    public virtual Office? Office { get; set; }
    public int DepartmentID { get; set; }
    public virtual Department Department { get; set; }
    public virtual List<Student> Students { get; set; } = [];
    public virtual List<StudentDoctors> StudentDoctors { get; set; } = [];
    public virtual List<Course> Courses { get; set; }
}
