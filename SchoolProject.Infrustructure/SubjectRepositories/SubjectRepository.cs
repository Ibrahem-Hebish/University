namespace SchoolProject.Infrustructure.SubjectRepositories;

public class SubjectRepository(AppDbContext appDbContext)
    : SchoolRepositery<Subject>(appDbContext)
    , ISubjectRepository
{
}
