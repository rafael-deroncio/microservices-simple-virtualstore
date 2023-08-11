using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services;

public class AuthorizeService : IAuthorizeService
{
    private readonly IJwtTokenService _jwtTokenService;

    public AuthorizeService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public async Task<TokenAuthorizationResponse> GetAuthorizationToken()
    {
        var jwt = await _jwtTokenService.GenerateBearerToken();

        return new TokenAuthorizationResponse
        {
            Token = jwt.Token,
            Expires = jwt.Expires,
            Message = jwt.Message
        };
    }
}