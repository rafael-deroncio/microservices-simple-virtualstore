using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services.Interfaces;

public interface IUserProfileService
{
    Task<UserResponse> GetUserProfile(string username);

    Task<IEnumerable<UserResponse>> GetUsersProfiles();

    Task<UserResponse> CreateUserProfile(UserRequest request);

    Task<UserResponse> UpdateUserProfile(UserRequest request);

    Task<bool> DeleteUserProfile(string username);
}