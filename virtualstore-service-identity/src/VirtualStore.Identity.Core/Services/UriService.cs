using Microsoft.AspNetCore.Http;
using VirtualStore.Identity.Core.Services.Interfaces;

namespace VirtualStore.Catalog.Core.Services;

public class UriService : IUriService
{
    private readonly IHttpContextAccessor _accessor;

    public UriService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public Uri GetEndpoint()
    {
        var uri = new UriBuilder()
        {
            Scheme = _accessor.HttpContext.Request.Scheme,
            Host = _accessor.HttpContext.Request.Host.Host,
            Port = _accessor.HttpContext.Request.Host.Port.Value,
            Path = _accessor.HttpContext.Request.Path,
        };

        return uri.Uri;
    }
}