namespace UniversityProject.Core.Response;

public class Response<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public Response()
    {

    }
    public Response(T data, string m)
    {
        Data = data;
        Message = m;
        Success = true;
    }
    public Response(string m)
    {
        Message = m;
        Success = false;
    }
}
