namespace UniversityProject.Infrustructure.GenericRepositiry;

public interface IRepositiry<T>
{
    Task<T> FindAsync(int id);
    Task<ICollection<T>> GetAllAsync(bool AsNoTracking = false);
    IQueryable<T> GetAsQueriable();
    Task<T> GetOneAsync(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<ICollection<T>> GetAllWhere(Expression<Func<T, bool>> filter, bool AsNoTracking = false);
    Task<T> AddAsync(T entity);
    Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
    Task<T> UpdateAsync(T entity, int id);
    Task<bool> DeleteAsync(T entity, int id);
    Task<bool> DeleteRangeAsync(ICollection<T> entities);

    IQueryable<T> AsNoTracking();
    IDbContextTransaction BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
