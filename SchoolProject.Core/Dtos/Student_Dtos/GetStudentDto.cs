namespace UniversityProject.Core.Dtos.Student_Dtos;

public class GetStudentDto
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string DepName { get; set; } = null!;
    public int Level { get; set; }
    public int Term { get; set; }
}
