using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserLoginModel : EntityConventionsDTO
{
    public int UserLoginId { get; set; }
    public int UserId { get; set; }
    public int LoginId { get; set; }
}