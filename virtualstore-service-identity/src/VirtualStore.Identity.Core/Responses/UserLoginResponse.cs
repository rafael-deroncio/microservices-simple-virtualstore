using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Responses;

public class UserLoginResponse
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public RoleResponse Role { get; set; }
    public IEnumerable<ClaimResponse> Claims { get; set; }
}