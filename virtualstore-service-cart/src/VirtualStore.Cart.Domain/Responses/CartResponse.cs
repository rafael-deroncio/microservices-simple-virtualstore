namespace VirtualStore.Cart.Domain.Responses;

public class CartResponse
{
    public CartHeaderResponse Header { get; set; }
    public IEnumerable<CartItemResponse> Itens { get; set; }
}