namespace SchoolProject.Data.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int DepId { get; set; }
    [ForeignKey(nameof(DepId))]
    public virtual Department Department { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }
    public virtual ICollection<StudentSubject> Studentsubjects { get; set; }
}
