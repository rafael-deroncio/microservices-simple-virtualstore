using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

public interface IAccountService
{
    Task<SignInResponse> SignIn(SignInRequest request);

    Task<SignOutResponse> SignOut(SignOutRequest request);

    Task<LogInResponse> LogIn(LogInRequest request);

    Task<UnsubscribeResponse> Unsubscribe(UnsubscribeRequest request);
}