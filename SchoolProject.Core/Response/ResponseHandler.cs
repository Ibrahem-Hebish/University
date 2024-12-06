namespace UniversityProject.Core.Response;

public class ResponseHandler
{
    public static Response<T> Created<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Created,
            Message = message ?? "Created Successfully",
            Success = true,
        };
    }
    public static Response<T> Deleted<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NoContent,
            Message = message ?? "Deleted Successfully",
            Success = true,
        };
    }
    public static Response<T> NotFouned<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = message ?? "Entity is not founed",
            Success = false,
        };
    }
    public static Response<T> Success<T>(T data, string message = null!)
    {
        return new Response<T>()
        {
            Data = data,
            StatusCode = HttpStatusCode.OK,
            Message = message ?? "Success",
            Success = true,
        };
    }
    public static Response<T> NoContent<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NoContent,
            Message = message ?? "Success process",
            Success = true,
        };
    }
    public static Response<T> BadRequest<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            Message = message ?? "Bad Request",
            Success = false,
        };
    }
    public static Response<T> UnAuthorize<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Message = message ?? "Unauthorized",
            Success = false,
        };
    }
    public static Response<T> InternalServerError<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Message = message ?? "An error happens while saving the data",
            Success = false,
        };
    }
    public static Response<T> UnprocessableEntity<T>(T entity = null!) where T : class
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.UnprocessableEntity,
            Message = "UnprocessableEntity",
            Success = false,
        };
    }
}
