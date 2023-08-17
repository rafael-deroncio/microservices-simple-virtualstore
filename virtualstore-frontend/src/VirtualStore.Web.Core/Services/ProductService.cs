using VirtualStore.Web.Core.Configurations.Mappers;
using VirtualStore.Web.Core.Models;
using VirtualStore.Web.Core.Repositories.Interfaces;
using VirtualStore.Web.Core.Responses;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IObjectConverter _objectConverter;

    public ProductService(IProductRepository productRepository, IObjectConverter objectConverter)
    {
        _productRepository = productRepository;
        _objectConverter = objectConverter;
    }

    public Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductViewModel> GetProductAsync(int id)
    {
        try
        {
            ProductResponse product = await _productRepository.GetProductAsync(id);
            if (product is null)
                return null;

            return _objectConverter.Map<ProductViewModel>(product);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
        try
        {
            IEnumerable<ProductResponse> products = await _productRepository.GetProductsAsync();
            if (products is null)
                return null;

            return _objectConverter.Map<IEnumerable<ProductViewModel>>(products);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product)
    {
        throw new NotImplementedException();
    }
}