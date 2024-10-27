namespace UniversityProject.Data.Configuration;

public partial class StudentSubjectConfiguration
{
    public class TeachingAssistantConfiguration
    : IEntityTypeConfiguration<TeachingAssistant>
    {
        public void Configure(EntityTypeBuilder<TeachingAssistant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Students)
                .WithMany(x => x.TeachingAssistants)
                .UsingEntity<StudentTeachingAssistants>();

            builder.HasOne(x => x.Department)
                .WithMany(x => x.TeachingAssistants)
                .HasForeignKey(x => x.DepartmentID);

            builder.HasMany(x => x.Sections)
                .WithOne(x => x.TeachingAssistant)
                .HasForeignKey(x => x.TeachingAssistantId);

            builder.ToTable(nameof(TeachingAssistant));
        }
    }
}