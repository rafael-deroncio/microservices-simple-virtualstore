namespace VirtualStore.Identity.Core.Configurations;

public class Secrets
{
    public string IdentityConnectionString { get; set; }
    public string LogDBConnectionString { get; set; }
    public string JwtSymmetricSecurityKey { get; set; }
    public string SecretHashRefreshToken { get; set; }
}