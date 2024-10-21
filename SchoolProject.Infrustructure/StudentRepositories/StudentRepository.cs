using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.StudentRepositories;

public class StudentRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : SchoolRepositery<Student>(appDbContext, memoryCache)
    , IStudentRepository
{
    public DbSet<Student> Students { get; set; } = appDbContext.Set<Student>();

    public override async Task<ICollection<Student>> GetAllAsync(
        bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var students = await Students.AsNoTracking()
                .Include(s => s.Subjects)
                .Include(s => s.Department)
                .ToListAsync();

            return students;
        }

        var students2 = await Students.Include(s => s.Subjects)
            .Include(s => s.Department)
            .ToListAsync();

        return students2;
    }

    public override async Task<ICollection<Student>> GetAllWhere(
        Expression<Func<Student, bool>> filter
        , bool AsNoTracking = false)
    {
        var students = Students
            .Include(s => s.Subjects)
            .Include(s => s.Department)
            .Where(filter);

        if (AsNoTracking)
            students = students.AsNoTracking();

        return await students.ToListAsync();
    }

    public override async Task<Student> GetOneAsync(
        Expression<Func<Student, bool>> filter
        , bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var entity = await Students.AsNoTracking()
                .FirstOrDefaultAsync(filter);
            if (entity is not null)
            {
                appDbContext.Entry(entity)
                    .Collection(s => s.Subjects)
                    .Load();

                appDbContext.Entry(entity)
                    .Reference(s => s.Department)
                    .Load();
            }
            return entity!;
        }
        else
        {
            var entity = await Students
                        .FirstOrDefaultAsync(filter);

            if (entity is not null)
            {
                appDbContext.Entry(entity)
                    .Collection(s => s.Subjects)
                    .Load();

                appDbContext.Entry(entity)
                    .Reference(s => s.Department)
                    .Load();
            }

            return entity!;
        }
    }
}
