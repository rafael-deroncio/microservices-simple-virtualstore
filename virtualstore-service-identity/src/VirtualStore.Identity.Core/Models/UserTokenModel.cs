using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserTokenModel : EntityConventionsDTO
{
    public int UserTokenId { get; set; }
    public int UserId { get; set; }
    public int TokenId { get; set; }
}