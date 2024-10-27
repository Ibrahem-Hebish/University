namespace UniversityProject.Data.Configuration;

public class OfficeConfiguration
    : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.HasKey(x => x.Name);

        builder.Property(x => x.Name)
           .HasColumnType("VARCHAR")
           .HasMaxLength(5);

        builder.Property(x => x.Floor)
           .HasColumnType("VARCHAR")
           .HasMaxLength(1);

        builder.Property(x => x.Building)
           .HasColumnType("VARCHAR")
           .HasMaxLength(3);

        builder.HasMany(x => x.Doctors)
            .WithOne(x => x.Office)
            .HasForeignKey(x => x.OfficeName);

        builder.HasMany(x => x.TeachingAssistants)
            .WithOne(x => x.Office)
            .HasForeignKey(x => x.OfficeName);

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Office)
            .HasForeignKey(x => x.OfficeName);

        builder.ToTable(nameof(Office));
    }
}