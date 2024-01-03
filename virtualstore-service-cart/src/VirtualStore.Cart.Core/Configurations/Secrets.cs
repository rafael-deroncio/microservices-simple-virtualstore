namespace VirtualStore.Cart.Core.Configurations;

public class Secrets
{
    public string CartConnectionString { get; set; }
    public string LogDBConnectionString { get; set; }
    public string JwtSymmetricSecurityKey { get; set; }
    public string IdentityConnectionString { get; set; }
}