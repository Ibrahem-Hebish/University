namespace UniversityProject.Infrustructure.SubjectRepositories;

public class SubjectRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : UniversityRepositery<Subject>(appDbContext, memoryCache)
    , ISubjectRepository
{
}
