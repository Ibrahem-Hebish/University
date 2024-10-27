namespace UniversityProject.Data.Configuration;

public class StudentSectionsConfiguration
    : IEntityTypeConfiguration<StudentSections>
{
    public void Configure(EntityTypeBuilder<StudentSections> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.SectionId });

        builder.ToTable(nameof(StudentSections));
    }
}
