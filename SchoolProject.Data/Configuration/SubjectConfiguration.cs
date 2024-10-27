namespace UniversityProject.Data.Configuration;

public class SubjectConfiguration
    : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasMany(x => x.Sections)
            .WithOne(x => x.Subject)
            .HasForeignKey(x => x.SubjectId);

        builder.ToTable(nameof(Subject));
    }
}
