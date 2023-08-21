namespace VirtualStore.Identity.Core.Configurations;

public class Secrets
{
    public string IdentityConnectionString { get; set; }
    public string JwtSymmetricSecurityKey { get; set; }
}