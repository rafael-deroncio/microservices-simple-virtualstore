using Refit;
using VirtualStore.Discount.Core.Responses;

/// <summary>
/// Interface for service calls related to the catalog.
/// </summary>
public interface ICatalogClientService
{
    /// <summary>
    /// Retrieves information about a category based on the provided identifier.
    /// </summary>
    /// <param name="categoryId">The identifier of the category to be queried.</param>
    /// <returns>A task representing the asynchronous operation and returning a category response.</returns>
    [Get("/{id}")]
    Task<CategoryResponse> GetCategory([AliasAs("id")] int categoryId);
}
