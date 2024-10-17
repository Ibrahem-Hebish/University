namespace SchoolProject.Data.Configuration;

public class DepartmentConfiguration
    : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasMany(x => x.Students)
            .WithOne(x => x.Department);

        builder.HasMany(x => x.Subjects)
            .WithMany(x => x.Departments)
            .UsingEntity<DepartmentSubject>();

        builder.ToTable("Department");
    }
}
