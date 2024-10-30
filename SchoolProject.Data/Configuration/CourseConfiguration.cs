namespace UniversityProject.Data.Configuration;

public class CourseConfiguration
    : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasMany(x => x.Sections)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId);

        builder.ToTable(nameof(Course));
    }
}
