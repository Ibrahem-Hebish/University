namespace UniversityProject.Data.Entities;

public class StudentTeachingAssistants
{
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }
    public int TeachingAssistantId { get; set; }
    public virtual TeachingAssistant TeachingAssistant { get; set; }
}
