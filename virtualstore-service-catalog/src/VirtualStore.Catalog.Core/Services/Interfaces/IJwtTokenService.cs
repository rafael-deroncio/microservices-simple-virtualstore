using VirtualStore.Catalog.Core.Models;

namespace VirtualStore.Catalog.Core.Services.Interfaces;

public  interface IJwtTokenService
{
    Task<TokenModel> GenerateBearerToken();
}