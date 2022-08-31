using System.Text.Json;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Lapka.Pet.Infrastructure.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ProjectException ex)
        {
            context.Response.StatusCode = ex._errorCode;
            context.Response.Headers.Add("content-type", "application/json");

            var errorCode = ex._errorCode;
            var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });
            await context.Response.WriteAsync(json);
        }
        catch (DomainException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");

            var errorCode = 400;
            var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });
            await context.Response.WriteAsync(json);
        }
        catch (DomainForbidden ex)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}