using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class AuthorizeService : IAuthorizeService
{
    private readonly IJwtTokenService _jwtTokenService;

    public AuthorizeService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    private async Task<TokenResponse> GenerateAuthorizationToken()
    {
        var jwt = await _jwtTokenService.GenerateBearerToken();

        return new TokenResponse
        {
            Token = jwt.TokenValue,
            Expires = jwt.Expires,
            Message = jwt.Message
        };
    }

    public Task<TokenResponse> GetTokenAuthentication(TokenRequest request)
    {
        return GenerateAuthorizationToken();
    }

    public Task<TokenResponse> ValidateTokenAuthentication(ValidateTokenRequest request)
    {
        throw new NotImplementedException();
    }
}