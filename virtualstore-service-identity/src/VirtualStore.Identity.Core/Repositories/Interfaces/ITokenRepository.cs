using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Models;

namespace VirtualStore.Identity.Core.Repositories.Interfaces;

/// <summary>
/// Represents a repository interface for managing user tokens.
/// </summary>
public interface ITokenRepository
{
    /// <summary>
    /// Retrieves a user token based on the token type and username.
    /// </summary>
    /// <param name="type">The type of the token to retrieve.</param>
    /// <param name="username">The username associated with the token.</param>
    /// <returns>An asynchronous task that represents the operation and contains the retrieved user token.</returns>
    Task<TokenModel> GetUserToken(TokenType type, string username);

    /// <summary>
    /// Saves a user token for the specified username and token arguments.
    /// </summary>
    /// <param name="username">The username associated with the token.</param>
    /// <param name="argument">The token arguments to be saved.</param>
    /// <returns>An asynchronous task that represents the operation and contains the saved user token.</returns>
    Task<TokenModel> SaveUserToken(string username, TokenArgument argument);

    /// <summary>
    /// Disables tokens of a specific type for a given username.
    /// </summary>
    /// <param name="username">The username associated with the tokens.</param>
    /// <param name="tokenType">The type of tokens to be disabled.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task DisableTokens(string username, TokenType tokenType);
}