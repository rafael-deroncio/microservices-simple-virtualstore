using System.Threading.Channels;
using VirtualStore.Identity.Core.Arguments;

namespace VirtualStore.Identity.Core.Repositories.Interfaces;

/// <summary>
/// Represents a repository interface for storing user account and authentication logs.
/// </summary>
public interface IAccountRepository
{
    /// <summary>
    /// Registers an invalid login attempt for a specific user.
    /// </summary>
    /// <param name="username">The username for which the invalid login attempt is registered.</param>
    /// <param name="block">Block by attempts</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task RegisterInvalidLoginAttempt(string username, bool block);

    /// <summary>
    /// Gets the number of access failed attempts for a user.
    /// </summary>
    /// <param name="userName">The username for which to retrieve the access failed count.</param>
    /// <returns>An asynchronous task that represents the operation and returns the access failed count.</returns>
    Task<int> GetUserAccessFailedCount(string userName);

    /// <summary>
    /// Blocks a user if the number of access failed attempts exceeds a certain threshold.
    /// </summary>
    /// <param name="userName">The username of the user to be blocked.</param>
    /// <returns>An asynchronous task that represents the operation and returns a boolean indicating success.</returns>
    Task<bool> UserAccessFailedBlock(string userName);

    /// <summary>
    /// Saves a log for a user login.
    /// </summary>
    /// <param name="argument">The login argument containing relevant information.</param>
    /// <returns>An asynchronous task that represents the operation and returns a boolean indicating success.</returns>
    Task<bool> SaveLogIn(LogInArgument argument);

    /// <summary>
    /// Saves a log for a user logout.
    /// </summary>
    /// <param name="argument">The logout argument containing relevant information.</param>
    /// <returns>An asynchronous task that represents the operation and returns a boolean indicating success.</returns>
    Task<bool> SaveLogOut(LogOutArgument argument);

    /// <summary>
    /// Saves a log for a user sign-in.
    /// </summary>
    /// <param name="argument">The sign-in argument containing relevant information.</param>
    /// <returns>An asynchronous task that represents the operation and returns a boolean indicating success.</returns>
    Task<bool> SaveSignIn(SignInArgument argument);

    /// <summary>
    /// Saves a log for a user sign-out.
    /// </summary>
    /// <param name="argument">The sign-out argument containing relevant information.</param>
    /// <returns>An asynchronous task that represents the operation and returns a boolean indicating success.</returns>
    Task<bool> SaveSignOut(SignOutArgument argument);
}