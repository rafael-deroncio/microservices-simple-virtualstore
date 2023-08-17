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

    public Task<CategoryResponse> CreateCategory(CategoryRequest category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> GetCategory(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCategory(int id)
    {
        throw new NotImplementedException();
    }
}
