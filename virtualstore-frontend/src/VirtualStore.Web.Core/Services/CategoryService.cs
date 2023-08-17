using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Core.Services;

public class CategoryService : ICategoryService
{
    public Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryViewModel> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryViewModel>> GetCategorysAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryViewModel> UpdateCategoryAsync(int id, CategoryViewModel product)
    {
        throw new NotImplementedException();
    }
}