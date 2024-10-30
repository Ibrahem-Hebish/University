namespace UniversityProject.Services.AbstractionServices;

public interface IStudentService
{
    public Task<Student> GetStudentById(int id);

    public Task<Student> GetStudentByName(string name);

    public Task<List<Student>> GetAll();

    public Task<Student> AddAsync(Student student);

    public Task<Student> Update(Student student);

    public Task<bool> DeleteStudent(int id);

    public Task<ICollection<Student>> GroupStudentsByDepartment(string depname);

    public Task<ICollection<Student>> GroupStudentsByCourse(string subname);

    IQueryable<Student> GetAsQueriable();

    IQueryable<Student> Filter(StudentOrderEnum? studentOrder, string? search);
}
