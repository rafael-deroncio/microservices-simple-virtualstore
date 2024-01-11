using VirtualStore.Cart.Core.Configurations.DTOs;

namespace VirtualStore.Cart.Core.Models;

public class CartModel : EntityConventionsDTO
{
    public int CartId { get; set; }
    public CartHeaderModel Header { get; set;}
    public List<CartItemModel> Itens { get; set; }

}