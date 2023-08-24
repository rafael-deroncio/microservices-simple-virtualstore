using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;

namespace VirtualStore.Catalog.Core.Repositories.Interfaces;

public interface IProductRepository
{
    Task<ProductModel> GetProduct(int id);

    Task<IEnumerable<ProductModel>> GetProducts(PaginationArgument pagination);

    Task<ProductModel> CreateProduct(ProductArgument product);

    Task<ProductModel> UpdateProduct(ProductArgument product);

    Task<bool> DeleteProduct(int id);

    Task<int> GetTotalRegisteredProducts();
}