using VirtualStore.Catalog.Core.Arguments;
using VirtualStore.Catalog.Core.Model;
using VirtualStore.Catalog.Domain.Responses;

namespace VirtualStore.Catalog.Core.Repositories.Interfaces;

/// <summary>
/// Represents a repository for managing categories.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a category based on its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryModel object.</returns>
    Task<CategoryModel> GetCategory(int id);

    /// <summary>
    /// Retrieves a collection of categories with pagination.
    /// </summary>
    /// <param name="argument">The pagination details.</param>
    /// <returns>A task representing the asynchronous operation. The result is a collection of CategoryModel objects.</returns>
    Task<IEnumerable<CategoryModel>> GetCategories(PaginationArgument argument);

    /// <summary>
    /// Retrieves a collection of categories.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result is a collection of CategoryModel objects.</returns>
    Task<IEnumerable<CategoryModel>> GetCategories();

    /// <summary>
    /// Retrieves a category associated with a specific product.
    /// </summary>
    /// <param name="productId">The ID of the product for which the category is retrieved.</param>
    /// <returns>
    /// A task representing the asynchronous operation. 
    /// The result is a CategoryResponse object representing the category associated with the specified product.
    /// </returns>
    Task<CategoryResponse> GetCategoryByProduct(int productId);

    /// <summary>
    /// Creates a new category based on the provided category details.
    /// </summary>
    /// <param name="category">The details of the category to create.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryModel object representing the created category.</returns>
    Task<CategoryModel> CreateCategory(CategoryArgument category);

    /// <summary>
    /// Updates an existing category with the provided details.
    /// </summary>
    /// <param name="category">The updated details of the category.</param>
    /// <returns>A task representing the asynchronous operation. The result is a CategoryModel object representing the updated category.</returns>
    Task<CategoryModel> UpdateCategory(CategoryArgument category);

    /// <summary>
    /// Deletes a category based on its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>A task representing the asynchronous operation. The result is a boolean indicating the success of the deletion.</returns>
    Task<bool> DeleteCategory(int id);

    /// <summary>
    /// Gets the total number of registered categories.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The result is an integer representing the total number of registered categories.</returns>
    Task<int> GetTotalRegisteredCategories();

    /// <summary>
    /// Checks if a category with the specified name already exists.
    /// </summary>
    /// <param name="category">The name of the category to check for existence.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result is a boolean indicating 
    /// whether a category with the specified name already exists (true) or not (false).
    /// </returns>
    Task<bool> CategoryExists(string category);
}