namespace SchoolProject.Data.Entities;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Student>? Students { get; set; }
    public virtual ICollection<StudentSubject>? Studentsubjects { get; set; }
    public virtual ICollection<Department> Departments { get; set; }
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

}
