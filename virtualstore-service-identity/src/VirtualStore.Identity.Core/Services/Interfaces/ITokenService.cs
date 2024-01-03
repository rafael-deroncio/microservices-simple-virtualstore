using Microsoft.Extensions.Primitives;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Domain.Requests;

/// <summary>
/// Represents a service interface for JWT (JSON Web Token) token operations.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates a bearer access token for a user with the specified role, claims, and username.
    /// </summary>
    /// <param name="role">The role associated with the user.</param>
    /// <param name="claims">The claims associated with the user.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous task that represents the operation and contains the generated bearer access token.</returns>
    Task<TokenModel> GenerateBearerAccessToken(RoleType role, IEnumerable<ClaimType> claims, string username);

    /// <summary>
    /// Generates a bearer refresh token for a user with the specified role and username.
    /// </summary>
    /// <param name="role">The role associated with the user.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous task that represents the operation and contains the generated bearer refresh token.</returns>
    Task<TokenModel> GenerateBearerRefreshToken(RoleType role, string username);

    /// <summary>
    /// Validates a bearer token based on the information provided in the token validation request.
    /// </summary>
    /// <param name="tokenRequest">The token validation request containing the refresh token.</param>
    /// <returns>An asynchronous task that represents the operation and contains the generated bearer access token.</returns>
    Task<(TokenModel, TokenModel)> RefreshToken(ValidateTokenRequest tokenRequest);

    /// <summary>
    /// Retrieves a user token based on the token type and username.
    /// </summary>
    /// <param name="type">The type of the token to retrieve.</param>
    /// <param name="username">The username associated with the token.</param>
    /// <returns>An asynchronous task that represents the operation and contains the retrieved user token.</returns>
    Task<TokenModel> GetUserToken(TokenType type, string username);

    /// <summary>
    /// Saves a user token with the specified role, claims, and token type.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="role">The role associated with the user.</param>
    /// <param name="claims">The claims associated with the user.</param>
    /// <param name="tokenType">The type of the token to save.</param>
    /// <returns>An asynchronous task that represents the operation and contains the saved user token.</returns>
    Task<TokenModel> SaveUserToken(string username, RoleType role, IEnumerable<ClaimType> claims, TokenType tokenType);

    /// <summary>
    /// Disables all tokens for a specific user.
    /// </summary>
    /// <param name="username">The username for which tokens should be disabled.</param>
    /// <returns>An asynchronous task representing the operation.</returns>
    Task DisableUserTokens(string username);
}
