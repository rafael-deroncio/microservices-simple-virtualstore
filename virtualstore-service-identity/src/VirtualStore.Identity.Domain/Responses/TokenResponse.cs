namespace VirtualStore.Identity.Domain.Responses;

public class TokenResponse
{
    public AccessTokenResponse AccessToken { get; set; }
    public RefreshTokenResponse RefreshToken { get; set; }
}