
using System.Text.Json;

namespace Universityproject.Api.Middlewares
{
    public class GlobalHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails problemDetails = new()
                {
                    Status = context.Response.StatusCode,
                    Detail = ex.Message,
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));

            }
        }
    }
}
