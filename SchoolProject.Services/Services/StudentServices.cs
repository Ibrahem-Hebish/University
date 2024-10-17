namespace SchoolProject.Services.Services;

public class StudentServices(
    IStudentRepository studentRepository)

    : IStudentService
{

    public async Task<Student> AddAsync(Student student)
    {
        var exsistingStudent = await studentRepository
            .GetOneAsync(
            s => s.Phone.Equals(
                student.Phone)
            , true);

        if (exsistingStudent is not null) return null!;

        var newStudent = await studentRepository.AddAsync(student);
        return newStudent;
    }

    public async Task<bool> DeleteStudent(int id)
    {
        var student = await studentRepository.FindAsync(id);

        if (student is not null)
        {
            await studentRepository.DeleteAsync(student);

            return true;
        }
        return false;
    }

    public IQueryable<Student> Filter(StudentOrderEnum? studentOrder,
                                      string? search)
    {
        var students = GetAsQueriable();

        if (search is not null)
            students.Where(s =>
            s.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)
           || s.Address.Contains(search, StringComparison.CurrentCultureIgnoreCase));

        switch (studentOrder)
        {
            case StudentOrderEnum.Name:
                students = students.OrderBy(s => s.Name);
                break;
            case StudentOrderEnum.Address:
                students = students.OrderBy(s => s.Address);
                break;
            case StudentOrderEnum.Phone:
                students = students.OrderBy(s => s.Phone);
                break;
            case StudentOrderEnum.DepName:
                students = students.OrderBy(s => s.Department.Name);
                break;
            default:
                break;
        }
        return students;
    }

    public async Task<List<Student>> GetAll()
    {
        var students = await studentRepository.GetAllAsync(true);

        return [.. students];
    }

    public IQueryable<Student> GetAsQueriable()
    {
        return studentRepository.AsNoTracking()
            .Include(s => s.Subjects)
            .Include(s => s.Department);
    }

    public async Task<Student> GetStudentById(int id)
    {
        var student = await studentRepository.FindAsync(id);

        return student;
    }

    public async Task<Student> GetStudentByName(string name)
    {
        var student = await studentRepository.GetOneAsync(s => s.Name == name, true);
        return student;
    }

    public async Task<ICollection<Student>> GroupStudentsByDepartment(string depname)
    {
        var DepStudents = await studentRepository.GetAllWhere(s =>
        s.Department.Name.Equals(depname, StringComparison.CurrentCultureIgnoreCase), true);

        return DepStudents;
    }

    public async Task<ICollection<Student>> GroupStudentsBySubject(string subname)
    {
        var DepStudents = await studentRepository.GetAllWhere
            (s => s.Subjects.Select(s => s.Name.ToLower())
            .Any(n => n.Equals(subname, StringComparison.CurrentCultureIgnoreCase)), true);

        return DepStudents;
    }

    public async Task<Student> Update(Student student)
    {
        var exsistingStudent = await studentRepository.FindAsync(student.Id);

        if (exsistingStudent is null) return null!;

        var s = await studentRepository.UpdateAsync(student);
        return s;
    }

}
