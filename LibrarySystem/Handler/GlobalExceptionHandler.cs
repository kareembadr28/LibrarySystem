using LibrarySystem.Exceptions;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace LibrarySystem.Handler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ExceptionResponse response;
            

            if (exception is BaseException baseEx)
            {
                httpContext.Response.StatusCode = (int)baseEx.statusCode;
                response = new ExceptionResponse
                {
                    Message = baseEx.Message,
                    Status = $"{(int)baseEx.statusCode} {baseEx.statusCode}"
                };
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                response = new ExceptionResponse
                {
                    Message = "An unexpected error occurred",
                    Status = "500 InternalServerError"
                };
            }

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken);

            return true;
        }
    }
}
