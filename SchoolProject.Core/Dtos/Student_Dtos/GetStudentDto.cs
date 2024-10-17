namespace SchoolProject.Core.Dtos.Student_Dtos;

public class GetStudentDto
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string DepName { get; set; } = null!;
    public List<string> Subjects { get; set; } = null!;

}
