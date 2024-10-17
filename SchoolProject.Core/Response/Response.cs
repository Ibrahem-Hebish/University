namespace SchoolProject.Core.Response;

public class Response<T>
{
    public T? Data { get; set; }
    public string? message { get; set; }
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public Response()
    {

    }
    public Response(T data, string m)
    {
        Data = data;
        message = m;
        Success = true;
    }
    public Response(string m)
    {
        message = m;
        Success = false;
    }
}
