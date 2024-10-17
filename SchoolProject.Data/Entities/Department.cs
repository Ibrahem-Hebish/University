namespace SchoolProject.Data.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
}
