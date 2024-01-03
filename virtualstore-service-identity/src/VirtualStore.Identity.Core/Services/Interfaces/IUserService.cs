using VirtualStore.Identity.Core.Responses;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

/// <summary>
/// Interface for the User Service, providing methods for user profile-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retrieves the user profile based on the provided username.
    /// </summary>
    /// <param name="username">The username of the user profile to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation and contains the user profile response.</returns>
    Task<UserResponse> GetUserProfile(string username);

    /// <summary>
    /// Creates a new user profile based on the provided request.
    /// </summary>
    /// <param name="request">The request containing user profile information for creation.</param>
    /// <returns>A task that represents the asynchronous operation and contains the created user profile response.</returns>
    Task<UserResponse> CreateUserProfile(UserRequest request);

    /// <summary>
    /// Updates the user profile based on the provided username and request.
    /// </summary>
    /// <param name="username">The username of the user profile to update.</param>
    /// <param name="request">The request containing updated user profile information.</param>
    /// <returns>A task that represents the asynchronous operation and contains the updated user profile response.</returns>
    Task<UserResponse> UpdateUserProfile(string username, UserRequest request);

    /// <summary>
    /// Deletes the user profile based on the provided username.
    /// </summary>
    /// <param name="username">The username of the user profile to delete.</param>
    /// <returns>A task that represents the asynchronous operation and returns true if the user profile is successfully deleted.</returns>
    Task<bool> DeleteUserProfile(string username);

    /// <summary>
    /// Retrieves login information for a user based on the username.
    /// </summary>
    /// <param name="username">Username of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a UserLoginResponse object.</returns>
    Task<UserLoginResponse> GetUserLogin(string username);

}