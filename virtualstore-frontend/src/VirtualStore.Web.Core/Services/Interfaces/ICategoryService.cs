using VirtualStore.Web.Core.ViewModels;

namespace VirtualStore.Web.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryViewModel> GetCategoryAsync(int id);

    Task<IEnumerable<CategoryViewModel>> GetCategorysAsync();

    Task<CategoryViewModel> CreateCategoryAsync(CategoryViewModel product);

    Task<CategoryViewModel> UpdateCategoryAsync(int id, CategoryViewModel product);

    Task<bool> DeleteCategoryAsync(int id);
}