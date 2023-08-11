namespace VirtualStore.Catalog.Domain.Responses;

public class TokenAuthorizationResponse
{
    public string Token { get; set; }
    public string Message { get; set; }
    public DateTime Expires { get; set; }
}