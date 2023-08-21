using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Responses;

namespace VirtualStore.Identity.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (APICustomException ex)
        {
            ExceptionResponse errorResponse = new()
            {
                ResponseType = ex.ResponseType,
                Tittle = "Erro",
                Messages = new[] { ex.Message }
            };

            string jsonResponse = JsonSerializer.Serialize(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.StatusCode;

            await context.Response.WriteAsync(jsonResponse);
        }
        catch (Exception ex)
        {
            ExceptionResponse errorResponse = new()
            {
                ResponseType = ExceptionResponseType.Error,
                Tittle = "Erro",
                Messages = new[] { $"An error occurred while processing the request. {ex.Message}" }
            };

            string jsonResponse = JsonSerializer.Serialize(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}

