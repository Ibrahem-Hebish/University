namespace UniversityProject.Core.Dtos.Student_Dtos;

public class StudentSchedule
{
    public string StudentName { get; set; }

    public List<Subject> Schedule { get; set; } = [];
}

public class Subject
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Day { get; set; }
    public string Place { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}