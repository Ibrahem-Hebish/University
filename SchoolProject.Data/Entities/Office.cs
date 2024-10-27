namespace UniversityProject.Data.Entities
{
    public class Office
    {
        public string Name { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string For { get; set; }
        public virtual List<Doctor> Doctors { get; set; } = [];
        public virtual List<TeachingAssistant> TeachingAssistants { get; set; } = [];
        public virtual List<User> Users { get; set; } = [];
    }
}
