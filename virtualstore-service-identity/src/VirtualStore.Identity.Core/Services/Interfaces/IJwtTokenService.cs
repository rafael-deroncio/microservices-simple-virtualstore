using VirtualStore.Identity.Core.Models;

public  interface IJwtTokenService
{
    Task<TokenModel> GenerateBearerToken();
}