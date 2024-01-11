using VirtualStore.Cart.Core.Models;

namespace VirtualStore.Cart.Core.Arguments;

public class CartItemArgument
{
    public int CartItemId { get; set; }
    public int CartHeaderId { get; set; }
    public int Quantity { get; set; }
    public ProductArgument Product { get; set; }
}