using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedInfrastructure.Exceptions;
using System;
using System.Text.Json;
using System.Threading;

namespace SharedInfrastructure.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            var response = new
            {
                Message = exception.Message
            };

            switch (exception)
            {
                case ValidationException:
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;

                case UnauthorizedException:
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;

                case NotFoundException:
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;

                case ConflictException:
                    httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                    break;

                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(response),
                cancellationToken);

            return true;
        }
    }
}