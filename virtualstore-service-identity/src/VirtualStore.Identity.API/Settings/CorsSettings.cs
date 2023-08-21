namespace VirtualStore.Identity.API.Settings;

public class CorsSettings
{
    public CorsCustomPolicy CorsPolicy { get; set; }
}

public class CorsCustomPolicy
{
    public string Name { get; set; }
    public string[] AllowedOrigins { get; set; }
    public string[] AllowedMethods { get; set; }
    public string[] AllowedHeaders { get; set; }
}