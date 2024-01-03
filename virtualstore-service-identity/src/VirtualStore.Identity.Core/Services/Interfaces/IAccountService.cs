using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

/// <summary>
/// Represents a service interface for user account management and authentication.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Signs in a user based on the provided sign-in request.
    /// </summary>
    /// <param name="request">The sign-in request containing user credentials.</param>
    /// <param name="userAgent">The User-Agent header from the HTTP request.</param>
    /// <param name="ipAddress">The IP address of the client.</param>
    /// <returns>An asynchronous task that represents the operation and contains the sign-in response.</returns>
    Task<SignInResponse> SignIn(SignInRequest request, string userAgent, string ipAddress);

    /// <summary>
    /// Signs out a user based on the provided sign-out request.
    /// </summary>
    /// <param name="request">The sign-out request containing user information.</param>
    /// <param name="userAgent">The User-Agent header from the HTTP request.</param>
    /// <param name="ipAddress">The IP address of the client.</param>
    /// <returns>An asynchronous task that represents the operation and contains the sign-out response.</returns>
    Task<SignOutResponse> SignOut(SignOutRequest request, string userAgent, string ipAddress);

    /// <summary>
    /// Logs in a user based on the provided login request.
    /// </summary>
    /// <param name="request">The login request containing user credentials.</param>
    /// <param name="userAgent">The User-Agent header from the HTTP request.</param>
    /// <param name="ipAddress">The IP address of the client.</param>
    /// <returns>An asynchronous task that represents the operation and contains the login response.</returns>
    Task<LogInResponse> LogIn(LogInRequest request, string userAgent, string ipAddress);

    /// <summary>
    /// Unsubscribes a user based on the provided unsubscribe request.
    /// </summary>
    /// <param name="request">The unsubscribe request containing user information.</param>
    /// <param name="userAgent">The User-Agent header from the HTTP request.</param>
    /// <param name="ipAddress">The IP address of the client.</param>
    /// <returns>An asynchronous task that represents the operation and contains the unsubscribe response.</returns>
    Task<LogOutResponse> LogOut(LogOutRequest request, string userAgent, string ipAddress);
}