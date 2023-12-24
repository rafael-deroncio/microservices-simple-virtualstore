using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

public interface IAuthorizeService
{
    Task<TokenResponse> GetTokenAuthentication(TokenRequest request);

    Task<TokenResponse> ValidateTokenAuthentication(ValidateTokenRequest request);
}