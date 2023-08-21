using VirtualStore.Web.Core.ViewModels;

namespace VirtualStore.Web.Core.Services.Interfaces;

public interface IUserService
{
    Task<UserViewModel> GetUserAsync(string username);
    Task<bool> CreateUserAsync(UserViewModel user);
    Task<bool> UpdateUserAsync(UserViewModel user);
    Task<bool> DeleteUserAsync(UserViewModel user);
}