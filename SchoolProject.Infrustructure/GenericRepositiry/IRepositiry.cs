namespace SchoolProject.Infrustructure.GenericRepositiry;

public interface IRepositiry<T>
{
    Task<ICollection<T>> GetAllAsync(bool AsNoTracking = false);
    Task<T> FindAsync(int id);
    IQueryable<T> GetAsQueriable();
    Task<T> GetOneAsync(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<ICollection<T>> GetAllWhere(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<T> AddAsync(T entity);
    Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    IQueryable<T> AsNoTracking();
    IDbContextTransaction BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
