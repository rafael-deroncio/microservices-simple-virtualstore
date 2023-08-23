using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;

namespace VirtualStore.Catalog.Core.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryModel> GetCategory(int id);

    Task<IEnumerable<CategoryModel>> GetCategorys();

    Task<CategoryModel> CreateCategory(CategoryArgument Category);

    Task<CategoryModel> UpdateCategory(CategoryArgument Category);

    Task<bool> DeleteCategory(int id);
}