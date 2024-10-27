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
                .Include(s => s.Subjects)
                .Include(s => s.Department)
                .ToListAsync();

            return students;
        }

        var students2 = await base._appDbContext.Students.Include(s => s.Subjects)
            .Include(s => s.Department)
            .ToListAsync();

        return students2;
    }

    public override async Task<ICollection<Student>> GetAllWhere(
        Expression<Func<Student, bool>> filter
        , bool AsNoTracking = false)
    {
        var students = base._appDbContext.Students
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
            var entity = await base._appDbContext.Students.AsNoTracking()
                .FirstOrDefaultAsync(filter);
            if (entity is not null)
            {
                base._appDbContext.Entry(entity)
                    .Collection(s => s.Subjects)
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
                    .Collection(s => s.Subjects)
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
        var Section = await base._appDbContext.Sections
            .Include(s => s.TeachingAssistant)
            .Include(s => s.Students)
            .Where(filter).ToListAsync();
        return Section;
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

            await _appDbContext.Entry(Doctor).Collection(d => d.Subjects).LoadAsync();
        }

        return Doctor!;
    }
    public async override Task<ICollection<Doctor>> GetAllAsync(bool AsNoTracking = false)
    {
        return await _appDbContext.Doctors.Include(d => d.Department).ToListAsync();
    }

}
public class TeachingAssistantRepository
    : UniversityRepositery<TeachingAssistant>
    , ITeachingAssistantRepository
{
    public TeachingAssistantRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class StudentSectionsRepository
    : UniversityRepositery<StudentSections>
    , IStudentSectionsRepository
{
    public StudentSectionsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class StudentDoctorsRepository
    : UniversityRepositery<StudentDoctors>
    , IStudentDoctorRepository
{
    public StudentDoctorsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class StudentTeachingAssistantsRepository
    : UniversityRepositery<StudentTeachingAssistants>
    , IStudentTeachingAssistantsRepository
{
    public StudentTeachingAssistantsRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class HallRepository
    : UniversityRepositery<Hall>
    , IHallRepository
{
    public HallRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

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

    public async Task<string> IsOfficeAvillibleForDoctor(Office office, int DepId)
    {
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
public class LabRepository
    : UniversityRepositery<Lab>
    , ILabRepository
{
    public LabRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class StudentSubjectRepository(AppDbContext AppDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentSubject>(AppDbContext, memoryCache)
    , IStudentSubjectRepository
{
}
public class SubjectRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Subject>(appDbContext, memoryCache)
    , ISubjectRepository
{
    public async override Task<ICollection<Subject>> GetAllWhere(Expression<Func<Subject, bool>> filter, bool AsNoTracking = false)
    {
        var Courses = await _appDbContext.Subjects.Include(c => c.Doctor)
            .Where(filter).ToListAsync();
        return Courses;
    }
}
public class UserTokenRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<UserToken>(appDbContext, memoryCache)
    , IUserTokenRepository
{
}



