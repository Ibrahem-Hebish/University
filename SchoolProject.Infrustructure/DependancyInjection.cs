namespace SchoolProject.Infrustructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrustructure(
        this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddDbContext<AppDbContext>();

        services.AddScoped(typeof(IRepositiry<>), typeof(SchoolRepositery<>));

        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<IUserTokenRepository, UserTokenRepository>();

        services.AddScoped<ISubjectRepository, SubjectRepository>();

        services.AddScoped<IStudentSubjectRepository, StudentSubjectRepository>();

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 6;
            opt.User.RequireUniqueEmail = true;
            opt.SignIn.RequireConfirmedEmail = true;
            opt.User.AllowedUserNameCharacters =
            "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm_#$%^&*?1234567890";
        }
        )
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();

        return services;
    }
}
