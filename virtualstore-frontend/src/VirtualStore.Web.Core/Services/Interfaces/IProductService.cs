using VirtualStore.Web.Core.ViewModels;

namespace VirtualStore.Web.Core.Services.Interfaces;

public interface IProductService
{
    Task<ProductViewModel> GetProductAsync(int id);

    Task<IEnumerable<ProductViewModel>> GetProductsAsync();

    Task<ProductViewModel> CreateProductAsync(ProductViewModel product);

    Task<ProductViewModel> UpdateProductAsync(int id, ProductViewModel product);

    Task<bool> DeleteProductAsync(int id);
}