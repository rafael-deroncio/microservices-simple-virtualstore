using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly IObjectConverter _objectConverter;

    public CategoryService(IObjectConverter objectConverter)
    {
        _objectConverter = objectConverter;
    }

    public async Task<CategoryResponse> CreateCategory(CategoryRequest category)
    {
        await Task.Delay(100);
        return new CategoryResponse
        {
            Id = 1,
            Name = "Category A",
            Description = "Description for Category A",
            Active = true
        };
    }

    public async Task<bool> DeleteCategory(int id)
    {
        await Task.Delay(100);
        return true;
    }

    public async Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        await Task.Delay(100);
        return new List<CategoryResponse>
        {
            new CategoryResponse
            {
                Id = 1,
                Name = "Category A",
                Description = "Description for Category A",
                Active = true
            },
            new CategoryResponse
            {
                Id = 2,
                Name = "Category B",
                Description = "Description for Category B",
                Active = true
            }
        };
    }

    public async Task<CategoryResponse> GetCategory(int id)
    {
        await Task.Delay(100);
        return new CategoryResponse
        {
            Id = 1,
            Name = "Category A",
            Description = "Description for Category A",
            Active = true
        };
    }

    public async Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category)
    {
        await Task.Delay(100);
        return new CategoryResponse
        {
            Id = 1,
            Name = "Category A",
            Description = "Description for Category A",
            Active = true
        };
    }
}
