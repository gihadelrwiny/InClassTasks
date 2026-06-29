using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Shared.Exceptions;

namespace WebApplication1.Shared.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = exception is NotFoundException ?
                StatusCodes.Status404NotFound: StatusCodes.Status500InternalServerError;


            await httpContext.Response.WriteAsJsonAsync(
                new ProblemDetails
                {
                    Title = exception is NotFoundException
                    ? "Not Found" : "Server Error",
                    Status = httpContext.Response.StatusCode,
                    Detail = exception.Message
                }, cancellationToken
                );
            return true;
        }
    }
}
