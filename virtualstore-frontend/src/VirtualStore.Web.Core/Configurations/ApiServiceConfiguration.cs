using VirtualStore.Web.Core.Configurations.Options;

namespace VirtualStore.Web.Core.Configurations;
public class ApiClientConfiguration
{
    public ApiClientOptions LoginApi { get; set; }
    public ApiClientOptions SiginApi { get; set; }
    public ApiClientOptions ProductApi { get; set; }
    public ApiClientOptions CategoryApi { get; set; }
    public ApiClientOptions CartApi { get; set; }
    public ApiClientOptions DiscountApi { get; set; }
}