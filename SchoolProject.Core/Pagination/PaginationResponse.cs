namespace UniversityProject.Core.Pagination;

public class PaginationResponse<T>
{
    public bool PreviusPage => CurrentPage > 1 && TotalPages > 1;
    public bool FollowingPage => CurrentPage < TotalPages && TotalPages > 1;
    public int Count { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public bool Successed { get; set; }
    public List<T>? Data { get; set; }


    public PaginationResponse() { }
    public PaginationResponse(List<T> data, int count, int pagenumber, int pagesize)
    {
        Data = data;
        Count = count;
        CurrentPage = pagenumber;
        PageSize = Count < pagesize ? Count : pagesize;
        Successed = true;
        TotalPages = (int)Math.Ceiling((double)count / PageSize);
    }
    public PaginationResponse<T> Success(List<T> data, int count, int pagenumber, int pagesize)
    {
        return new(data, count, pagenumber, pagesize);

    }
}
