using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;

namespace VirtualStore.Catalog.Core.Repositories.Interfaces;

/// <summary>
/// Represents a repository for managing product data.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves a specific product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductModel object if found, otherwise null.</returns>
    Task<ProductModel> GetProduct(int id);

    /// <summary>
    /// Retrieves a paginated collection of products.
    /// </summary>
    /// <param name="pagination">Pagination settings specifying the page number and page size.</param>
    /// <returns>A task representing the asynchronous operation. The result is an IEnumerable of ProductModel objects.</returns>
    Task<IEnumerable<ProductModel>> GetPagedProducts(PaginationArgument pagination);

    /// <summary>
    /// Retrieves a collection of all products.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result is an IEnumerable of ProductModel objects.</returns>
    Task<IEnumerable<ProductModel>> GetProducts();

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">The product data to create.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductModel object representing the created product.</returns>
    Task<ProductModel> CreateProduct(ProductArgument product);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="product">The updated product data.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductModel object representing the updated product if successful, otherwise null.</returns>
    Task<ProductModel> UpdateProduct(ProductArgument product);

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>A task representing the asynchronous operation. The result is a boolean indicating the success of the delete operation.</returns>
    Task<bool> DeleteProduct(int id);

    /// <summary>
    /// Retrieves the total count of registered products.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result is an integer representing the total count of products.</returns>
    Task<int> GetTotalRegisteredProducts();
}