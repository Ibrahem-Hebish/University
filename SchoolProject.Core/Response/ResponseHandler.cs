namespace SchoolProject.Core.Response;

public class ResponseHandler
{
    public Response<T> Created<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Created,
            message = message ?? "Created Successfully",
            Success = true,
        };
    }
    public Response<T> Deleted<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NoContent,
            message = message ?? "Deleted Successfully",
            Success = true,
        };
    }
    public Response<T> NotFouned<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NotFound,
            message = message ?? "Entity is not founed",
            Success = false,
        };
    }
    public Response<T> Success<T>(T data)
    {
        return new Response<T>()
        {
            Data = data,
            StatusCode = HttpStatusCode.OK,
            message = "Success",
            Success = true,
        };
    }
    public Response<T> NoContent<T>(string message = null)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.NoContent,
            message = message ?? "Success process",
            Success = true,
        };
    }
    public Response<T> BadRequest<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            message = message ?? "Bad Request",
            Success = false,
        };
    }
    public Response<T> UnAuthorize<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.Unauthorized,
            message = message ?? "Unauthorized",
            Success = false,
        };
    }
    public Response<T> InternalServerError<T>(string message = null!)
    {
        return new Response<T>()
        {
            StatusCode = HttpStatusCode.InternalServerError,
            message = message ?? "An error happens while saving the data",
            Success = false,
        };
    }
    public Response<T> UnprocessableEntity<T>(T entity = null!) where T : class
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = HttpStatusCode.UnprocessableEntity,
            message = "UnprocessableEntity",
            Success = false,
        };
    }
}
