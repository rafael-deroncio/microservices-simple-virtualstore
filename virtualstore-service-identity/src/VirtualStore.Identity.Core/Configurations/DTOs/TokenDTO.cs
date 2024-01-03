namespace VirtualStore.Identity.Core.Configurations.DTOs;

public class TokenDTO
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string Message { get; set; }
}