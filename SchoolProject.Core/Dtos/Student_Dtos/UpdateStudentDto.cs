namespace SchoolProject.Core.Dtos.Student_Dtos;

public class UpdateStudentDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int DepId { get; set; }
    [Required]
    public List<string> Subjects { get; set; }

}

