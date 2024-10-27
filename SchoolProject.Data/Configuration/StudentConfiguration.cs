namespace UniversityProject.Data.Configuration;

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
            .UsingEntity<StudentSubject>(x =>
            x.HasOne(x => x.subject)
            .WithMany(x => x.Studentsubjects)
            .OnDelete(DeleteBehavior.ClientNoAction),
            x =>
            x.HasOne(x => x.student)
            .WithMany(x => x.Studentsubjects)
            .OnDelete(DeleteBehavior.Cascade));

        builder.HasMany(x => x.Sections)
            .WithMany(x => x.Students)
            .UsingEntity<StudentSections>(x =>
            x.HasOne(x => x.Section)
            .WithMany(x => x.StudentSections)
            .OnDelete(DeleteBehavior.ClientNoAction),
            x =>
            x.HasOne(x => x.student)
            .WithMany(x => x.StudentSections)
            .OnDelete(DeleteBehavior.Cascade));

        builder.ToTable("Students");
    }
}

