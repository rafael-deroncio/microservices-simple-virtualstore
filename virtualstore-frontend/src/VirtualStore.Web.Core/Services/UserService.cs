using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Core.Services;

public class UserService : IUserService
{

    public Task<bool> CreateUserAsync(UserViewModel user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(UserViewModel user)
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModel> GetUserAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserAsync(UserViewModel user)
    {
        throw new NotImplementedException();
    }
}