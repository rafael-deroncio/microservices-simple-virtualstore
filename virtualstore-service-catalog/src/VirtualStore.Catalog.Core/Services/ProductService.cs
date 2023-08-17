using VirtualStore.Catalog.Core.Configurations.Mappers;
using VirtualStore.Catalog.Core.Services.Interfaces;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services;

public class ProductService : IProductService
{
    private readonly IObjectConverter _objectConverter;

    public ProductService(IObjectConverter objectConverter)
    {
        _objectConverter = objectConverter;
    }

    public Task<ProductResponse> CreateProduct(ProductRequest product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse> GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductResponse>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse> UpdateProduct(int id, ProductRequest product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateProduct(int id)
    {
        throw new NotImplementedException();
    }
}
