namespace UniversityProject.Infrustructure.DepartmentRepositories;

public class DepartmentRepository
    : UniversityRepositery<Department>
    , IDepartmentRepository
{
    public DepartmentRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class SectionRepository
    : UniversityRepositery<Section>
    , ISectionRepository
{
    public SectionRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

}
public class DoctorRepository
    : UniversityRepositery<Doctor>
    , IDoctorRepository
{
    public DoctorRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

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
public class OfficeRepository
    : UniversityRepositery<Office>
    , IOfficeRepository
{
    public OfficeRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
        : base(appDbContext, memoryCache) { }

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


