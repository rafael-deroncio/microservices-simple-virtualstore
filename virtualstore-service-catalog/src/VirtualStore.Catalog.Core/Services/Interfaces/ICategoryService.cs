using System;
using VirtualStore.Catalog.Domain.Requests;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Services.Interfaces;

/// <summary>
/// Represents a service for managing categories.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Retrieves a category based on its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryResponse object.</returns>
    Task<CategoryResponse> GetCategory(int id);

    /// <summary>
    /// Retrieves a collection of categories with pagination.
    /// </summary>
    /// <param name="pagination">The pagination details.</param>
    /// <returns>A task representing the asynchronous operation. The result is a collection of CategoryResponse objects.</returns>
    Task<PaginationResponse<IEnumerable<CategoryResponse>>> GetCategories(PaginationRequest pagination);

    /// <summary>
    /// Retrieves a collection of categories.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result is a collection of CategoryResponse objects.</returns>
    Task<IEnumerable<CategoryResponse>> GetCategories();

    /// <summary>
    /// Retrieves a category associated with a specific product.
    /// </summary>
    /// <param name="productId">The ID of the product for which the category is retrieved.</param>
    /// <returns>
    /// A task representing the asynchronous operation. 
    /// The result is a CategoryResponse object representing the category associated with the specified product.
    /// </returns>
    Task<CategoryResponse> GetCategorieByProduct(int productId);

    /// <summary>
    /// Creates a new category based on the provided category details.
    /// </summary>
    /// <param name="category">The details of the category to create.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryResponse object representing the created category.</returns>
    Task<CategoryResponse> CreateCategory(CategoryRequest category);

    /// <summary>
    /// Updates an existing category with the provided details.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="category">The updated details of the category.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryResponse object representing the updated category.</returns>
    Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category);

    /// <summary>
    /// Deletes a category based on its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>A task representing the asynchronous operation. The result is a boolean indicating the success of the deletion.</returns>
    Task<bool> DeleteCategory(int id);
}
