namespace VirtualStore.Cart.Domain.Responses;

public  class CartItemResponse
{
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public ProductResponse Product { get; set; }

}