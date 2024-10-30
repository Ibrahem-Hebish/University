namespace UniversityProject.Data.Configuration;

public class DepartmentConfiguration
    : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ManagerId).IsUnique();

        builder.Property(x => x.ManagerId).IsRequired(false);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasMany(x => x.Students)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepId);

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);

        builder.HasMany(x => x.Sections)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);

        builder.ToTable("Department");
    }
}
