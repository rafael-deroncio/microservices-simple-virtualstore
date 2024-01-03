using System.Data;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Models;

namespace VirtualStore.Identity.Core.Repositories.Interfaces;

/// <summary>
/// Interface for the User Repository, providing methods for user-related operations.
/// </summary>
public interface IUserRepository
{
    #region User Operations

    /// <summary>
    /// Retrieves a user based on the provided username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation and contains the retrieved user.</returns>
    Task<UserModel> GetUser(string username);

    /// <summary>
    /// Updates user information based on the provided argument.
    /// </summary>
    /// <param name="argument">The argument containing updated user information.</param>
    /// <returns>A task that represents the asynchronous operation and contains the updated user.</returns>
    Task<UserModel> UpdateUser(UserArgument argument);

    /// <summary>
    /// Inserts a new user based on the provided argument.
    /// </summary>
    /// <param name="argument">The argument containing user information for insertion.</param>
    /// <returns>A task that represents the asynchronous operation and contains the inserted user.</returns>
    Task<UserModel> InsertUser(UserArgument argument);

    /// <summary>
    /// Deletes a user based on the provided username.
    /// </summary>
    /// <param name="username">The username of the user to delete.</param>
    /// <returns>A task that represents the asynchronous operation and returns true if the user is successfully deleted.</returns>
    Task<bool> DeleteUser(string username);

    #endregion

    #region User Validations

    /// <summary>
    /// Checks if a username already exists.
    /// </summary>
    /// <param name="username">The username to check for existence.</param>
    /// <returns>A task that represents the asynchronous operation and returns true if the username exists.</returns>
    Task<bool> UserNameExists(string username);

    /// <summary>
    /// Checks if an email already exists.
    /// </summary>
    /// <param name="email">The email to check for existence.</param>
    /// <param name="username">Optional: The username to exclude from the check.</param>
    /// <returns>A task that represents the asynchronous operation and returns true if the email exists.</returns>
    Task<bool> EmailExists(string email, string username = null);

    /// <summary>
    /// Checks if a CPF (Brazilian ID) already exists.
    /// </summary>
    /// <param name="cpf">The CPF to check for existence.</param>
    /// <param name="username">Optional: The username to exclude from the check.</param>
    /// <returns>A task that represents the asynchronous operation and returns true if the CPF exists.</returns>
    Task<bool> CPFExists(string cpf, string username = null);

    /// <summary>
    /// Retrieves the count of users.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation and returns the count of users.</returns>
    Task<int> GetCountUsers();
    #endregion
}