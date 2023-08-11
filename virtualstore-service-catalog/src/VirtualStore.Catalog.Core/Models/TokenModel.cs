using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Catalog.Core.Models;

public class TokenModel : TokenDTO
{
    public DateTime Expires { get; set; }
}