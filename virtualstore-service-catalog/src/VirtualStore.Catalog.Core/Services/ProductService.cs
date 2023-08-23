using Microsoft.Extensions.Logging;
using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Model;
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

    public ProductService(
        IObjectConverter objectConverter,
        IProductRepository productRepository,
        ILogger<ProductService> logger,
        ICategoryService categoryService)
    {
        _objectConverter = objectConverter;
        _productRepository = productRepository;
        _logger = logger;
        _categoryService = categoryService;
    }

    public async Task<ProductResponse> CreateProduct(ProductRequest product)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(CreateProduct), product);

        try
        {
            ProductModel existingProduct = (await _productRepository.GetProducts())
                .FirstOrDefault(
                    c => c.Name.ToUpper().Trim() == product.Name.ToUpper().Trim() &&
                    c.Description.ToUpper().Trim() == product.Description.ToUpper().Trim() &&
                    c.Brand.ToUpper().Trim() == product.Brand.ToUpper().Trim() &&
                    c.Active);

            if (existingProduct != null)
                throw new Exception($"Product already registered at id {existingProduct.Id} at {existingProduct.RegistrationDate}");

            ProductModel newProduct = await _productRepository.CreateProduct(_objectConverter.Map<ProductArgument>(product));

            return _objectConverter.Map<ProductResponse>(newProduct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(DeleteProduct), id);

        try
        {
            ProductModel product = await _productRepository.GetProduct(id);

            if (product is null || !product.Active)
                return default;

            return await _productRepository.DeleteProduct(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<IEnumerable<ProductResponse>> GetProducts()
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1}", nameof(ProductService), nameof(GetProducts));

        try
        {
            IEnumerable<ProductModel> products = await _productRepository.GetProducts();

            if (products is null)
                return default;

            return products.Join(
                    await _categoryService.GetCategories(),
                    product => product.CategoryId,
                    category => category.Id,
                    (product, category) => new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Brand = product.Brand,
                        Price = product.Price,
                        Stock = product.Stock,
                        Active = product.Active,
                        Category = category
                    }
                );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<ProductResponse> GetProduct(int id)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to {2}", nameof(ProductService), nameof(GetProduct), id);

        try
        {
            ProductModel product = await _productRepository.GetProduct(id);

            if (product is null || !product.Active)
                return default;

            ProductResponse response = _objectConverter.Map<ProductResponse>(product);
            CategoryResponse category = await _categoryService.GetCategory(product.CategoryId);

            response.Category = category;

            return response;
        }
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
            ProductModel categoryModel = await _productRepository.GetProduct(id);

            if (product is null || !categoryModel.Active)
                return default;

            ProductArgument argument = _objectConverter.Map<ProductArgument>(product);

            categoryModel = await _productRepository.UpdateProduct(argument);

            return _objectConverter.Map<ProductResponse>(categoryModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }
}
