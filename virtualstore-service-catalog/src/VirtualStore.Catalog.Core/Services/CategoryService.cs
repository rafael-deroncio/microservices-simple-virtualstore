using Microsoft.Extensions.Logging;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Repositories.Interfaces;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly IObjectConverter _objectConverter;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(
        IObjectConverter objectConverter,
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> logger)
    {
        _objectConverter = objectConverter;
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<CategoryResponse> CreateCategory(CategoryRequest category)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(CreateCategory), category);

        try
        {
            CategoryModel existingCategory = (await _categoryRepository.GetCategorys())
                .FirstOrDefault(
                    c => c.Name.ToUpper().Trim() == category.Name.ToUpper().Trim() &&
                    c.Description.ToUpper().Trim() == category.Description.ToUpper().Trim() &&
                    c.IsActive);

            if (existingCategory != null)
                throw new Exception($"Category already registered at id {existingCategory.CategoryId} at {existingCategory.CreatedDate}");

            CategoryModel newCategory = await _categoryRepository.CreateCategory(_objectConverter.Map<CategoryArgument>(category));

            return _objectConverter.Map<CategoryResponse>(newCategory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> DeleteCategory(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(DeleteCategory), id);

        try
        {
            CategoryModel category = await _categoryRepository.GetCategory(id);

            if (category is null || !category.IsActive)
                return default;

            return await _categoryRepository.DeleteCategory(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1}", nameof(CategoryService), nameof(GetCategories));

        try
        {
            IEnumerable<CategoryModel> categories = await _categoryRepository.GetCategorys();
            return _objectConverter.Map<IEnumerable<CategoryResponse>>(categories).OrderBy(category => category.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<CategoryResponse> GetCategory(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(GetCategory), id);

        try
        {
            CategoryModel category = await _categoryRepository.GetCategory(id);

            if (category is null || !category.IsActive)
                return default;

            return _objectConverter.Map<CategoryResponse>(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(UpdateCategory), category);

        try
        {
            CategoryModel categoryModel = await _categoryRepository.GetCategory(id);

            if (category is null || !categoryModel.IsActive)
                return default;

            CategoryArgument argument = _objectConverter.Map<CategoryArgument>(category);

            categoryModel = await _categoryRepository.UpdateCategory(argument);

            return _objectConverter.Map<CategoryResponse>(categoryModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }
}
