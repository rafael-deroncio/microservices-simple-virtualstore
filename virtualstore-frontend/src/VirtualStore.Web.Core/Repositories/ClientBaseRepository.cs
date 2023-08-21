using System.Text.Json;
using VirtualStore.Web.Core.Configurations.Enum;

namespace VirtualStore.Web.Core.Repositories;

public class ClientBaseRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    protected static JsonSerializerOptions JsonOptions =>
        new() { PropertyNameCaseInsensitive = true };

    protected ClientBaseRepository(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
    }

    protected HttpClient GetClient(ClientService service)
    {
        return service switch
        {
            ClientService.Login => _httpClientFactory.CreateClient("LoginApi"),
            ClientService.Signin => _httpClientFactory.CreateClient("SiginApi"),
            ClientService.Product => _httpClientFactory.CreateClient("ProductApi"),
            ClientService.Category => _httpClientFactory.CreateClient("CategoryApi"),
            ClientService.Cart => _httpClientFactory.CreateClient("CartApi"),
            ClientService.Discount => _httpClientFactory.CreateClient("DiscountApi"),
            _ => _httpClientFactory.CreateClient()
        };
    }
}