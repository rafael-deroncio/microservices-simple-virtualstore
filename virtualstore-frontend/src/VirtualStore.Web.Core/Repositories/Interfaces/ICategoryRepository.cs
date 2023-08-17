using VirtualStore.Web.Core.Requests;
using VirtualStore.Web.Core.Responses;

namespace VirtualStore.Web.Core.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryResponse> GetCategoryAsync(int id);

    Task<IEnumerable<CategoryResponse>> GetCategorysAsync();

    Task<CategoryResponse> CreateCategoryAsync(CategoryRequest category);

    Task<CategoryResponse> UpdateCategoryAsync(int id, CategoryRequest category);

    Task<bool> DeleteCategoryAsync(int id);
}