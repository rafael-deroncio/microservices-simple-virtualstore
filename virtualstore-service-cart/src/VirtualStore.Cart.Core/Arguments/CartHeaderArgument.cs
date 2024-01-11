namespace VirtualStore.Cart.Core.Arguments;

public class CartHeaderArgument
{
    public int CartHeaderId { get; set; }
    public int CartId { get; set; }
    public int UserId { get; set; }
    public string CouponCode { get; set; }
    public decimal TotalAmount { get; set; }
}