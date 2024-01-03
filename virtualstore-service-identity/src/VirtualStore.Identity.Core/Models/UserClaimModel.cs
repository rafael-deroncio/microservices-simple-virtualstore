using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserClaimModel : EntityConventionsDTO
{
    public int UserClaimId { get; set; }
    public int UserId { get; set; }
    public int ClaimId { get; set; }
}