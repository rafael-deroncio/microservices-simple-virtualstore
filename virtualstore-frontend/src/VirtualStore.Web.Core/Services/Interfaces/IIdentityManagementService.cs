using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.ViewModels;

namespace VirtualStore.Web.Core.Services.Interfaces;

public interface IIdentityManagementService
{
    Task<SignInResultModel> SignInAsync(UserViewModel user);

    Task<LogInResultModel> LoginAsync(LoginViewModel login);

    Task LogoutAsync();
}