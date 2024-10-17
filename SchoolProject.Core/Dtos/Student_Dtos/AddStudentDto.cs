namespace SchoolProject.Core.Dtos.Student_Dtos;

public class AddStudentDto
{

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public int DepId { get; set; }

    public List<string> Subjects { get; set; }

}
