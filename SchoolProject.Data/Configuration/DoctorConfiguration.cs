namespace UniversityProject.Data.Configuration;

public class DoctorConfiguration
    : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DepartmentID).IsRequired();

        builder.HasMany(x => x.Students)
            .WithMany(x => x.Doctors)
            .UsingEntity<StudentDoctors>();

        builder.HasOne(x => x.Department)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.DepartmentID);

        builder.HasMany(x => x.Subjects)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.DoctorId);

        builder.ToTable(nameof(Doctor));
    }
}
