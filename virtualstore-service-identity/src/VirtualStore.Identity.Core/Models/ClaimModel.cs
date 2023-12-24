
using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class ClaimModel : EntityConventionsDTO
{
    public int ClaimId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}