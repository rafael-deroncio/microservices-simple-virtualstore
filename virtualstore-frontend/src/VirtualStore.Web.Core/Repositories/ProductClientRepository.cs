using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using VirtualStore.Web.Core.Configurations;
using VirtualStore.Web.Core.Configurations.Enum;
using VirtualStore.Web.Core.Configurations.Options;
using VirtualStore.Web.Core.Repositories.Interfaces;
using VirtualStore.Web.Core.Requests;
using VirtualStore.Web.Core.Responses;

namespace VirtualStore.Web.Core.Repositories;

public class ProductClientRepository : ClientBaseRepository, IProductRepository
{
    private readonly ClientService _service;
    private readonly ApiClientOptions _options;

    public ProductClientRepository(IHttpClientFactory httpClient, IOptions<ApiClientConfiguration> options) : base(httpClient)
    {
        _service = ClientService.Product;
        _options = options.Value.ProductApi;
    }

    public async Task<ProductResponse> CreateProductAsync(ProductRequest product)
    {
        StringContent request = new(
            content: JsonSerializer.Serialize(product),
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        using HttpResponseMessage response = await GetClient(_service).PostAsync(_options.Endpoint, request);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<ProductResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        using HttpResponseMessage response = await GetClient(_service).DeleteAsync(_options.Endpoint + id);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<bool>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return false;
    }

    public async Task<ProductResponse> GetProductAsync(int id)
    {
        using HttpResponseMessage response = await GetClient(_service).GetAsync(_options.Endpoint + id);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<ProductResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        using HttpResponseMessage response = await GetClient(_service).GetAsync(_options.Endpoint);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<IEnumerable<ProductResponse>>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<ProductResponse> UpdateProductAsync(int id, ProductRequest product)
    {
        StringContent request = new(
            content: JsonSerializer.Serialize(product),
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        using HttpResponseMessage response = await GetClient(_service).PostAsync(_options.Endpoint + id, request);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<ProductResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }
}