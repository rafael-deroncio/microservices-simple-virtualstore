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

public class CategoryClientRepository : ClientBaseRepository, ICategoryRepository
{
    private readonly ClientService _service;
    private readonly ApiClientOptions _options;

    public CategoryClientRepository(IHttpClientFactory httpClient, IOptions<ApiClientConfiguration> options) : base(httpClient)
    {
        _service = ClientService.Category;
        _options = options.Value.CategoryApi;
    }

    public async Task<CategoryResponse> CreateCategoryAsync(CategoryRequest category)
    {
        StringContent request = new (
            content: JsonSerializer.Serialize(category),
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        using HttpResponseMessage response = await GetClient(_service).PostAsync(_options.Endpoint, request);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<CategoryResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        using HttpResponseMessage response = await GetClient(_service).DeleteAsync(_options.Endpoint + id);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<bool>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return false;
    }

    public async Task<CategoryResponse> GetCategoryAsync(int id)
    {
        using HttpResponseMessage response = await GetClient(_service).GetAsync(_options.Endpoint + id);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<CategoryResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<IEnumerable<CategoryResponse>> GetCategorysAsync()
    {
        using HttpResponseMessage response = await GetClient(_service).GetAsync(_options.Endpoint);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<IEnumerable<CategoryResponse>>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }

    public async Task<CategoryResponse> UpdateCategoryAsync(int id, CategoryRequest category)
    {
        StringContent request = new (
            content: JsonSerializer.Serialize(category),
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        using HttpResponseMessage response = await GetClient(_service).PostAsync(_options.Endpoint + id, request);
        if (response.IsSuccessStatusCode)
            return JsonSerializer.Deserialize<CategoryResponse>(
                await response.Content.ReadAsStreamAsync(), JsonOptions);

        return null;
    }
}