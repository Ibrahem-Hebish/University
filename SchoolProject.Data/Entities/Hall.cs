namespace UniversityProject.Data.Entities;

public class Hall
{
    public string Name { get; set; }
    public string Building { get; set; }
    public string Floor { get; set; }

    public virtual List<Subject> Subjects { get; set; } = [];
}

