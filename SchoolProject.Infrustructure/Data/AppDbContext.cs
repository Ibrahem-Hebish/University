namespace SchoolProject.Infrustructure.Data;

public class AppDbContext
    : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>
        , IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
    public override DbSet<User> Users { get; set; }
    public override DbSet<Role> Roles { get; set; }
    public new DbSet<UserToken> UserTokens { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public AppDbContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Student).Assembly);
    }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("AppSettings.json")
            .Build();

        var cotstr = config
            .GetSection("cotstr")
            .Value;

        optionsBuilder.UseSqlServer(cotstr);
    }
}
