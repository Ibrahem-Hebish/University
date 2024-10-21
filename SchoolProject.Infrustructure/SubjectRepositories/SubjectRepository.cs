using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.SubjectRepositories;

public class SubjectRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
    : SchoolRepositery<Subject>(appDbContext, memoryCache)
    , ISubjectRepository
{
}
