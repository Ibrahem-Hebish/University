namespace SchoolProject.Data.Configuration;

internal class StudentConfiguration
    : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Phone)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100);

        builder.HasMany(x => x.Subjects)
            .WithMany(x => x.Students)
            .UsingEntity<StudentSubject>();

        builder.ToTable("Students");
    }
}

