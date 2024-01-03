using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Models;

namespace VirtualStore.Identity.Core.Managers.Interfaces;

/// <summary>
/// Interface for managing roles and claims in the identity system.
/// </summary>
public interface IRoleManager
{
    /// <summary>
    /// Gets all available roles.
    /// </summary>
    /// <returns>An asynchronous operation that returns a collection of role models.</returns>
    Task<IEnumerable<RoleModel>> GetRoles();

    /// <summary>
    /// Gets all available claims.
    /// </summary>
    /// <returns>An asynchronous operation that returns a collection of claim models.</returns>
    Task<IEnumerable<ClaimModel>> GetClaims();

    /// <summary>
    /// Sets a role for a given user.
    /// </summary>
    /// <param name="role">The role to be set.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> SetRole(RoleType role, string username);

    /// <summary>
    /// Deletes a role from a given user.
    /// </summary>
    /// <param name="role">The role to be removed.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> RemoveRole(RoleType role, string username);

    /// <summary>
    /// Deletes a claim from a given user.
    /// </summary>
    /// <param name="claim">The claim to be removed.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> RemoveClaim(ClaimType claim, string username);

    /// <summary>
    /// Checks if a user contains a specific role.
    /// </summary>
    /// <param name="role">The role to check for.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the user contains the role, false otherwise.</returns>
    Task<bool> ContainsRole(RoleType role, string username);

    /// <summary>
    /// Checks if a user contains a specific claim.
    /// </summary>
    /// <param name="claim">The claim to check for.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the user contains the claim, false otherwise.</returns>
    Task<bool> ContainsClaim(ClaimType claim, string username);

    /// <summary>
    /// Sets claims based on the specified role for a given user.
    /// </summary>
    /// <param name="role">The role to determine the claims.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> SetClaimByRole(RoleType role, string username);

    /// <summary>
    /// Initializes the seed roles and claims in the system.
    /// </summary>
    /// <returns>An asynchronous operation that initializes seed roles and claims.</returns>
    Task InitializeSeedRoles();
}