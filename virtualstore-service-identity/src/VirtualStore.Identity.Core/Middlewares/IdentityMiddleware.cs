using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStore.Identity.Core.Middlewares;

public class IdentityMiddleware
{
    private readonly RequestDelegate _next;

    public IdentityMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public IdentityMiddleware()
    {
        
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Lógica do middleware aqui, antes de passar para o próximo middleware.

        // Exemplo: Definindo um cabeçalho personalizado.
        context.Response.Headers.Add("X-Identity-Middleware", "Executado");

        // Chama o próximo middleware na cadeia.
        await _next(context);

        // Lógica do middleware aqui, após o retorno do próximo middleware.
    }
}