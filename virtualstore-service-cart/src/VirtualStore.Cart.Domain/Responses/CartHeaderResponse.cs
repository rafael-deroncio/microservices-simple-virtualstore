namespace VirtualStore.Cart.Domain.Responses;

public class CartHeaderResponse
{
    public string Username { get; set; }
    public string CouponCode { get; set; }
    public decimal TotalAmount { get; set; }
}