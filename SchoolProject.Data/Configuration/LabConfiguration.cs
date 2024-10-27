namespace UniversityProject.Data.Configuration;

public class LabConfiguration
    : IEntityTypeConfiguration<Lab>
{
    public void Configure(EntityTypeBuilder<Lab> builder)
    {
        builder.HasKey(x => x.Name);

        builder.Property(x => x.Name)
           .HasColumnType("VARCHAR")
           .HasMaxLength(4);

        builder.Property(x => x.Floor)
           .HasColumnType("VARCHAR")
           .HasMaxLength(1);

        builder.Property(x => x.Building)
           .HasColumnType("VARCHAR")
           .HasMaxLength(3);

        builder.HasMany(x => x.Sections)
            .WithOne(x => x.Lab)
            .HasForeignKey(x => x.LabName);

        builder.ToTable(nameof(Lab));
    }
}