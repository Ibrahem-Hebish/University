namespace UniversityProject.Data.Entities
{
    public class TeachingAssistant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? OfficeName { get; set; }

        [ForeignKey(nameof(OfficeName))]
        public virtual Office? Office { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public virtual Department Department { get; set; }
        public virtual List<Student> Students { get; set; } = [];
        public virtual List<StudentTeachingAssistants> StudentTeachingAssistants { get; set; } = [];
        public virtual List<Section> Sections { get; set; } = [];
    }
}
