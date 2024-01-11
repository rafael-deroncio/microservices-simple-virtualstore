using Refit;
using VirtualStore.Cart.Core.Requests;
using VirtualStore.Cart.Core.Responses;

namespace VirtualStore.Cart.Core.Services.Clients;

public interface ITokenClientService
{
    [Get("")]
    Task<TokenResponse> GetTokensAuthentication([Body] TokenRequest request);
}