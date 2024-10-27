namespace UniversityProject.Data.Configuration;

public class StudentTeachingAssistantsConfiguration
    : IEntityTypeConfiguration<StudentTeachingAssistants>
{
    public void Configure(EntityTypeBuilder<StudentTeachingAssistants> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.TeachingAssistantId });

        builder.ToTable(nameof(StudentTeachingAssistants));
    }
}