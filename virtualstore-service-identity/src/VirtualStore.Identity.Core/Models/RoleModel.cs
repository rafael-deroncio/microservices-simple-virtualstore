using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class RoleModel : EntityConventionsDTO
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
}