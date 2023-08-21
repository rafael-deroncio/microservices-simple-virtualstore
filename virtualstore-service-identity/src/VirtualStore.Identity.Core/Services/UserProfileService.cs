using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class UserProfileService : IUserProfileService
{
    public Task<UserResponse> CreateUserProfile(UserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserProfile(string username)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> GetUserProfile(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResponse>> GetUsersProfiles()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> UpdateUserProfile(UserRequest request)
    {
        throw new NotImplementedException();
    }
}