namespace UniversityProject.Data.Configuration;

public class StudentDoctorsConfiguration
    : IEntityTypeConfiguration<StudentDoctors>
{
    public void Configure(EntityTypeBuilder<StudentDoctors> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.DoctorId });

        builder.ToTable(nameof(StudentDoctors));
    }
}