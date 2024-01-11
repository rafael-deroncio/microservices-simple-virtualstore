using Refit;
using VirtualStore.Cart.Core.Responses;

public interface ICatalogClientService
{
    [Get("/{id}")]
    Task<ProductResponse> GetProduct([AliasAs("id")] int productId);
}