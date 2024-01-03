using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserRoleModel : EntityConventionsDTO
{
    public int UserRoleId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}