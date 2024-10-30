namespace UniversityProject.Infrustructure.GenericRepositiry;

public class UniversityRepositery<T>
    : IRepositiry<T> where T : class
{
    protected AppDbContext _appDbContext;
    protected readonly IMemoryCache _memoryCache;
    public UniversityRepositery(AppDbContext appDbContext, IMemoryCache memoryCache)
    {
        _appDbContext = appDbContext;
        _memoryCache = memoryCache;
    }
    public virtual async Task<T> FindAsync(int id)
    {
        if (!_memoryCache.TryGetValue($"{typeof(T).Name}:{id}", out T? result))
        {
            T? Entity = await _appDbContext.Set<T>()
            .FindAsync(id);

            var options = Set_memoryCacheOptions();

            _memoryCache.Set($"{typeof(T).Name}:{id}", Entity, options);

            await Console.Out.WriteLineAsync($"{typeof(T).Name} with id {id} is comming from DB");

            return Entity!;
        }
        await Console.Out.WriteLineAsync($"{typeof(T).Name} with id {id} is comming from Cacheing");

        return result!;
    }

    public virtual async Task<T> GetOneAsync(
        Expression<Func<T, bool>> filter
        , bool AsNoTracking = false)
    {
        if (AsNoTracking)
        {
            var entity = await _appDbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);

            return entity!;
        }
        var entity2 = await _appDbContext.Set<T>()
            .FirstOrDefaultAsync(filter);

        return entity2!;
    }
    public virtual async Task<ICollection<T>> GetAllAsync(
        bool AsNoTracking = false)
    {
        if (!_memoryCache.TryGetValue(typeof(T).Name, out ICollection<T>? value))
        {

            var query = _appDbContext.Set<T>().AsQueryable();

            var options = Set_memoryCacheOptions();

            if (AsNoTracking)
                query = query.AsNoTracking();

            _memoryCache.Set(typeof(T).Name, query.ToList(), options);

            return await query.ToListAsync();
        }
        return value!;
    }
    public virtual async Task<ICollection<T>> GetAllWhere(
        Expression<Func<T, bool>> filter
        , bool AsNoTracking = false)
    {
        var query = _appDbContext.Set<T>().AsQueryable();
        if (!_memoryCache.TryGetValue($"{typeof(T).Name} {filter.Name}", out IQueryable<T>? value))
        {
            if (AsNoTracking)
                query = query.AsNoTracking();

            var options = Set_memoryCacheOptions();

            _memoryCache.Set($"{typeof(T).Name} {filter.Name}", query.ToList(), options);

            return await query.Where(filter).ToListAsync();
        }
        return await value!.ToListAsync();
    }


    public virtual async Task<T> AddAsync(T entity)
    {
        var Result = _appDbContext.Set<T>().Add(entity);

        await _appDbContext.SaveChangesAsync();

        _memoryCache.Remove(typeof(T).Name);

        return Result.Entity;
    }
    public virtual async Task<ICollection<T>> AddRangeAsync(
        ICollection<T> entities)
    {
        _appDbContext.Set<T>().AddRange(entities);

        await _appDbContext.SaveChangesAsync();

        _memoryCache.Remove(typeof(T).Name);

        return entities;
    }
    public virtual async Task<bool> DeleteAsync(T entity, int id)
    {
        _appDbContext.Set<T>().Remove(entity);

        await _appDbContext.SaveChangesAsync();

        _memoryCache.Remove(typeof(T).Name);

        _memoryCache.Remove($"{typeof(T).Name}:{id}");

        return true;
    }

    public async Task<bool> DeleteRangeAsync(ICollection<T> entities)
    {
        _appDbContext.Set<T>().RemoveRange(entities);

        await _appDbContext.SaveChangesAsync();

        _memoryCache.Remove(typeof(T).Name);

        return true;
    }
    public async Task<T> UpdateAsync(T entity, int id)
    {
        _appDbContext.Set<T>().Update(entity);

        await _appDbContext.SaveChangesAsync();

        _memoryCache.Remove(typeof(T).Name);

        _memoryCache.Remove($"{typeof(T).Name}:{id}");

        return entity;
    }
    public IQueryable<T> GetAsQueriable()
    {
        return AsNoTracking();
    }
    public IQueryable<T> AsNoTracking()
    {
        return _appDbContext.Set<T>().AsNoTracking().AsQueryable();
    }
    public IDbContextTransaction BeginTransaction()
    {
        return _appDbContext.Database.BeginTransaction();
    }
    public void CommitTransaction()
    {
        _appDbContext.Database.CommitTransaction();
    }
    public void RollbackTransaction()
    {
        _appDbContext.Database.RollbackTransaction();
    }

    protected static MemoryCacheEntryOptions Set_memoryCacheOptions()
    {
        var options = new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2),
            SlidingExpiration = TimeSpan.FromMinutes(1),
            Priority = CacheItemPriority.Normal,
        };

        return options;
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
