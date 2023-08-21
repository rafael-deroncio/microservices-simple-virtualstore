using Microsoft.Extensions.Logging;
using System;
using VirtualStore.Web.Core.Configurations.Mappers;
using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Repositories.Interfaces;
using VirtualStore.Web.Core.Requests;
using VirtualStore.Web.Core.Responses;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IObjectConverter _objectConverter;
    private readonly ILogger<IProductService> _logger;

    public ProductService(IProductRepository productRepository, IObjectConverter objectConverter, ILogger<IProductService> logger)
    {
        _productRepository = productRepository;
        _objectConverter = objectConverter;
        _logger = logger;
    }

    public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
    {
        try
        {
            _logger.LogInformation("Request {0} received to products/post/new", Guid.NewGuid().ToString());
            ProductRequest request = _objectConverter.Map<ProductRequest>(product);
            ProductResponse response = await _productRepository.CreateProductAsync(request);
            return _objectConverter.Map<ProductViewModel>(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while {Action}.", nameof(CreateProductAsync));
            return null;
        }
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            _logger.LogInformation("Request {0} received to products/delete", Guid.NewGuid().ToString());
            return await _productRepository.DeleteProductAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while {Action}.", nameof(DeleteProductAsync));
            return false;
        }
    }

    public async Task<ProductViewModel> GetProductAsync(int id)
    {
        try
        {
            _logger.LogInformation("Request {0} received to products/get/id:int", Guid.NewGuid().ToString());
            ProductResponse product = await _productRepository.GetProductAsync(id);
            return _objectConverter.Map<ProductViewModel>(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while {Action}.", nameof(GetProductAsync));
            return null;
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
        try
        {
            _logger.LogInformation("Request {0} received to products/get/all", Guid.NewGuid().ToString());
            IEnumerable<ProductResponse> products = await _productRepository.GetProductsAsync();
            return _objectConverter.Map<IEnumerable<ProductViewModel>>(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while {Action}.", nameof(GetProductsAsync));
            return null;
        }
    }

    public async Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product)
    {
        try
        {
            _logger.LogInformation("Request {0} received to products/put/id:int", Guid.NewGuid().ToString());
            ProductRequest request = _objectConverter.Map<ProductRequest>(product);
            ProductResponse response = await _productRepository.UpdateProductAsync(id, request);
            return _objectConverter.Map<ProductViewModel>(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while {Action}.", nameof(UpdateProductAsync));
            return null;
        }
    }
}