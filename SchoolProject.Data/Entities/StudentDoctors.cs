namespace UniversityProject.Data.Entities
{
    public class StudentDoctors
    {
        public int StudentId { get; set; }
        [ForeignKey(name: nameof(StudentId))]
        public virtual Student Student { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey(name: nameof(DoctorId))]
        public virtual Doctor Doctor { get; set; }
    }
}
