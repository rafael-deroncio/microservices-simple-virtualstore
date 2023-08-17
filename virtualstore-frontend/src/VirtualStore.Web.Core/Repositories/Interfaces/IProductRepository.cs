using VirtualStore.Web.Core.Requests;
using VirtualStore.Web.Core.Responses;

namespace VirtualStore.Web.Core.Repositories.Interfaces;

public interface IProductRepository
{
    Task<ProductResponse> GetProductAsync(int id);

    Task<IEnumerable<ProductResponse>> GetProductsAsync();

    Task<ProductResponse> CreateProductAsync(ProductRequest product);

    Task<ProductResponse> UpdateProductAsync(int id, ProductRequest product);

    Task<bool> DeleteProductAsync(int id);
}