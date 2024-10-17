namespace SchoolProject.Infrustructure.GenericRepositiry;

public class SchoolRepositery<T>(AppDbContext appDbContext)
    : IRepositiry<T> where T : class
{
    public virtual async Task<T> AddAsync(T entity)
    {
        appDbContext.Set<T>().Add(entity);

        await appDbContext.SaveChangesAsync();

        return entity;
    }
    public virtual async Task<ICollection<T>> AddRangeAsync(
        ICollection<T> entities)
    {
        appDbContext.Set<T>().AddRange(entities);

        await appDbContext.SaveChangesAsync();

        return entities;
    }
    public virtual async Task<bool> DeleteAsync(T entity)
    {
        appDbContext.Set<T>().Remove(entity);

        await appDbContext.SaveChangesAsync();

        return true;
    }
    public virtual async Task<ICollection<T>> GetAllAsync(
        bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var students = await appDbContext.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return students;
        }
        var students2 = await appDbContext.Set<T>()
            .ToListAsync();

        return students2;
    }
    public virtual async Task<ICollection<T>> GetAllWhere(
        Expression<Func<T, bool>> filter
        , bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var students = await appDbContext.Set<T>()
                .AsNoTracking()
                .Where(filter)
                .ToListAsync();

            return students;
        }
        var students2 = await appDbContext.Set<T>()
            .Where(filter)
            .ToListAsync();

        return students2;
    }
    public virtual async Task<T> GetOneAsync(
        Expression<Func<T, bool>> filter
        , bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var entity = await appDbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);

            return entity!;
        }
        var entity2 = await appDbContext.Set<T>()
            .FirstOrDefaultAsync(filter);

        return entity2!;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        appDbContext.Set<T>().Update(entity);

        await appDbContext.SaveChangesAsync();

        return entity;
    }
    public IQueryable<T> GetAsQueriable()
    {
        return AsNoTracking();
    }
    public IQueryable<T> AsNoTracking()
    {
        return appDbContext.Set<T>().AsNoTracking().AsQueryable();
    }
    public IDbContextTransaction BeginTransaction()
    {
        return appDbContext.Database.BeginTransaction();
    }
    public void CommitTransaction()
    {
        appDbContext.Database.CommitTransaction();
    }
    public void RollbackTransaction()
    {
        appDbContext.Database.RollbackTransaction();
    }

    public async Task<T> FindAsync(int id)
    {
        T? Entity = await appDbContext.Set<T>()
            .FindAsync(id);

        return Entity!;
    }
}
