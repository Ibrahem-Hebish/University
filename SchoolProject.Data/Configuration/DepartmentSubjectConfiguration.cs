namespace SchoolProject.Data.Configuration;

public class DepartmentSubjectConfiguration
    : IEntityTypeConfiguration<DepartmentSubject>
{
    public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
    {
        builder.HasKey(x => new { x.SubId, x.DepId });

        builder.ToTable(nameof(DepartmentSubject));
    }
}
