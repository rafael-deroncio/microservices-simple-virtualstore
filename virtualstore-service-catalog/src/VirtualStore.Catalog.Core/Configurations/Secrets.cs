namespace VirtualStore.Catalog.Core.Configurations;

public class Secrets
{
    public string CatalogConnectionString { get; set; }
    public string JwtSymmetricSecurityKey { get; set; }
    public string IdentityConnectionString { get; set; }
}