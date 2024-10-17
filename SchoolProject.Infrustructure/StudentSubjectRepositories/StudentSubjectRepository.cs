namespace SchoolProject.Infrustructure.StudentSubjectRepositories;

public class StudentSubjectRepository(AppDbContext AppDbContext)
        : SchoolRepositery<StudentSubject>(AppDbContext)
    , IStudentSubjectRepository
{
}
