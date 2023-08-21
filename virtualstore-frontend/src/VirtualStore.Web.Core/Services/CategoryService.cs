using VirtualStore.Web.Core.Configurations.Mappers;
using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Repositories.Interfaces;
using VirtualStore.Web.Core.Responses;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IObjectConverter _objectConverter;

    public CategoryService(ICategoryRepository categoryRepository, IObjectConverter objectConverter)
    {
        _categoryRepository = categoryRepository;
        _objectConverter = objectConverter;
    }

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

    public async Task<IEnumerable<CategoryViewModel>> GetCategorysAsync()
    {
        try
        {
            IEnumerable<CategoryResponse> categorys = await _categoryRepository.GetCategorysAsync();
            if (categorys is null)
                return null;

            return _objectConverter.Map<IEnumerable<CategoryViewModel>>(categorys);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<CategoryViewModel> UpdateCategoryAsync(int id, CategoryViewModel product)
    {
        throw new NotImplementedException();
    }
}