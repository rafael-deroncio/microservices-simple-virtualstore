using Microsoft.Extensions.Logging;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Exceptions;
using VirtualStore.Catalog.Core.Helpers;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Core.Repositories;
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
    private readonly IUriService _uriService;

    public CategoryService(
        IObjectConverter objectConverter,
        ICategoryRepository categoryRepository,
        ILogger<CategoryService> logger,
        IUriService uriService)
    {
        _objectConverter = objectConverter;
        _categoryRepository = categoryRepository;
        _logger = logger;
        _uriService = uriService;
    }

    public async Task<CategoryResponse> CreateCategory(CategoryRequest category)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(CreateCategory), category);

        try
        {
            if (await _categoryRepository.CategoryExists(category.Name))
                throw new CategoryException(
                    $"Category {category.Name} is not available!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<CategoryResponse>(
                await _categoryRepository.CreateCategory(
                    _objectConverter.Map<CategoryArgument>(category)
                    )
                );
        }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCategory(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to ID: {2}", nameof(CategoryService), nameof(DeleteCategory), id);

        try
        {
            CategoryModel categoryModel = await _categoryRepository.GetCategory(id) ??
                throw new CategoryException($"Category ID: {id} not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return await _categoryRepository.DeleteCategory(id);
        }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<PaginationResponse<IEnumerable<CategoryResponse>>> GetCategories(PaginationRequest pagination)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1}. Page {2} Size {3}", nameof(CategoryService), nameof(GetCategories), pagination.Page, pagination.Size);

        try
        {
            PaginationArgument paginationArgument = _objectConverter.Map<PaginationArgument>(pagination);
            IEnumerable<CategoryModel> categories = await _categoryRepository.GetCategories(paginationArgument);

            return PaginationHelpers<IEnumerable<CategoryResponse>>.CreateResponse(
                service: _uriService,
                data: _objectConverter.Map<IEnumerable<CategoryResponse>>(categories),
                page: paginationArgument.Page,
                size: paginationArgument.Size,
                count: await _categoryRepository.GetTotalRegisteredCategories());
        }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while retrieving categories. {0}", ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CategoryResponse>> GetCategories()
    {
        try
        {
            IEnumerable<CategoryModel> categories = await _categoryRepository.GetCategories();
            return _objectConverter.Map<IEnumerable<CategoryResponse>>(categories.OrderBy(category => category.CategoryId));
        }
        catch (CategoryException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while retrieving categories. {ex.Message}");
            throw;
        }
    }

    public async Task<CategoryResponse> GetCategorieByProduct(int productId)
    {
        return await _categoryRepository.GetCategoryByProduct(productId);
    }

    public async Task<CategoryResponse> GetCategory(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(GetCategory), id);

        try
        {
            CategoryModel category = await _categoryRepository.GetCategory(id) ??
                throw new CategoryException($"Category ID: {id} not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<CategoryResponse>(category);
        }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(CategoryService), nameof(UpdateCategory), category.Name);

        try
        {
            CategoryModel categoryModel = await _categoryRepository.GetCategory(id) ??
                throw new CategoryException($"Category '{category.Name}' not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<CategoryResponse>(
                await _categoryRepository.UpdateCategory(
                    _objectConverter.Map<CategoryArgument>(category)
                    )
                );
        }
        catch (CategoryException) {  throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}
