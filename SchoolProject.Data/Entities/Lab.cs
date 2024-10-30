namespace UniversityProject.Data.Entities;

public class Lab
{
    public string Name { get; set; }
    public string Building { get; set; }
    public string Floor { get; set; }
    public int? DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; }
    public virtual List<Section> Sections { get; set; } = [];
}


