namespace UniversityProject.Infrustructure.StudentRepositories;

public interface IStudentRepository
    : IRepositiry<Student>
{
    Task<List<Course>> GetStudentCourses(Student student);
    Task<List<Section>> GetStudentSections(Student student);
}
public interface IDepartmentRepository
    : IRepositiry<Department>
{ }
public interface IStudentCourseRepository
    : IRepositiry<StudentCourse>
{ }
public interface ICourseRepository
    : IRepositiry<Course>
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
    public Task<string> IsOfficeAvillibleForTeachingAssistant(Office office, int DepId);

}
public interface IHallRepository
    : IRepositiry<Hall>
{
    public Task<Hall> FindByNameAsync(string Name);
}
public interface ILabRepository
    : IRepositiry<Lab>
{
    public Task<Lab> FindByNameAsync(string Name);
}
public interface IUserTokenRepository
    : IRepositiry<UserToken>
{ }
