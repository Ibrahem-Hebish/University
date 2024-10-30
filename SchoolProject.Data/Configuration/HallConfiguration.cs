namespace UniversityProject.Data.Configuration;

public class HallConfiguration
    : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.HasKey(x => x.Name);

        builder.Property(x => x.Name)
           .HasColumnType("VARCHAR")
           .HasMaxLength(2);

        builder.Property(x => x.Floor)
           .HasColumnType("VARCHAR")
           .HasMaxLength(10);

        builder.Property(x => x.Building)
           .HasColumnType("VARCHAR")
           .HasMaxLength(3);

        builder.HasMany(x => x.Courses)
            .WithOne(x => x.Hall)
            .HasForeignKey(x => x.HallName);

        builder.ToTable(nameof(Hall));
    }
}