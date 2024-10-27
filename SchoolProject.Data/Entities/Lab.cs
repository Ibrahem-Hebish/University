namespace UniversityProject.Data.Entities;

public class Lab
{
    public string Name { get; set; }
    public string Building { get; set; }
    public string Floor { get; set; }
    public virtual List<Section> Sections { get; set; } = [];
}


