using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class TokenModel : EntityConventionsDTO
{
    public int TokenId { get; set; }
    public string TokenValue { get; set; }
    public string Message { get; set; }
    public DateTime Expires { get; set; }
}