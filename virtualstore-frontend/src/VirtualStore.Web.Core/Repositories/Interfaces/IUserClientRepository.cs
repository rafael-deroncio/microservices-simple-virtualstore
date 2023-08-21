namespace VirtualStore.Web.Core.Repositories.Interfaces;

public interface IUserClientRepository
{
    public Task<UserResponse> GetUserAsync(string username);
    public Task<UserResponse> CreateUserAsync(UserRequest request);
}
