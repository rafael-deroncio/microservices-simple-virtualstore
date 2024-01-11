using Refit;
using VirtualStore.Discount.Core.Requests;
using VirtualStore.Discount.Core.Responses;

namespace VirtualStore.Discount.Core.Services.Clients;

public interface ITokenClientService
{
    [Get("")]
    Task<TokenResponse> GetTokensAuthentication([Body] TokenRequest request);
}