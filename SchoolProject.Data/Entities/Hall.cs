namespace UniversityProject.Data.Entities;

public class Hall
{
    public string Name { get; set; }
    public string Building { get; set; }
    public string Floor { get; set; }
    public int? DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Deprtment { get; set; }
    public virtual List<Course> Courses { get; set; } = [];
}

