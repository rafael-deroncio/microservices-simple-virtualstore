namespace VirtualStore.Identity.Domain.Responses;

public class AccessTokenResponse
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string Message { get; set; }
}