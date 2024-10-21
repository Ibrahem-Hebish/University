using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.StudentSubjectRepositories;

public class StudentSubjectRepository(AppDbContext AppDbContext, IMemoryCache memoryCache)
        : SchoolRepositery<StudentSubject>(AppDbContext, memoryCache)
    , IStudentSubjectRepository
{
}
