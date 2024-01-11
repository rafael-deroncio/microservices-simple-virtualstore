using Refit;
using VirtualStore.Cart.Core.Responses;

namespace VirtualStore.Cart.Core.Services.Clients;

public interface IAccountClientService
{
    [Get("/{username}")]
    Task<UserResponse> GetUser([AliasAs("username")] string username);
}