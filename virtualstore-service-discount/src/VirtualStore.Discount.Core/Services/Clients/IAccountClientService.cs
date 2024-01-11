using Refit;
using VirtualStore.Discount.Core.Responses;

namespace VirtualStore.Discount.Core.Services.Clients;

public interface IAccountClientService
{
    [Get("/{username}")]
    Task<UserResponse> GetUser([AliasAs("username")] string username);
}