using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.DepartmentRepositories
{
    public class DepartmentRepository
        : SchoolRepositery<Department>
        , IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext appDbContext, IMemoryCache memoryCache)
            : base(appDbContext, memoryCache) { }

    }
}
