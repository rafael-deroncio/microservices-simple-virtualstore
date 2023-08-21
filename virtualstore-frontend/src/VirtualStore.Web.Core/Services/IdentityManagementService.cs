using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.Services.Interfaces;
using VirtualStore.Web.Core.ViewModels;

namespace VirtualStore.Web.Core.Services;

public class IdentityManagementService : IIdentityManagementService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserService _userService;

    public IdentityManagementService(IHttpContextAccessor httpContextAccessor, IUserService userService)
    {
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public async Task<LogInResultModel> LoginAsync(LoginViewModel login)
    {
        UserViewModel user = await _userService.GetUserAsync(login.Username);

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        ClaimsIdentity claimsIdentity = new(
            claims: claims, 
            authenticationType: CookieAuthenticationDefaults.AuthenticationScheme);

        await _httpContextAccessor.HttpContext.SignInAsync(
            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
            principal: new ClaimsPrincipal(claimsIdentity));

        return new LogInResultModel 
        {
            Username = user.Username,
            Result = true,
            Message = string.Empty,
            Token = string.Empty,
        };
    }

    public async Task LogoutAsync()
        => await _httpContextAccessor.HttpContext.SignOutAsync();

    public Task<SignInResultModel> SignInAsync(UserViewModel user)
    {
        throw new NotImplementedException();
    }
}