using VirtualStore.Catalog.Core.Configurations.DTOs;
using VirtualStore.Identity.Core.Configurations.Enums;

namespace VirtualStore.Identity.Core.Models;

public class TokenModel : EntityConventionsDTO
{
    public int TokenId { get; set; }
    public string TokenValue { get; set; }
    public string TokenType { get; set; }
    public string Message { get; set; }
    public DateTime Expires { get; set; }
}