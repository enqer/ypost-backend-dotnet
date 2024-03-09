
using ypost_backend_dotnet.Exceptions;

namespace ypost_backend_dotnet.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {

        public ErrorHandlingMiddleware() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception ex)
            {
                // logger

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
