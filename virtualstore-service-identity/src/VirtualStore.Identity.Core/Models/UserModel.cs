using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserModel : EntityConventionsDTO
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public DateTime? LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    public int AccessFailedCount { get; set; }
    public List<AddressModel> Addresses { get; set; }
    public List<TelephoneModel> Telephones{ get; set; }
    public List<RoleModel> Roles { get; set; }
    public List<ClaimModel> Claims { get; set; }
    public List<TokenModel> Tokens { get; set; }
    public List<LoginModel> Logins { get; set; }
}