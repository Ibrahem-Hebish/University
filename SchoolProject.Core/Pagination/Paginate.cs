namespace UniversityProject.Core.Pagination;

public static class Paginate
{
    public static async Task<PaginationResponse<T>> ToPaginate<T>(
        this IQueryable<T> source,
        int pagenumber = 1,
        int pagesize = 10)
    {
        if (source is null) throw new ArgumentNullException("source can not be null");

        pagenumber = pagenumber == 0 ? 1 : pagenumber;

        pagesize = pagesize == 0 ? 10 : pagesize;

        var sourcerecords = await source.CountAsync();

        var result = await source
            .Skip((pagenumber - 1) * pagesize)
            .Take(pagesize)
            .ToListAsync();

        return new PaginationResponse<T>(
            result,
            sourcerecords,
            pagenumber,
            pagesize);
    }
}
