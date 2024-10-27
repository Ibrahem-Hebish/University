namespace UniversityProject.Infrustructure.StudentSubjectRepositories;

public class StudentSubjectRepository(AppDbContext AppDbContext, IMemoryCache memoryCache)
        : UniversityRepositery<StudentSubject>(AppDbContext, memoryCache)
    , IStudentSubjectRepository
{
}
