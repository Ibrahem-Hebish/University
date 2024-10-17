namespace SchoolProject.Infrustructure.DepartmentRepositories
{
    public class DepartmentRepository
        : SchoolRepositery<Department>
        , IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext appDbContext)
            : base(appDbContext) { }

    }
}
