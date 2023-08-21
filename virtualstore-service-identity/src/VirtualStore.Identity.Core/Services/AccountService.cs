using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class AccountService : IAccountService
{
    public Task<LogInResponse> LogIn(LogInRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<SignInResponse> SignIn(SignInRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<SignOutResponse> SignOut(SignOutRequest request)
    {
        throw new NotImplementedException();
    }
}