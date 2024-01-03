using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

/// <summary>
/// Represents a service interface for user authorization and token management.
/// </summary>
public interface IAuthorizeService
{
    /// <summary>
    /// Disables all tokens for a specific user.
    /// </summary>
    /// <param name="username">The username for which tokens should be disabled.</param>
    /// <returns>An asynchronous task representing the operation.</returns>
    Task DisableUserTokens(string username);

    /// <summary>
    /// Generates an authentication token for a user based on the provided token request.
    /// </summary>
    /// <param name="request">The token request containing user information and authentication details.</param>
    /// <returns>An asynchronous task that represents the operation and contains the generated authentication token.</returns>
    Task<TokenResponse> GetTokensAuthentication(TokenRequest request);

    /// <summary>
    /// Validates the authentication token based on the information provided in the token validation request.
    /// </summary>
    /// <param name="request">The token validation request containing the refresh token.</param>
    /// <returns>An asynchronous task that represents the operation and contains the validation result.</returns>
    Task<TokenResponse> RefreshTokensAuthentication(ValidateTokenRequest request);

    /// <summary>
    /// Validates the refresh token for a given user.
    /// </summary>
    /// <param name="refreshToken">The refresh token to validate.</param>
    /// <param name="username">The username associated with the refresh token.</param>
    /// <returns>An asynchronous task that represents the operation and contains the validation result.</returns>
    Task<bool> ValidateRefreshToken(string refreshToken, string username);
}