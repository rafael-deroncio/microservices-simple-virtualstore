using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Models;

namespace VirtualStore.Identity.Core.Repositories.Interfaces;

/// <summary>
/// Interface for managing roles and claims in the repository.
/// </summary>
public interface IRoleManagerRepository
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
    /// Sets multiple claims for a given user based on the specified role.
    /// </summary>
    /// <param name="role">The role to determine the claims.</param>
    /// <param name="claims">An array of claims to be set.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> SetClaims(ClaimType claim, string username);

    /// <summary>
    /// Removes a role from a given user.
    /// </summary>
    /// <param name="role">The role to be removed.</param>
    /// <param name="username">The username of the user.</param>
    /// <returns>An asynchronous operation that returns true if the operation is successful, false otherwise.</returns>
    Task<bool> RemoveRole(RoleType role, string username);

    /// <summary>
    /// Removes a claim from a given user.
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
    /// Checks if a role exists.
    /// </summary>
    /// <param name="roleType">The role type to check for.</param>
    /// <returns>An asynchronous operation that returns true if the role exists, false otherwise.</returns>
    Task<bool> RoleExists(RoleType roleType);

    /// <summary>
    /// Checks if a claim exists.
    /// </summary>
    /// <param name="claimType">The claim type to check for.</param>
    /// <returns>An asynchronous operation that returns true if the claim exists, false otherwise.</returns>
    Task<bool> ClaimExists(ClaimType claimType);

    /// <summary>
    /// Saves roles to the repository.
    /// </summary>
    /// <param name="roles">A collection of role arguments to be saved.</param>
    /// <returns>An asynchronous operation to save roles.</returns>
    Task SaveRoles(IEnumerable<RoleArgument> roles);

    /// <summary>
    /// Saves claims to the repository.
    /// </summary>
    /// <param name="claims">A collection of claim arguments to be saved.</param>
    /// <returns>An asynchronous operation to save claims.</returns>
    Task SaveClaims(IEnumerable<ClaimArgument> claims);
}