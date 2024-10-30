namespace UniversityProject.Data.Configuration;

public class SectionConfiguration
    : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(s => s.DepartmentId).IsRequired();

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasOne(s => s.TeachingAssistant)
            .WithMany(t => t.Sections)
            .HasForeignKey(s => s.TeachingAssistantId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable(nameof(Section));
    }
}
