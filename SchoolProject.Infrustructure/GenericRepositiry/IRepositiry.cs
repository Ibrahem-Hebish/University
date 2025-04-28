namespace UniversityProject.Infrustructure.GenericRepositiry;

public interface IRepositiry<T>
{
    Task<T> FindAsync(int id);
    Task<IEnumerable<T>> GetAllAsync(bool AsNoTracking = false);
    IQueryable<T> GetAsQueriable();
    Task<T> GetOneAsync(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity, object id);
    Task<bool> DeleteAsync(T entity, object id);
    Task<bool> DeleteRangeAsync(IEnumerable<T> entities);

    IQueryable<T> AsNoTracking();
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
