namespace SchoolProject.Data.Entities;

public class DepartmentSubject
{
    public int DepId { get; set; }
    public int SubId { get; set; }

    [ForeignKey(nameof(DepId))]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey(nameof(SubId))]
    public virtual Subject Subject { get; set; } = null!;
}