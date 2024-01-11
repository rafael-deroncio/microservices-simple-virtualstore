using VirtualStore.Cart.Core.Configurations.DTOs;

namespace VirtualStore.Cart.Core.Models;

public class CartItemModel : EntityConventionsDTO
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
    public ProductModel Product { get; set; }
}