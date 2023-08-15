using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using VirtualStore.Catalog.Core.Configurations.Enums;
using VirtualStore.Catalog.Core.Exceptions;
using VirtualStore.Catalog.Core.Responses;

namespace VirtualStore.Catalog.Core.Middlewares;

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
                ResponseType = ExceptionResponseTypeEnum.Error,
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

