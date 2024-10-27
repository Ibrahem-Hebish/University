namespace UniversityProject.Infrustructure.StudentRepositories;

public interface IStudentRepository
    : IRepositiry<Student>
{ }
public interface IDepartmentRepository
    : IRepositiry<Department>
{ }
public interface IStudentSubjectRepository
    : IRepositiry<StudentSubject>
{ }
public interface ISubjectRepository
    : IRepositiry<Subject>
{ }
public interface ISectionRepository
    : IRepositiry<Section>
{ }
public interface IDoctorRepository
    : IRepositiry<Doctor>
{ }
public interface IStudentDoctorRepository
    : IRepositiry<StudentDoctors>
{ }
public interface ITeachingAssistantRepository
    : IRepositiry<TeachingAssistant>
{ }
public interface IStudentTeachingAssistantsRepository
    : IRepositiry<StudentTeachingAssistants>
{ }
public interface IStudentSectionsRepository
    : IRepositiry<StudentSections>
{ }
public interface IOfficeRepository
    : IRepositiry<Office>
{
    public Task<Office> FindByNameAsync(string Name);
    public Task<string> IsOfficeAvillibleForDoctor(Office office, int DepId);
}
public interface IHallRepository
    : IRepositiry<Hall>
{ }
public interface ILabRepository
    : IRepositiry<Lab>
{ }
public interface IUserTokenRepository
    : IRepositiry<UserToken>
{ }
