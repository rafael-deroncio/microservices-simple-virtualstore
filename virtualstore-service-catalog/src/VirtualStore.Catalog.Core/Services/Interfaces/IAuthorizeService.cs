using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services.Interfaces;

public interface IAuthorizeService
{
    Task<TokenAuthorizationResponse> GetAuthorizationToken();
}