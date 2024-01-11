namespace VirtualStore.Discount.Core.Configurations;

public class Secrets
{
    public string DiscountConnectionString { get; set; }
    public string LogDBConnectionString { get; set; }
    public string JwtSymmetricSecurityKey { get; set; }
}