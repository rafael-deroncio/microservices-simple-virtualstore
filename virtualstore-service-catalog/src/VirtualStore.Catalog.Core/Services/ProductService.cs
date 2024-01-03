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

public class ProductService : IProductService
{
    private readonly IObjectConverter _objectConverter;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;
    private readonly ICategoryService _categoryService;
    private readonly IUriService _uriService;

    public ProductService(
        IObjectConverter objectConverter,
        IProductRepository productRepository,
        ILogger<ProductService> logger,
        ICategoryService categoryService,
        IUriService uriService)
    {
        _objectConverter = objectConverter;
        _productRepository = productRepository;
        _logger = logger;
        _categoryService = categoryService;
        _uriService = uriService;
    }

    public async Task<ProductResponse> CreateProduct(ProductRequest product)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(CreateProduct), product);

        try
        {
            if (await _productRepository.ProductExists(product.Name))
                throw new ProductException(
                    $"Product {product.Name} is not available!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            if(await _categoryService.GetCategory(product.CategoryId) == null)
                throw new ProductException(
                    $"Category with ID {product.CategoryId} not exists!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<ProductResponse>(
                await _productRepository.CreateProduct(
                    _objectConverter.Map<ProductArgument>(product)
                    )
                );
        }
        catch (ProductException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(DeleteProduct), id);

        try
        {
            ProductModel product = await _productRepository.GetProduct(id) ??
                throw new ProductException($"Product ID: {id} not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return await _productRepository.DeleteProduct(id);
        }
        catch (ProductException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<PaginationResponse<IEnumerable<ProductResponse>>> GetProducts(PaginationRequest pagination)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1}", nameof(ProductService), nameof(GetProducts));

        try
        {
            PaginationArgument paginationArgument = _objectConverter.Map<PaginationArgument>(pagination);
            IEnumerable<ProductModel> products = await _productRepository.GetPagedProducts(paginationArgument);

            if (products is null)
                return new PaginationResponse<IEnumerable<ProductResponse>>();


            return PaginationHelpers<IEnumerable<ProductResponse>>.CreateResponse(
                service: _uriService,
                data: _objectConverter.Map<IEnumerable<ProductResponse>>(products),
                page: paginationArgument.Page, 
                size: paginationArgument.Size,
                count: await _productRepository.GetTotalRegisteredProducts());
        }
        catch (ProductException) { throw; }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while retrieving products. {0}", ex.Message);
            throw;
        }
    }

    public async Task<ProductResponse> GetProduct(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(GetProduct), id);

        try
        {
            ProductModel product = await _productRepository.GetProduct(id) ??
                throw new ProductException($"Product ID: {id} not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            return _objectConverter.Map<ProductResponse>(product); ;
        }
        catch (ProductException) { throw; }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<ProductResponse> UpdateProduct(int id, ProductRequest product)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(UpdateProduct), product);

        try
        {
            ProductModel productModel = await _productRepository.GetProduct(id) ??
                throw new CategoryException($"Product '{product.Name}' not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            CategoryResponse categoryModel = await _categoryService.GetCategory(product.CategoryId) ??
                throw new CategoryException($"Category with id '{product.CategoryId}' not found!",
                    Configurations.Enums.ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);

            ProductArgument argument = _objectConverter.Map<ProductArgument>(product);
            argument.ProductId = id;

            return _objectConverter.Map<ProductResponse>(
                await _productRepository.UpdateProduct(argument));
        }
        catch (ProductException) { throw; }
        catch (CategoryException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }
}
