namespace SchoolProject.Data.Configuration;

public class StudentSubjectConfiguration
    : IEntityTypeConfiguration<StudentSubject>
{
    public void Configure(EntityTypeBuilder<StudentSubject> builder)
    {
        builder.HasKey(x => new { x.SubId, x.StuId });

        builder.ToTable(nameof(StudentSubject));
    }
}
