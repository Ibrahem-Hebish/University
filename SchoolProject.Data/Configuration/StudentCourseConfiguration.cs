namespace UniversityProject.Data.Configuration;

public partial class StudentCourseConfiguration
    : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasKey(x => new { x.CourseId, x.StudentId });

        builder.ToTable(nameof(StudentCourse));
    }
}