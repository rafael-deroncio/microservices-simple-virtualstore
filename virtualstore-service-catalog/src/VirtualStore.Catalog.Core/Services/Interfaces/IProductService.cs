using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services.Interfaces;

/// <summary>
/// Represents a service for managing products.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves a product based on its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductResponse object.</returns>
    Task<ProductResponse> GetProduct(int id);

    /// <summary>
    /// Retrieves a paginated collection of products.
    /// </summary>
    /// <param name="pagination">Pagination settings specifying the page number and page size.</param>
    /// <returns>A task representing the asynchronous operation. The result is a PaginationResponse containing an IEnumerable of ProductResponse objects.</returns>
    Task<PaginationResponse<IEnumerable<ProductResponse>>> GetProducts(PaginationRequest pagination);


    /// <summary>
    /// Creates a new product based on the provided product details.
    /// </summary>
    /// <param name="product">The details of the product to create.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductResponse object representing the created product.</returns>
    Task<ProductResponse> CreateProduct(ProductRequest product);

    /// <summary>
    /// Updates an existing product with the provided details.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="product">The updated details of the product.</param>
    /// <returns>A task representing the asynchronous operation. The result is a ProductResponse object representing the updated product.</returns>
    Task<ProductResponse> UpdateProduct(int id, ProductRequest product);

    /// <summary>
    /// Deletes a product based on its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>A task representing the asynchronous operation. The result is a boolean indicating the success of the deletion.</returns>
    Task<bool> DeleteProduct(int id);
}
