namespace VirtualStore.Discount.Core.Services.Interfaces;

/// <summary>
/// Represents a service for generating URIs for endpoints.
/// </summary>
public interface IUriService
{
    /// <summary>
    /// Gets the base URI for the current endpoint.
    /// </summary>
    /// <returns>A URI representing the base endpoint URI.</returns>
    Uri GetEndpoint();
}
