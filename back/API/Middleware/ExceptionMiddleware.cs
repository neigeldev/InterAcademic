using Application.DTOs.Common;
using System.Net;
using System.Text.Json;
namespace API.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning(ex, "Business rule violation: {Message}", ex.Message);
            await WriteResponseAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error: {Message}", ex.Message);
            await WriteResponseAsync(
                context,
                HttpStatusCode.InternalServerError,
                ex.Message  // <- cambia esto temporalmente
            );
        }
    }

    private static async Task WriteResponseAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponse
        {
            Message = message,
            RequestId = context.TraceIdentifier
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}