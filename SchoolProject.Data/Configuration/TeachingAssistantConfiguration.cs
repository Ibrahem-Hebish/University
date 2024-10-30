namespace UniversityProject.Data.Configuration;

public partial class StudentCourseConfiguration
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



            builder.ToTable(nameof(TeachingAssistant));
        }
    }
}