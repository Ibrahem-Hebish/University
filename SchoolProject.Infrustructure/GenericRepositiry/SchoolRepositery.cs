using Microsoft.Extensions.Caching.Memory;

namespace SchoolProject.Infrustructure.GenericRepositiry;

public class SchoolRepositery<T>(AppDbContext appDbContext, IMemoryCache memoryCache)
    : IRepositiry<T> where T : class
{
    public async Task<T> FindAsync(int id)
    {
        if (!memoryCache.TryGetValue($"{typeof(T).Name}:{id}", out T? result))
        {
            T? Entity = await appDbContext.Set<T>()
            .FindAsync(id);

            var options = SetMemoryCacheOptions();

            memoryCache.Set($"{typeof(T).Name}:{id}", Entity, options);

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
            var entity = await appDbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(filter);

            return entity!;
        }
        var entity2 = await appDbContext.Set<T>()
            .FirstOrDefaultAsync(filter);

        return entity2!;
    }
    public virtual async Task<ICollection<T>> GetAllAsync(
        bool AsNoTracking = false)
    {
        if (!memoryCache.TryGetValue(typeof(T).Name, out ICollection<T>? value))
        {

            var query = appDbContext.Set<T>().AsQueryable();

            var options = SetMemoryCacheOptions();

            if (AsNoTracking)
                query = query.AsNoTracking();

            memoryCache.Set(typeof(T).Name, query, options);

            return await query.ToListAsync();
        }
        return value!;
    }
    public virtual async Task<ICollection<T>> GetAllWhere(
        Expression<Func<T, bool>> filter
        , bool AsNoTracking = false)
    {
        var query = appDbContext.Set<T>().AsQueryable();
        if (!memoryCache.TryGetValue($"{typeof(T).Name} {filter.Name}", out IQueryable<T>? value))
        {
            if (AsNoTracking)
                query = query.AsNoTracking();

            var options = SetMemoryCacheOptions();

            memoryCache.Set($"{typeof(T).Name} {filter.Name}", query, options);

            return await query.Where(filter).ToListAsync();
        }
        return await value!.ToListAsync();
    }


    public virtual async Task<T> AddAsync(T entity)
    {
        appDbContext.Set<T>().Add(entity);

        await appDbContext.SaveChangesAsync();

        memoryCache.Remove(typeof(T).Name);

        return entity;
    }
    public virtual async Task<ICollection<T>> AddRangeAsync(
        ICollection<T> entities)
    {
        appDbContext.Set<T>().AddRange(entities);

        await appDbContext.SaveChangesAsync();

        memoryCache.Remove(typeof(T).Name);

        return entities;
    }
    public virtual async Task<bool> DeleteAsync(T entity, int id)
    {
        appDbContext.Set<T>().Remove(entity);

        await appDbContext.SaveChangesAsync();

        memoryCache.Remove(typeof(T).Name);

        memoryCache.Remove($"{typeof(T).Name}:{id}");

        return true;
    }

    public async Task<T> UpdateAsync(T entity, int id)
    {
        appDbContext.Set<T>().Update(entity);

        await appDbContext.SaveChangesAsync();

        memoryCache.Remove(typeof(T).Name);

        memoryCache.Remove($"{typeof(T).Name}:{id}");

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

    private static MemoryCacheEntryOptions SetMemoryCacheOptions()
    {
        var options = new MemoryCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2),
            SlidingExpiration = TimeSpan.FromMinutes(1),
            Priority = CacheItemPriority.Normal,
        };

        return options;
    }
}
