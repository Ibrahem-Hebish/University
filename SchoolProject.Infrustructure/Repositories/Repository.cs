namespace UniversityProject.Infrustructure.StudentRepositories;

public class StudentRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<Student>(appDbContext, memoryCache)
    , IStudentRepository
{
    public async override Task<Student> FindAsync(int id)
    {
        var Student = await base.FindAsync(id);

        if (Student != null)
            await base._appDbContext.Entry(Student).Reference(s => s.Department).LoadAsync();

        return Student!;
    }
    public override async Task<ICollection<Student>> GetAllAsync(
        bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var students = await base._appDbContext.Students.AsNoTracking()
                .Include(s => s.Courses)
                .Include(s => s.Department)
                .ToListAsync();

            return students;
        }

        var students2 = await base._appDbContext.Students.Include(s => s.Courses)
            .Include(s => s.Department)
            .ToListAsync();

        return students2;
    }

    public override async Task<ICollection<Student>> GetAllWhere(
        Expression<Func<Student, bool>> filter
        , bool AsNoTracking = false)
    {
        var students = base._appDbContext.Students
            .Include(s => s.Courses)
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
            var entity = await base._appDbContext.Students.AsNoTracking()
                .FirstOrDefaultAsync(filter);
            if (entity is not null)
            {
                base._appDbContext.Entry(entity)
                    .Collection(s => s.Courses)
                    .Load();

                base._appDbContext.Entry(entity)
                    .Reference(s => s.Department)
                    .Load();
            }
            return entity!;
        }
        else
        {
            var entity = await base._appDbContext.Students
                        .FirstOrDefaultAsync(filter);

            if (entity is not null)
            {
                base._appDbContext.Entry(entity)
                    .Collection(s => s.Courses)
                    .Load();

                base._appDbContext.Entry(entity)
                    .Reference(s => s.Department)
                    .Load();
            }

            return entity!;
        }
    }
}
public class DepartmentRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Department>(appDbContext, memoryCache)
    , IDepartmentRepository
{
}
public class SectionRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Section>(appDbContext, memoryCache)
    , ISectionRepository
{
    public async override Task<ICollection<Section>> GetAllWhere(Expression<Func<Section, bool>> filter, bool AsNoTracking = false)
    {
        var Sections = _appDbContext.Sections
            .Include(s => s.TeachingAssistant)
            .Include(s => s.Students)
            .Where(filter);
        await Console.Out.WriteLineAsync(Sections.ToQueryString());
        if (AsNoTracking)
            Sections.AsNoTracking();

        return await Sections.ToListAsync();
    }
}
public class DoctorRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Doctor>(appDbContext, memoryCache)
    , IDoctorRepository
{
    public override async Task<Doctor> FindAsync(int id)
    {
        var Doctor = await base.FindAsync(id);

        if (Doctor is not null)
        {
            await _appDbContext.Entry(Doctor).Reference(d => d.Department).LoadAsync();

            await _appDbContext.Entry(Doctor).Collection(d => d.Courses).LoadAsync();
        }

        return Doctor!;
    }
    public async override Task<ICollection<Doctor>> GetAllAsync(bool AsNoTracking = false)
    {
        return await _appDbContext.Doctors.Include(d => d.Department).ToListAsync();
    }

}
public class TeachingAssistantRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<TeachingAssistant>(appDbContext, memoryCache)
    , ITeachingAssistantRepository
{
    public override async Task<TeachingAssistant> FindAsync(int id)
    {
        var TeachingAssistant = await base.FindAsync(id);

        if (TeachingAssistant is not null)
            await _appDbContext.Entry(TeachingAssistant).Reference(t => t.Department).LoadAsync();

        return TeachingAssistant!;
    }

    public override async Task<ICollection<TeachingAssistant>> GetAllAsync(bool AsNoTracking = false)
    {
        var TeachingAssistants = await _appDbContext.TeachingAssistants
            .Include(t => t.Department)
            .ToListAsync();

        return TeachingAssistants;
    }
}
public class StudentSectionsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentSections>(appDbContext, memoryCache)
    , IStudentSectionsRepository
{
}
public class StudentDoctorsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentDoctors>(appDbContext, memoryCache)
    , IStudentDoctorRepository
{
}
public class StudentTeachingAssistantsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentTeachingAssistants>(appDbContext, memoryCache)
    , IStudentTeachingAssistantsRepository
{
}
public class HallRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<Hall>(appDbContext, memoryCache)
    , IHallRepository
{
}
public class OfficeRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Office>(appDbContext, memoryCache)
    , IOfficeRepository
{
    public async Task<Office> FindByNameAsync(string Name)
    {
        if (!_memoryCache.TryGetValue($"{typeof(Office).Name}:{Name}", out Office? result))
        {
            var Entity = await _appDbContext.Offices
                     .SingleOrDefaultAsync(o => o.Name.ToLower() == Name.ToLower());

            if (Entity is not null)
            {
                var options = Set_memoryCacheOptions();

                _memoryCache.Set($"{typeof(Office).Name}:{Name}", Entity, options);

                await Console.Out.WriteLineAsync($"{typeof(Office).Name} with id {Name} is comming from DB");
            }

            return Entity!;
        }
        await Console.Out.WriteLineAsync($"{typeof(Office).Name} with id {Name} is comming from Cacheing");

        return result!;
    }
    public async Task<string> IsOfficeAvillibleForTeachingAssistant(Office office, int DepId)
    {
        if (office.DepartmentId != DepId)
            return "This ofiice is not avillible for teaching assistants in this department";

        if (office.For != "Teaching Assistants")
            return "Office is not for Teaching Assistants";

        await _appDbContext.Entry(office).Collection(o => o.TeachingAssistants).LoadAsync();

        if (office.TeachingAssistants.Count == 3)
            return "Office is not avillible";

        return "Office is avillible";
    }
    public async Task<string> IsOfficeAvillibleForDoctor(Office office, int DepId)
    {
        if (office.DepartmentId != DepId)
            return "This ofiice is not avillible for teaching assistants in this department";

        if (office.For != "Doctors")
            return "Office is not for doctors";

        var Department = await _appDbContext.Departments.FindAsync(DepId);

        if (Department is null)
            return "There is no department with this id";

        var DepManagerId = Department.ManagerId;

        string ManagerOffice = null!;

        if (DepManagerId > 0)
        {
            var Manager = await _appDbContext.Doctors.FindAsync(DepManagerId);

            ManagerOffice = Manager!.OfficeName!;
        }

        if (ManagerOffice != null && office.Name == ManagerOffice)
            return "This office is for the manager";

        await _appDbContext.Entry(office).Collection(o => o.Doctors).LoadAsync();

        if (office.Doctors.Count == 3)
            return "Office is not avillible";

        return "Office is avillible";
    }
}
public class LabRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<Lab>(appDbContext, memoryCache)
    , ILabRepository
{
}
public class StudentCourseRepository(AppDbContext AppDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentCourse>(AppDbContext, memoryCache)
    , IStudentCourseRepository
{
}
public class CourseRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Course>(appDbContext, memoryCache)
    , ICourseRepository
{
    public async override Task<ICollection<Course>> GetAllWhere(Expression<Func<Course, bool>> filter, bool AsNoTracking = false)
    {
        var Courses = await _appDbContext.Courses.Include(c => c.Doctor)
            .Where(filter).ToListAsync();
        return Courses;
    }
}
public class UserTokenRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<UserToken>(appDbContext, memoryCache)
    , IUserTokenRepository
{
}



